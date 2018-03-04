#include <sys/ipc.h>
#include <sys/shm.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>
#include <semaphore.h>
#include <pthread.h>
#include "FunctionsP.h"


void Group1task(int position, int keyb1, int sizeb1, int keyb2, int sizeb2, int keyc, int sizec, int timedelay)
{

	int shmidb2 = shmget(keyb2, sizeb2, IPC_CREAT | 0775);
	int *Buffer2 = (int *) shmat(shmidb2, NULL, 0);

	int shmidc = shmget(keyc, sizec, IPC_CREAT | 0775);
	int *counter = (int *) shmat(shmidc, NULL, 0);
	
	int validrow = 0;

	//verify row
	validrow = verifyrow(position, keyb1, sizeb1);

	//display result on screen
	printf("Validation result from PID-%u Row %d is valid \n",(unsigned int)pthread_self(), (position/9)+1);

	//timedelay
	sleep(timedelay);

	//write to buffer2
	sem_wait(&Buffer2Sem);
	Buffer2[position/9] = validrow;
	sem_post(&Buffer2Sem);

	//update counter
	sem_wait(&CounterSem);	
	*counter = *counter + validrow;
	sem_post(&CounterSem);	
	shmdt(Buffer2);

	shmdt((void*) counter);
}


void Group2task(int keyb1, int sizeb1, int keyb2, int sizeb2, int keyc, int sizec, int timedelay)
{

	int shmidb2 = shmget(keyb2, sizeb2, IPC_CREAT | 0775);
	int *Buffer2 = (int *) shmat(shmidb2, NULL, 0);

	int shmidc = shmget(keyc, sizec, IPC_CREAT | 0775);
	int *counter = (int *) shmat(shmidc, NULL, 0);

	int validcol =0;

	//verify all columns
	validcol = verifycol(keyb1, sizeb1);

	//display result on screen
	printf("Validation result from PID-%u %d of 9 columns are valid \n",(unsigned int)pthread_self(), validcol);
	//timedelay
	sleep(timedelay);

	//update buffer2
	sem_wait(&Buffer2Sem);
	Buffer2[9] = validcol;
	sem_post(&Buffer2Sem);	

	//update counter
	sem_wait(&CounterSem);	
	*counter = *counter + validcol;
	sem_post(&CounterSem);		

	shmdt(Buffer2);

	shmdt((void*) counter);

}

void Group3task(int keyb1, int sizeb1, int keyb2, int sizeb2, int keyc, int sizec, int timedelay)
{

	int shmidb2 = shmget(keyb2, sizeb2, IPC_CREAT | 0775);
	int *Buffer2 = (int *) shmat(shmidb2, NULL, 0);

	int shmidc = shmget(keyc, sizec, IPC_CREAT | 0775);
	int *counter = (int *) shmat(shmidc, NULL, 0);

	int validgrid =0;

	//verify all subgrids
	validgrid = verify3x3subgrid(keyb1, sizeb1);

	//display result on screen
	printf("Validation result from PID-%u %d of 9 3x3 subgrids are valid \n",(unsigned int)pthread_self(), validgrid);
	//timedelay
	sleep(timedelay);

	//update buffer2
	sem_wait(&Buffer2Sem);	
	Buffer2[10] = validgrid;
	sem_post(&Buffer2Sem);	

	//update counter
	sem_wait(&CounterSem);	
	*counter = *counter + validgrid;
	sem_post(&CounterSem);		

	shmdt(Buffer2);

	shmdt((void*) counter);

}

void populateBuffer1(char *filename, int keyb1, int sizeb1)
{
	int *Buffer1;
	int shmidb1 = shmget(keyb1, sizeb1, IPC_CREAT | 0775);
	Buffer1 = (int *) shmat(shmidb1, NULL, 0);
	//opening sudoku solution file for reading
	FILE *f;
	f = fopen(filename, "r");

	if(f == NULL)
	{
		printf("Input file error");
	}
	else
	{
		printf("Input file succesfully read \n");
		//entering solution into Buffer1 array
		for (int i = 0; i<81; i++)
		{
			fscanf(f, "%d", &Buffer1[i]);
		
		}

		fclose(f);
	}
	shmdt(Buffer1);
}

//takes starting position of row and compares the 9 numbers from there. Return 1 if all numbers are unique and only comprises of 1-9 digits.
int verifyrow(int position, int keyb1, int sizeb1)
{

	int *Buffer1;
	int shmidb1 = shmget(11111, 81, IPC_CREAT | 0775);
	Buffer1 = (int *) shmat(shmidb1, NULL, 0);

	int valid;
	int numofInvalid=0;
	int tempbuf[9];


	for (int k = position; k < position+9; k++)
	{

		if (Buffer1[k] > 9)
		{
			numofInvalid++;

		}
		else if (Buffer1[k] < 1)
		{
			numofInvalid++;
		}

	}

	if (numofInvalid == 0)
	{
		for (int i = position; i < position+8; i++) 
		{
			for (int j = i + 1; j< position+9; j++) 
			{				
       				if (Buffer1[i] == Buffer1[j]) 
				{
					numofInvalid++;

				}		
			}
		}
	}

	if(numofInvalid>0)
	{
		valid=0;
		//append log file
		FILE *logf = fopen("ProcessLogFile.txt", "a");
		fprintf(logf, "PID-%u Row %d is invalid \n",(unsigned int)pthread_self(), (position/9)+1);
		fclose(logf);
	}
	else
	{
		valid=1;
		//append log file
		FILE *logf = fopen("ProcessLogFile.txt", "a");
		fprintf(logf, "PID-%u Row %d is valid \n",(unsigned int)pthread_self(), (position/9)+1);
		fclose(logf);
	}
	shmdt(Buffer1);

	return valid;
}

//check if all the numbers in a row are unique if exists within range 1-9
int verifycol(int keyb1, int sizeb1)
{

	int *Buffer1;
	int shmidb1 = shmget(keyb1, sizeb1, IPC_CREAT | 0775);
	Buffer1 = (int *) shmat(shmidb1, NULL, 0);

	int valid = 0;
	int numofInvalidpercol;

	for (int m = 0; m < 9; m++)
	{
		int tempcolbuffer[9];
		int tempbuffercount = 0;
		numofInvalidpercol = 0;
		for (int n = m; n < m+73; n = n+9)
		{
		
			tempcolbuffer[tempbuffercount] = Buffer1[n];
			tempbuffercount++;
		}

		for (int k = 0; k < 9; k++)
		{
			if (tempcolbuffer[k] > 9)
			{
				numofInvalidpercol++;
			}
			else if (tempcolbuffer[k] < 1)
			{
				numofInvalidpercol++;

			}
		}

		for (int i = 0; i <  9; i++) 
		{
			for (int j = i + 1; j< 10; j++) 
			{				
       				if (tempcolbuffer[i] == tempcolbuffer[j]) 
				{
					numofInvalidpercol++;

				}		
			}
		}

		if(numofInvalidpercol == 0)
		{
			valid ++;
			//append log file
			FILE *logf = fopen("ProcessLogFile.txt", "a");
			fprintf(logf, "PID-%u Column %d is valid \n",(unsigned int)pthread_self(), m+1);
			fclose(logf);
		}
		else
		{
			//append log file
			FILE *logf = fopen("ProcessLogFile.txt", "a");
			fprintf(logf, "PID-%u Column %d is invalid \n",(unsigned int)pthread_self(), m+1);
			fclose(logf);
		}

	}
	shmdt(Buffer1);	
	return valid;
}

//checks if all number in subgrids one to nine are unique and exists within range 0-9
int verify3x3subgrid(int keyb1, int sizeb1)
{

	int *Buffer1;
	int shmidb1 = shmget(keyb1, sizeb1, IPC_CREAT | 0775);
	Buffer1 = (int *) shmat(shmidb1, NULL, 0);

	int numinvalidpersg;
	int valid = 0;
	int outercounter = 0;
	for(int s=0; s < 61 ;s = s +3)
	{
		outercounter ++;
		int innercounter=0;
		int tempsgbuffer[9];
		numinvalidpersg=0;

		tempsgbuffer[0] = Buffer1[s];
		tempsgbuffer[1] = Buffer1[s+1];
		tempsgbuffer[2] = Buffer1[s+2];
		tempsgbuffer[3] = Buffer1[s+9];
		tempsgbuffer[4] = Buffer1[s+10];
		tempsgbuffer[5] = Buffer1[s+11];
		tempsgbuffer[6] = Buffer1[s+18];
		tempsgbuffer[7] = Buffer1[s+19];
		tempsgbuffer[8] = Buffer1[s+20];

		for (int k = 0; k < 9; k++)
		{
			if (tempsgbuffer[k] > 9)
			{
				numinvalidpersg++;
			}
			else if (tempsgbuffer[k] < 1)
			{
				numinvalidpersg++;
			}

		}

		for (int i = 0; i <  9; i++) 
		{
			for (int j = i + 1; j< 10; j++) 
			{				
       				if (tempsgbuffer[i] == tempsgbuffer[j]) 
				{
					numinvalidpersg++;
				}		
			}	
		}
		
		if(numinvalidpersg == 0)
		{
			valid ++;

			//append log file
			FILE *logf = fopen("ProcessLogFile.txt", "a");
			fprintf(logf, "PID-%u 3x3 SubGrid start at spot %d (counting left to right, top to bottom) is valid \n",(unsigned int)pthread_self(), s+1);
			fclose(logf);
		}
		else
		{
			//append log file
			FILE *logf = fopen("ProcessLogFile.txt", "a");
			fprintf(logf, "PID-%u 3x3 SubGrid start at spot %d (counting left to right, top to bottom)is invalid \n",(unsigned int)pthread_self(), s+1);
			fclose(logf);
		}

		switch(outercounter)
		{
			case 3:
			case 6:
				s = s + 18;
				break;
		}
	
	}
	shmdt(Buffer1);
	return valid;
}

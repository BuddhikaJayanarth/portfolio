#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <unistd.h>
#include "Functions.h"


void *Group1task(void *arg){
	
	long int position = (long int)arg;

	int validrow = 0;
	//verify row
	validrow = verifyrow(position);

	//display result on screen
	printf("Validation result from PID-%u Row %ld is valid \n",(unsigned int)pthread_self(), (position/9)+1);

	//timedelay
	sleep(timedelay);

	//write to buffer2
	pthread_mutex_lock(&buffer2mutex);
	Buffer2[position/9] = validrow;
	pthread_mutex_unlock(&buffer2mutex);

	//update counter
	pthread_mutex_lock(&countermutex);
	counter = counter + validrow;
	pthread_mutex_unlock(&countermutex);

	pthread_exit(NULL);
}


void *Group2task(void *arg)
{

	int validcol =0;

	//verify all columns
	validcol = verifycol();

	//display result on screen
	printf("Validation result from PID-%u %d of 9 columns are valid \n",(unsigned int)pthread_self(), validcol);

	//timedelay
	sleep(timedelay);

	//update buffer2
	pthread_mutex_lock(&buffer2mutex);
	Buffer2[9] = validcol;
	pthread_mutex_unlock(&buffer2mutex);

	//update counter
	pthread_mutex_lock(&countermutex);
	counter = counter + validcol;
	pthread_mutex_unlock(&countermutex);

	pthread_exit(NULL);

}

void *Group3task(void *arg)
{

	int validgrid =0;

	//verify all subgrids
	validgrid = verify3x3subgrid();

	//display result on screen
	printf("Validation result from PID-%u %d of 9 3x3 subgrids are valid \n",(unsigned int)pthread_self(), validgrid);
	//timedelay
	sleep(timedelay);

	//update buffer2
	pthread_mutex_lock(&buffer2mutex);
	Buffer2[10] = validgrid;
	pthread_mutex_unlock(&buffer2mutex);

	//update counter
	pthread_mutex_lock(&countermutex);
	counter = counter + validgrid;
	pthread_mutex_unlock(&countermutex);

	pthread_exit(NULL);

}

void populateBuffer1(char *filename)
{

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
}

//takes starting position of row and compares the 9 numbers from there. Return 1 if all numbers are unique and only comprises of 1-9 digits.
int verifyrow(long int position)
{
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
		FILE *logf = fopen("ThreadLogFile.txt", "a");
		fprintf(logf, "PID-%u Row %ld is invalid \n",(unsigned int)pthread_self(), (position/9)+1);
		fclose(logf);
	}
	else
	{
		valid=1;
		//append log file
		FILE *logf = fopen("ThreadLogFile.txt", "a");
		fprintf(logf, "PID-%u Row %ld is valid \n",(unsigned int)pthread_self(), (position/9)+1);
		fclose(logf);
	}
	return valid;
}

//check if all the numbers in a row are unique if exists within range 1-9
int verifycol()
{
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
			FILE *logf = fopen("ThreadLogFile.txt", "a");
			fprintf(logf, "PID-%u Column %d is valid \n",(unsigned int)pthread_self(), m+1);
			fclose(logf);
		}
		else
		{
			//append log file
			FILE *logf = fopen("ThreadLogFile.txt", "a");
			fprintf(logf, "PID-%u Column %d is invalid \n",(unsigned int)pthread_self(), m+1);
			fclose(logf);
		}

	}
return valid;
}

//checks if all number in subgrids one to nine are unique and exists within range 0-9
int verify3x3subgrid()
{
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
			FILE *logf = fopen("ThreadLogFile.txt", "a");
			fprintf(logf, "PID-%u 3x3 SubGrid start at spot %d (counting left to right, top to bottom) is valid \n",(unsigned int)pthread_self(), s+1);
			fclose(logf);
		}
		else
		{
			//append log file
			FILE *logf = fopen("ThreadLogFile.txt", "a");
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

return valid;
}

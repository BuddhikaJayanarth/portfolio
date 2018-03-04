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


int main(int argc, char *argv[])
{	
	int pid;
	int shmidb1;
	int shmidb2;
	int shmidc;
	int *Buffer1;
	int *Buffer2;
	int *counter;
	int keyb1 = 11111;
	int keyb2 = 22222;
	int keyc = 33333;
	int sizeb1 = 81;
	int sizeb2 = 11;
	int sizec = 1;
	int position;
	
	//(re)create log file

	FILE *logf = fopen("ProcessLogFile.txt", "w");
	fprintf(logf, "-----||Log file for Process Program||----- \n \n");
	fclose(logf);

	//initialising semaphores
	sem_init(&Buffer2Sem, 1, 1);
	sem_init(&CounterSem, 1, 1);

	int timedelay = atoi(argv[2]);

	//creating shared memories
	shmidb1 = shmget(keyb1, sizeb1, IPC_CREAT | 0775);
	shmidb2 = shmget(keyb2, sizeb2, IPC_CREAT | 0775);
	shmidc = shmget(keyc, sizec, IPC_CREAT | 0775);

	//attaching Buffer 1, Buffer 2, Counter pointers to reference shared memory
	Buffer1 = (int *) shmat(shmidb1, NULL, 0);
	Buffer2 = (int *) shmat(shmidb2, NULL, 0);
	counter = (int *) shmat(shmidc, NULL, 0);

	*counter = 0;

	//reading and assign to buffer1
	populateBuffer1(argv[1], keyb1, sizeb1);


	//create 11 child processes for 3 groups of tasks
	for (position = 0; position <91; position = position +9)	
	{

		if (position<73)
		{
			//create process for group 1
			pid = fork();
			if(pid == -1)
			{
				printf("Group1 child failed");
			}
			else if(pid == 0)
			{
				//a child process for Group 1 task
				Group1task(position, keyb1, sizeb1, keyb2, sizeb2, keyc, sizec, timedelay);

				exit(0);
			}
			else
			{
				//parent process

			}

		}
		else
		{
			if (position==81)
			{
				//create process for group 2
				pid = fork();
				if(pid == -1)
				{
					printf("Group2 child failed");
				}
				else if(pid == 0)
				{
					//a child process for Group 2 task
					Group2task(keyb1, sizeb1, keyb2, sizeb2, keyc, sizec, timedelay);
				
					exit(0);
				}
				else
				{
					//parent process

				}
			}

			else
			{
				//create process for group 3
				pid = fork();
				if(pid == -1)
				{
					printf("Group3 child failed");
				}
				else if(pid == 0)
				{
					//a child process for Group 3 task
					Group3task(keyb1, sizeb1, keyb2, sizeb2, keyc, sizec, timedelay);
				
					exit(0);
				}
				else
				{
					//parent process

				}
			}
		}
	}

	//Wait for all child processes to terminate before waking parent
	for (int i = 0; i<11; i++)
	{
	wait(NULL);
	}

	//Display Solution Summary
	printf("\nCount of valid rows, columns and subgrids: %d ", *counter);

	if (*counter == 27)
	{
		printf("and thus solution is valid\n");
	}
	else{
		printf("and thus solution is invalid\n");
	}

	//detach shared memories
	shmdt((void*) counter);
	shmdt(Buffer1);
	shmdt(Buffer2);

	//deallocate shared memory space
	shmctl(shmidb1,IPC_RMID, NULL);
	shmctl(shmidb2,IPC_RMID, NULL);
	shmctl(shmidc,IPC_RMID, NULL);

	return 0;
}

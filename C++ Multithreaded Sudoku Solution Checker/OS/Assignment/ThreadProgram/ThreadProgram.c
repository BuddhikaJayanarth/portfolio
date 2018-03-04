#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <unistd.h>
#include "Functions.h"

int Buffer1[81]; //array to hold the incoming sudoku solution
int Buffer2[11]; //array to hold results for 9 individual row tests, 1 all-columns test, 1 all-subgrids test
int counter;	//counts the sum of valid rows, columns, subgrids
int timedelay; //user specified time delay for threads


int main(int argc, char *argv[])
{
	//(re)create log file

	FILE *logf = fopen("ThreadLogFile.txt", "w");
	if(logf == NULL)
	{
	perror("Error");
	}
	fprintf(logf, "-----||Log file for Thread Program||----- \n \n");
	fclose(logf);

	long int position;
	counter = 0;
	pthread_t threads[11];
	timedelay = atoi(argv[2]);

	//reading and assign to buffer1
	populateBuffer1(argv[1]);

	if (pthread_mutex_init(&buffer2mutex, NULL) ==0)
	{
	//	printf("\n bmutex success");
	}

	if (pthread_mutex_init(&countermutex, NULL) ==0)
	{
	//	printf("\n cmutex success");
	}

	//create 11 threads for 3 groups of tasks
	for (position = 0; position <91; position = position +9)	
	{

		if (position<73)
		{
			//create thread for group 1
			pthread_create(&threads[position/9],NULL,Group1task,(void *)position);

		}
		else
		{
			if (position==81)
			{
				//create thread for group 2
			pthread_create(&threads[position/9],NULL,Group2task,NULL);
			}

			else
			{
				//create thread for group 3
			pthread_create(&threads[position/9],NULL,Group3task,NULL);
			}
		}
	}

	//wait for all child threads to exit before resuming parent
	for (int i = 0; i<11; i++)
	{
		pthread_join(threads[i],NULL);
	}

	//Display Solution Summary
	printf("\nCount of valid rows, columns and subgrids: %d ", counter);

	if (counter == 27)
	{
		printf("and thus solution is valid\n");
	}
	else{
		printf("and thus solution is invalid\n");
	}
	return 0;
}

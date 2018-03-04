#ifndef FUNCTIONS_H_INCLUDED
#define FUNCTIONS_H_INCLUDED


extern int Buffer1[];
extern int Buffer2[];
extern int counter;
extern int timedelay;

pthread_mutex_t buffer2mutex;
pthread_mutex_t countermutex;
pthread_mutex_t verifymutex;

void *Group1task(void *);

void *Group2task(void *arg);

void *Group3task(void *arg);

void populateBuffer1(char *filename);

int verifyrow(long int position);

int verifycol();

int verify3x3subgrid();


#endif

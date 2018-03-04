#ifndef FUNCTIONSP_H_INCLUDED
#define FUNCTIONSP_H_INCLUDED

sem_t Buffer2Sem;
sem_t CounterSem;

void Group1task(int position, int keyb1, int sizeb1, int keyb2, int sizeb2, int keyc, int sizec, int timedelay);

void Group2task(int keyb1, int sizeb1, int keyb2, int sizeb2, int keyc, int sizec, int timedelay);

void Group3task(int keyb1, int sizeb1, int keyb2, int sizeb2, int keyc, int sizec, int timedelay);

void populateBuffer1(char *filename, int keyb1, int sizeb1);

int verifyrow(int position, int keyb1, int sizeb1);

int verifycol(int keyb1, int sizeb1);

int verify3x3subgrid(int keyb1, int sizeb1);


#endif

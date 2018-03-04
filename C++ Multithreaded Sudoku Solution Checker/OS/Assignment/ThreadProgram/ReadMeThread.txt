For ThreadProgram.c:

--If necessary---------------------------
sudo chmod u+x ThreadProgram.c
sudo chmod u+x Functions.c
--------------------------------------------

gcc -pthread -c Functions.c
gcc -pthread -c ThreadProgram.c
gcc -pthread -c Functions.o ThreadProgram.o -o ThreadExe
	//Either Incorrect Sudoku Solution Input File
./ThreadExe input.txt 5
	//Or Correct Sudoku Solution Input File
./ThreadExe correctinput.txt 5

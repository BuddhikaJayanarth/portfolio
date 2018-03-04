For ProcessProgram.c:

--If necessary---------------------------
sudo chmod u+x ProcessProgram.c
sudo chmod u+x FunctionsP.c
--------------------------------------------

gcc -pthread -c FunctionsP.c
gcc -pthread -c ProcessProgram.c
gcc -pthread -c FunctionsP.o ProcessProgram.o -o ProcessExe
	//Either Incorrect Sudoku Solution Input File
./ProcessExe input.txt 5
	//Or Correct Sudoku Solution Input File
./ProcessExe correctinput.txt 5

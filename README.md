# Problem description

P(T)Vzzle – 2021-12-09

A map is represented as a matrix of 0s and 1s, where 0s are passable space and 1s are impassable walls. 
A door out of the prison is at the top left (0,0) and a door into an escape pod is at the bottom right (w-1,h-1).

Write a function solution(map) that generates the shortest path from the prison door to the escape pod, 
where you are allowed to remove one wall as part of your remodeling plans. The path length is the total number of nodes
you pass through, counting both the entrance and exit nodes. The starting and ending positions are always passable (0).
The map will always be solvable, though you may or may not need to remove a wall. 
The height and width of the map can be from 2 to 20. Moves can only be made in cardinal directions; 
no diagonal moves are allowed.

# Install .NET 6

## Windows
Run dotnet-install.ps1

## Linux/Mac
Run dotnet-install.sh

# Execute
cd PtVzzlePrison

dotnet run -- \<input-file-name\>

## File format
The input file must be a text file with N rows.

Each row must contain M integers in [0, 1] separated by spaces

All rows must have the same number of elemets.

Examples of valid and invalid input files are provided in the
directory PvVzzlePrison.Tests\Resources\.

## Output
A text file named \<input-file-name-without-extension\>.solution with the following format:

If no solution was found, the file is empty.

If a sloution was found, the file is composed by three blocks, separated by blank lines.

The fist block represents the solution; like the input file there are N rows, and each
row has M integers in [0, 1] with the ones representing the solution path.

The second block is the cost of the solution (the sum of the ones minus one).

The third (optional) block contains two integers in ([0, N-1], [0, M-1]) of the opened wall.
If no wall was opened, the block is missing.

Solution examples (files with "expected" extension) are provided in the PvVzzlePrison.Tests\Resources\ directory.

## Tests
cd PtVzzlePrison.Tests
dotnet test

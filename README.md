# Install .NET 6

## Windows
Run dotnet-install.ps1

## Linux/Mac
Run dotnet-install.sh

# Execute
cd PtVzzlePrison
dotnet run -- <input-file-name>

## File format
The input file must be a text file with N rows.

Each row must contain M integers in [0, 1] separated by spaces

All rows must have the same number of elemets.

Examples of valid and invalid input files are provided in the
directory PvVzzlePrison.Tests\Resources\.

## Output
A text file named <input-file-name-without-extension>.solution with the following format:

If no solution was found, the file is empty.

If a sloution was found, the file is composed by three blocks, separated by blank lines.

The fist block represents the solution; like the input file there are N rows, and each
row has M integers in [0, 1] with the ones representing the solution path.

The second block id the cost of the solution (the sum of the ones).

The third (optional) block contains two integers in ([0, N-1], [0, M-1]) of the opened wall.
If no wall was opened, the block is missing.

Solution examples are provided in the PvVzzlePrison.Tests\Resources\ directory.

## Tests
cd PtVzzlePrison.Tests
dotnet test
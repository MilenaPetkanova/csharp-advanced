using System;
using System.Linq;

class SquaresInMatrix
{
    static void Main()
    {
        var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int rows = sizes[0];
        int columns = sizes[1];

        string[,] matrix = new string[rows, columns];

        int squaresCounter = 0;

        for (int row = 0; row < rows; row++)
        {
            var currentRow = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int column = 0; column < columns; column++)
            {
                matrix[row,column] = currentRow[column];
            }
        }

        for (int row = 0; row < rows - 1; row++)
        {
            for (int column = 0; column < columns - 1; column++)
            {
                if (matrix[row, column] == matrix[row, column + 1] &&
                    matrix[row, column] == matrix[row + 1, column] &&
                    matrix[row + 1, column] == matrix[row + 1, column + 1])
                {
                    squaresCounter++;
                }
            }
        }

        Console.WriteLine(squaresCounter);
    }
}

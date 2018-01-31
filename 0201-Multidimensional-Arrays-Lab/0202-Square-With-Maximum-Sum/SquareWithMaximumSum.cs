using System;
using System.Linq;

class SquareWithMaximumSum
{
    static void Main()
    {
        var sizes = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int rows = sizes[0];
        int columns = sizes[1];
        int maxSum = 0;
        int bestRow = 0;
        int bestColumn = 0;

        int[,] matrix = new int[rows,columns];
        matrix = ReadMatrix(rows, columns, matrix);

        for (int row = 0; row < rows - 1; row++)
        {
            for (int column = 0; column < columns - 1; column++)
            {
                int currentSum = matrix[row, column] + matrix[row, column + 1] +
                        matrix[row + 1, column] + matrix[row + 1, column + 1];
                if (currentSum > maxSum)
                {
                    bestRow = row;
                    bestColumn = column;
                    maxSum = currentSum;
                }
            }
        }

        PrintBestSubmatrix(matrix, bestRow, bestColumn, maxSum);
    }

    private static void PrintBestSubmatrix(int[,] matrix, int bestRow, int bestColumn, int maxSum)
    {
        Console.WriteLine("{0} {1}", matrix[bestRow, bestColumn], matrix[bestRow, bestColumn + 1]);
        Console.WriteLine("{0} {1}", matrix[bestRow + 1, bestColumn], matrix[bestRow + 1, bestColumn + 1]);
        Console.WriteLine(maxSum);
    }

    private static int[,] ReadMatrix(int rows, int columns, int[,] matrix)
    {
        for (int row = 0; row < rows; row++)
        {
            var elements = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int column = 0; column < columns; column++)
            {
                matrix[row, column] = elements[column];
            }
        }
        return matrix;
    }
}

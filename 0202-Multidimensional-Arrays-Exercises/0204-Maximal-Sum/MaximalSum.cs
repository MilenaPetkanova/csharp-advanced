using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rows = sizes[0];
        int columns = sizes[1];

        int[,] matrix = new int[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            var currentRow = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            for (int column = 0; column < columns; column++)
            {
                matrix[row, column] = currentRow[column];
            }
        }

        int maxSum = int.MinValue;
        int maxRow = 0;
        int maxColumn = 0;

        for (int row = 0; row < rows - 2; row++)
        {
            for (int column = 0; column < columns - 2; column++)
            {
                int currentSum = matrix[row, column] + matrix[row, column + 1] + matrix[row, column + 2]
                    + matrix[row + 1, column] + matrix[row + 1, column + 1] + matrix[row + 1, column + 2]
                    + matrix[row + 2, column] + matrix[row + 2, column + 1] + matrix[row + 2, column + 2];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxRow = row;
                    maxColumn = column;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");
        for (int row = maxRow; row < maxRow + 3; row++)
        {
            Console.WriteLine("{0} {1} {2}", matrix[row, maxColumn],
                matrix[row, maxColumn + 1], matrix[row, maxColumn + 2]);
        }
    }
}

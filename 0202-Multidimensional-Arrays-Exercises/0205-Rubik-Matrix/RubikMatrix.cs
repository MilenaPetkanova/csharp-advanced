using System;
using System.Linq;

class RubikMatrix
{
    static void Main()
    {
        var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rows = sizes[0];
        int columns = sizes[1];

        int[,] matrix = new int[rows, columns];
        int incrNumber = 1;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                matrix[row, column] = incrNumber;
                incrNumber++;
            }
        }

        int countCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < countCommands; i++)
        {
            var command = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int index = int.Parse(command[0]);
            string direction = command[1];
            int moves = int.Parse(command[2]);

            if (direction == "left")
            {
                for (int move = 0; move < moves; move++)
                {
                    int firstElement = matrix[index, 0];
                    for (int j = 1; j < matrix.GetLength(0); j++)
                    {
                        matrix[index, j - 1] = matrix[index, j];
                    }
                    matrix[index, matrix.GetLength(0) - 1] = firstElement;
                }
            }

            else if (direction == "right")
            {
                for (int move = 0; move < moves; move++)
                {
                    int lastElement = matrix[index, matrix.GetLength(0) - 1];
                    for (int j = matrix.GetLength(0) - 1; j >= 1; j--)
                    {
                        matrix[index, j] = matrix[index, j - 1];
                    }
                    matrix[index, 0] = lastElement;
                }
            }

            else if (direction == "up")
            {
                for (int move = 0; move < moves; move++)
                {
                    int firstElement = matrix[0, index];
                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {
                        matrix[j - 1, index] = matrix[j, index];
                    }
                    matrix[matrix.GetLength(1) - 1, index] = firstElement;
                }
            }

            else if (direction == "down")
            {
                for (int move = 0; move < moves; move++)
                {
                    int lastElement = matrix[matrix.GetLength(1) - 1, index];
                    for (int j = matrix.GetLength(1) - 1; j >= 1; j--)
                    {
                        matrix[j, index] = matrix[j - 1, index];
                    }
                    matrix[0, index] = lastElement;
                }
            }
        }

        int originalNumber = 1;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                if (matrix[row, column] == originalNumber)
                {
                    Console.WriteLine("No swap required");
                }
                else
                {
                    int[] numToSwap = FindNumberInMatrix(matrix, originalNumber);

                    Console.WriteLine($"Swap ({row}, {column}) with ({numToSwap[0]}, {numToSwap[1]})");

                    matrix[numToSwap[0], numToSwap[1]] = matrix[row, column];
                    matrix[row, column] = originalNumber;
                }

                originalNumber++;
            }
        }
    }

    private static int[] FindNumberInMatrix(int[,] matrix, int originalNum)
    {
        var indexes = new int[2];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                if (matrix[row, column] == originalNum)
                {
                    indexes[0] = row;
                    indexes[1] = column;
                }
            }
        }

        return indexes;
    }
}

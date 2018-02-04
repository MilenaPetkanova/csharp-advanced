using System;
using System.Linq;

class DiagonalDifference
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int[,] matrix = new int[size, size];

        int primaryIndex = 0;
        int primarySum = 0;
        int secondaryIndex = size - 1;
        int secondarySum = 0;

        for (int row = 0; row < size; row++)
        {
            var rowElements = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int column = 0; column < size; column++)
            {
                matrix[row, column] = rowElements[column];
            }

            primarySum += matrix[row, primaryIndex];
            primaryIndex++;
            secondarySum += matrix[row, secondaryIndex];
            secondaryIndex--;
        }

        int difference = primarySum - secondarySum;
        Console.WriteLine(difference);
    }
}

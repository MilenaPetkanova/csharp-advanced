using System;
using System.Linq;

class SumMatrixElements
{
    static void Main()
    {
        var sizes = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int rows = sizes[0];
        int columns = sizes[1];
        int sumElements = 0;

        for (int row = 0; row < rows; row++)
        {
            var inputRow = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int column = 0; column < columns; column++)
            {
                sumElements += inputRow[column];
            }
        }

        Console.WriteLine(rows);
        Console.WriteLine(columns);
        Console.WriteLine(sumElements);
    }
}

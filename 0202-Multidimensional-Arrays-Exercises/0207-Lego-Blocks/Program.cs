using System;
using System.Linq;

class LegoBlocks
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());

        int[][] firstLego = new int[rows][];
        int[][] secondLego = new int[rows][];

        int cellCounter = 0;

        for (int row = 0; row < rows; row++)
        {
            var rowElements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int columns = rowElements.Length;

            firstLego[row] = new int[columns];

            for (int column = 0; column < columns; column++)
            {
                firstLego[row][column] = rowElements[column];
                cellCounter++;
            }
        }

        for (int row = 0; row < rows; row++)
        {
            var rowElements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int columns = rowElements.Length;
            int columnCounter = 0;
            secondLego[row] = new int[columns];

            for (int column = columns - 1; column >= 0; column--)
            {
                secondLego[row][column] = rowElements[columnCounter];
                columnCounter++;
                cellCounter++;
            }
        }

        int firstRowMatch = firstLego[0].Length + secondLego[0].Length;
        bool isFit = true;
        for (int row = 1; row < rows; row++)
        {
            if (firstLego[row].Length + secondLego[row].Length != firstRowMatch)
            {
                isFit = false;
                break;
            }
        }

        if (isFit == false)
        {
            Console.WriteLine($"The total number of cells is: {cellCounter}");
        }
        else
        {
            for (int row = 0; row < rows; row++)
            {
                Console.Write("[");
                for (int col = 0; col < firstLego[row].Length; col++)
                {
                    Console.Write($"{firstLego[row][col]}, ");
                }
                for (int col = 0; col < secondLego[row].Length; col++)
                {
                    if (col != secondLego[row].Length - 1)
                    {
                        Console.Write($"{secondLego[row][col]}, ");
                    }
                    else
                    {
                        Console.Write($"{secondLego[row][col]}");
                    }
                }
                Console.Write("]");
                Console.WriteLine();
            }

        }
    }
}

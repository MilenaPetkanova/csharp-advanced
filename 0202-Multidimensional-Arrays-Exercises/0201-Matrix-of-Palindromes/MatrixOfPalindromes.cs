using System;

class MatrixOfPalindromes
{
    static void Main()
    {
        var input = Console.ReadLine().Split(' ');

        int rows = int.Parse(input[0]);
        int columns = int.Parse(input[1]);

        var matrix = new string[rows, columns];

        var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        for (int row = 0; row < rows; row++)
        {
            for (int column = row; column < columns + row; column++)
            {
                string palindrome = alphabet[row].ToString() + alphabet[column] + alphabet[row];
                matrix[row, column - row] = palindrome;
            }
        }

        PrintMatrix(matrix);
    }

    private static void PrintMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                Console.Write($"{matrix[row, column]} ");
            }
            Console.WriteLine();
        }
    }
}

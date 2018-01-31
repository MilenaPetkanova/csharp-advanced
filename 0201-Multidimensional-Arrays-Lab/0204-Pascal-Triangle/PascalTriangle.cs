using System;

class PascalTriangle
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());

        long[][] triangle = new long[height][];

        triangle[0] = new long[1];
        triangle[0][0] = 1;

        for (int row = 0; row < height; row++)
        {
            triangle[row] = new long[row + 1];
            triangle[row][0] = 1;

            for (int col = 1; col <= row - 1; col++)
            {
                triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
            }

            triangle[row][row] = 1;
        }

        for (int row = 0; row < triangle.Length; row++)
        {
            for (int col = 0; col < triangle[row].Length; col++)
            {
                Console.Write("{0} ", triangle[row][col]);
            }
            Console.WriteLine();
        }
    }
}

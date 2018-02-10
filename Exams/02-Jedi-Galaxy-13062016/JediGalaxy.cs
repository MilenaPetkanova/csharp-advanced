using System;
using System.Linq;

// 10/100

class JediGalaxy
{
    static void Main()
    {
        var rowsColumns = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int rows = rowsColumns[0];
        int columns = rowsColumns[1];

        var galaxy = new int[rows][];
        FillGalaxyStars(rows, columns, galaxy);

        long result = 0;

        var inputLine = string.Empty;
        while ((inputLine = Console.ReadLine()) != "Let the Force be with you")
        {
            var ivoStartCoordinates = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var evelStartCoordinates = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();


            Func<int, int, int, int, bool> ivoEntersGalaxy = (r, c, rowsCount, columnsCount) => r >= 1 && r < rowsCount && c >= 0 && c < columnsCount;
            int ivoCurrentRow = ivoStartCoordinates[0];
            int ivoCurrentColumn = ivoStartCoordinates[1];
            while (!ivoEntersGalaxy(ivoCurrentRow, ivoCurrentColumn, rows, columns))
            {
                ivoCurrentRow--;
                ivoCurrentColumn++;
            }

            Func<int, int, int, int, bool> evelEntersGalaxy = (r, c, rowsCount, columnsCount) => r >= 1 && r < rowsCount && c >= 0 && c < columnsCount;
            int evelCurrentRow = evelStartCoordinates[0];
            int evelCurrentColumn = evelStartCoordinates[1];
            while (!evelEntersGalaxy(evelCurrentRow, evelCurrentColumn, rows, columns))
            {
                evelCurrentRow--;
                evelCurrentColumn--;
            }

            ProcessDestroyingGalaxies(galaxy, evelCurrentRow, evelCurrentColumn);

            result = GatherStars(galaxy, result, ivoCurrentRow, ivoCurrentColumn);
        }

        Console.WriteLine(result);
    }

    private static long GatherStars(int[][] galaxy, long result, int ivoCurrentRow, int ivoCurrentColumn)
    {
        while (ivoCurrentRow >= 0)
        {
            result += galaxy[ivoCurrentRow][ivoCurrentColumn];
            ivoCurrentRow--;
            ivoCurrentColumn++;
        }
        return result;
    }

    private static void ProcessDestroyingGalaxies(int[][] galaxy, int evelCurrentRow, int evelCurrentColumn)
    {
        while (evelCurrentRow >= 0)
        {
            galaxy[evelCurrentRow][evelCurrentColumn] = 0;
            evelCurrentRow--;
            evelCurrentColumn--;
        }
    }

    private static void FillGalaxyStars(int rows, int columns, int[][] galaxy)
    {
        int starPower = 0;
        for (int row = 0; row < rows; row++)
        {
            galaxy[row] = new int[columns];
            for (int column = 0; column < columns; column++)
            {
                galaxy[row][column] = starPower;
                starPower++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

class Sneaking
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        var room = new char[rows][];
        for (int row = 0; row < rows; row++)
        {
            room[row] = Console.ReadLine().ToCharArray();
        }

        int[] samPosition = SearchForSam(room);
        var notMovingEnemies = new SortedList<int, int>();

        var directions = Console.ReadLine().ToCharArray();
        foreach (var direction in directions)
        {
            EnemyMoves(room, notMovingEnemies);
            samPosition = SamMoves(room, direction, samPosition);
        }
    }

    private static int[] SamMoves(char[][] room, char direction, int[] samPosition)
    {
        int samRow = samPosition[0];
        int samCol = samPosition[1];

        room[samRow][samCol] = '.';

        switch (direction)
        {
            case 'U':
                samRow--;
                room[samRow][samCol] = 'S';
                break;
            case 'D':
                samRow++;
                room[samRow][samCol] = 'S';
                break;
            case 'L':
                samCol--;
                room[samRow][samCol] = 'S';
                break;
            case 'R':
                samCol++;
                room[samRow][samCol] = 'S';
                break;
            case 'W':
                room[samRow][samCol] = 'S';
                break;
            default:
                break;
        }

        CheckIfSamKillsNico(room, samRow);

        CheckIfEnemyKillsSam(room, samRow, samCol);

        samPosition[0] = samRow;
        samPosition[1] = samCol;
        return samPosition;
    }

    private static void CheckIfSamKillsNico(char[][] room, int samRow)
    {
        if (room[samRow].Contains('N'))
        {
            int nicoCol = 0;
            for (int i = 0; i < room[samRow].Length; i++)
            {
                if (room[samRow][i] == 'N')
                {
                    nicoCol = i;
                    break;
                }

            }
            room[samRow][nicoCol] = 'X';
            Console.WriteLine("Nikoladze killed!");
            PrintRoom(room);
        }
    }

    private static void CheckIfEnemyKillsSam(char[][] room, int samRow, int samCol)
    {
        for (int col = 0; col < samCol; col++)
        {
            if (room[samRow][col] == 'b')
            {
                room[samRow][samCol] = 'X';
                Console.WriteLine($"Sam died at {samRow}, {samCol}");
                PrintRoom(room);
            }
        }
        for (int col = samCol + 1; col < room[samRow].Length; col++)
        {
            if (room[samRow][col] == 'd')
            {
                Console.WriteLine($"Sam died at {samRow}, {samCol}");
                PrintRoom(room);
            }
        }
    }

    private static void PrintRoom(char[][] room)
    {
        for (int row = 0; row < room.GetLength(0); row++)
        {
            Console.WriteLine(string.Join("", room[row]));
        }
        Environment.Exit(0);
    }

    private static int[] SearchForSam(char[][] room)
    {
        int[] samPosition = new int[2];
        bool isFound = false;
        for (int row = 0; row < room.GetLength(0); row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'S')
                {
                    samPosition[0] = row;
                    samPosition[1] = col;
                    isFound = true;
                    break;
                }
            }
            if (isFound)
            {
                break;
            }
        }
        return samPosition;
    }

    private static void EnemyMoves(char[][] room, SortedList<int, int> notMovingEnemies)
    {
        for (int row = 0; row < room.GetLength(0); row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'N')
                {
                    break;
                }

                if (room[row][col] == 'd')
                {
                    if (col != 0 && !notMovingEnemies.Any(x => x.Key == row && x.Value == col))
                    {
                        room[row][col] = '.';
                        room[row][col - 1] = 'd';
                    }
                    else if (col == 0)
                    {
                        room[row][col] = 'b';
                        notMovingEnemies.Add(row, col);
                    }
                    break; 
                }

                if (room[row][col] == 'b')
                {
                    if (col != room[row].Length - 1 && !notMovingEnemies.Any(x => x.Key == row && x.Value == col))
                    {
                        room[row][col] = '.';
                        room[row][col + 1] = 'b';
                    }
                    if (col == room[row].Length - 1)
                    {
                        room[row][col] = 'd';
                        notMovingEnemies.Add(row, col);
                    }
                    break;
                }
            }
        }
    }
}

using System;
using System.Linq;

class DangerousFloor
{
    static void Main()
    {
        char[][] board = new char[8][];

        for (int row = 0; row < 8; row++)
        {
            board[row] = new char[8];
            board[row] = Console.ReadLine().Split(',')
                .Select(char.Parse).ToArray();
        }

        var command = string.Empty;
        while ((command = Console.ReadLine()) != "END")
        {
            var symbol = command.ElementAt(0);
            int currentRow = int.Parse(command[1].ToString());
            int currentCol = int.Parse(command[2].ToString());
            int finalRow = int.Parse(command[4].ToString());
            int finalCol = int.Parse(command[5].ToString());

            if (ExistingPieceCheck(board, symbol, currentRow, currentCol, finalRow, finalCol))
            {
                if (InvalidMoveCheck(board, symbol, currentRow, currentCol, finalRow, finalCol))
                {
                    if (MoveOutOfBoardCheck(board, symbol, currentRow, currentCol, finalRow, finalCol))
                    {
                        board[finalRow][finalCol] = symbol;
                        board[currentRow][currentCol] = 'x';
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Move go out of board!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }
        }
    }

    private static bool MoveOutOfBoardCheck(char[][] board, char symbol, int currentRow, int currentCol, int finalRow, int finalCol)
    {
        if (finalRow < 0 || finalRow >= 8 || finalCol < 0 || finalCol >= 8)
            return false;
        else
            return true;
    }

    private static bool InvalidMoveCheck(char[][] board, char symbol, int currentRow, int currentCol, int finalRow, int finalCol)
    {
        bool isValidMove = false;
        switch (symbol)
        {
            case 'K':
                if ((finalRow == currentRow - 1 && finalCol == currentCol - 1)
                    || (finalRow == currentRow - 1 && finalCol == currentCol)
                    || (finalRow == currentRow - 1 && finalCol == currentCol + 1)
                    || (finalRow == currentRow && finalCol == currentCol - 1)
                    || (finalRow == currentRow && finalCol == currentCol + 1)
                    || (finalRow == currentRow + 1 && finalCol == currentCol - 1)
                    || (finalRow == currentRow + 1 && finalCol == currentCol)
                    || (finalRow == currentRow + 1 && finalCol == currentCol + 1))
                    isValidMove = true;
                break;
            case 'R':
                if (finalRow == currentRow || finalCol == currentCol)
                    isValidMove = true;
                break;
            case 'B':
                if (Math.Abs(finalRow - currentRow) == Math.Abs(finalCol - currentCol))
                    isValidMove = true;
                break;
            case 'Q':
                if (Math.Abs(finalRow - currentRow) == Math.Abs(finalCol - currentCol) 
                    || finalRow == currentRow || finalCol == currentCol)
                    isValidMove = true;
                break;
            case 'P':
                if (finalRow == currentRow - 1 && finalCol == currentCol)
                    isValidMove = true;
                break;
            default:
                break;
        }
        return isValidMove;
    }

    private static bool ExistingPieceCheck(char[][] board, char symbol, int currentRow, int currentCol, int finalRow, int finalCol)
    {
        return board[currentRow][currentCol] == symbol;
    }
}

using System;
using System.Linq;
using System.Text;

class TargetPractice
{
    static void Main()
    {
        var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rows = dimensions[0];
        int columns = dimensions[1];

        string snake = Console.ReadLine();
        int snakeMove = 0;

        var parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int blackCellRow = parameters[0];
        int blackCellColumn = parameters[1];
        int radius = parameters[2];

        var stairs = new char[rows, columns];

        bool backwardsDirection = true;

        for (int row = rows - 1; row >= 0; row--)
        {
            if (backwardsDirection == true)
            {
                for (int column = columns - 1; column >= 0; column--)
                {
                    stairs[row, column] = snake[snakeMove];
                    if (snakeMove < snake.Length - 1)
                    {
                        snakeMove++;
                    }
                    else
                    {
                        snakeMove = 0;
                    }
                }
                backwardsDirection = false;
            }
            else
            {
                for (int column = 0; column < columns; column++)
                {
                    stairs[row, column] = snake[snakeMove];
                    if (snakeMove < snake.Length - 1)
                    {
                        snakeMove++;
                    }
                    else
                    {
                        snakeMove = 0;
                    }
                }
                backwardsDirection = true;
            }
        }

        int currentRow;
        int currentColumn;

        for (int i = 0; i < radius; i++)
        {
            currentRow = blackCellRow - radius + i;

            if (currentRow < 0)
            {
                continue;
            }

            currentColumn = 0;
            currentColumn = blackCellColumn - radius + i;

            for (int j = currentColumn;  j <= currentColumn + 1; j++)
            {
                if (j < 0 || j > columns - 1)
                {
                    continue;
                }

                stairs[currentRow, j] = ' ';
            }
        }

        currentRow = blackCellRow;

        for (int i = radius; i >= 0; i--)
        {
            if (currentRow > rows - 1)
            {
                continue;
            }

            for (int j = blackCellColumn - i; j <= blackCellColumn + i; j++)
            {
                if (j < 0 || j > columns - 1)
                {
                    continue;
                }

                stairs[currentRow, j] = ' ';
            }
            currentRow++;
        }

        // All characters are falling down
        for (int column = 0; column < stairs.GetLength(1); column++)
        {
            int bottomSpaceIndex = 0;
            bool spacesFound = false;
            int spaceCounter = 0;

            for (int row = stairs.GetLength(0) - 1; row >= 0; row--)
            {
                if (stairs[row, column] == ' ' && spacesFound == false)
                {
                    bottomSpaceIndex = row;
                    spacesFound = true;
                }
                if (stairs[row, column] == ' ')
                {
                    spaceCounter++;
                }
            }

            if (spaceCounter == 0)
            {
                continue;
            }


            while (stairs[0, column] != ' ')
            {
                int newSpaceIndex = bottomSpaceIndex - spaceCounter;

                stairs[bottomSpaceIndex, column] = stairs[newSpaceIndex, column];
                stairs[newSpaceIndex, column] = ' ';

                bottomSpaceIndex--;
            }
        }

        // Printing the result
        for (int row = 0; row < rows; row++)
        {
            StringBuilder finalRow = new StringBuilder();
            for (int column = 0; column < columns; column++)
            {
                finalRow.Append(stairs[row, column]);
            }
            Console.WriteLine(finalRow);
        }
    }
}

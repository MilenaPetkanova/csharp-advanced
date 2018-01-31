using System;
using System.Collections.Generic;
using System.Linq;

class GroupNumbers
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse).ToArray();

        // Solution with nested Lists 

        //var remainders = new List<List<int>>();

        //for (int i = 0; i < 3; i++)
        //{
        //    remainders.Add(new List<int>());
        //}

        //for (int i = 0; i < numbers.Length; i++)
        //{
        //    int reminder = Math.Abs(numbers[i] % 3);
        //    remainders[reminder].Add(numbers[i]);
        //}

        var reminders = new int[3][];

        var columnCounter = new int[3];

        foreach (var number in numbers)
        {
            int reminder = Math.Abs(number % 3);
            columnCounter[reminder]++;
        }

        for (int i = 0; i < columnCounter.Length; i++)
        {
            reminders[i] = new int[columnCounter[i]];
        }

        int zeroReminders = 0;
        int oneReminders = 0;
        int twoReminders = 0;

        foreach (var number in numbers)
        {
            int reminder = Math.Abs(number % 3);
            if (reminder == 0)
            {
                reminders[0][zeroReminders] = number;
                zeroReminders++;
            }
            else if (reminder == 1)
            {
                reminders[1][oneReminders] = number;
                oneReminders++;
            }
            else if (reminder == 2)
            {
                reminders[2][twoReminders] = number;
                twoReminders++;
            }
        }

        PrintMatrix(reminders);
    }

    private static void PrintMatrix(int[][] reminders)
    {
        for (int row = 0; row < reminders.GetLength(0); row++)
        {
            Console.WriteLine(String.Join(" ", reminders[row]));
        }
    }
}

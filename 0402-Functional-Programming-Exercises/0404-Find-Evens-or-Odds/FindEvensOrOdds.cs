using System;
using System.Linq;

class FindEvensOrOdds
{
    static void Main()
    {
        Predicate<int> oddFinder = delegate (int x) { return x % 2 == 1 || x % 2 == -1; };

        Func<string, int[]> parseString = x =>
                x.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

        var range = parseString(Console.ReadLine());
        int downRange = range[0];
        int upperRange = range[1];

        string command = Console.ReadLine();

        for (int i = 0; i <= upperRange - downRange; i++)
        {
            int currentNum = downRange + i;

            switch (command)
            {
                case "odd":
                    if (oddFinder(currentNum))
                        Console.Write($"{currentNum} ");
                    break;
                case "even":
                    if (!oddFinder(currentNum))
                        Console.Write($"{currentNum} ");
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine();
    }
}

using System;
using System.Linq;

class FindEvensOrOdds
{
    static void Main()
    {
        Predicate<int> oddFinder = delegate (int x) { return x % 2 == 1; };
        Predicate<string> oddQuery = delegate (string x) { return x == "odd"; };

        Func<string, int[]> parseString = x => 
                x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

        var range = parseString(Console.ReadLine());
        int downRange = range[0];
        int upperRange = range[1];

        string command = Console.ReadLine();

        for (int i = 0; i <= upperRange - downRange; i++)
        {
            int currentNum = downRange + i;

            if (oddQuery(command) == true && oddFinder(currentNum) == true)
                Console.Write($"{currentNum} ");

            else if (oddQuery(command) == false && oddFinder(currentNum) == false)
                Console.Write($"{currentNum} ");
                    }
        Console.WriteLine();
    }
}

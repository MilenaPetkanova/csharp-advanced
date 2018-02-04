using System;
using System.Collections.Generic;
using System.Linq;

class ListOfPredicates
{
    static void Main()
    {
        int upperRange = int.Parse(Console.ReadLine());

        var dividers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();

        var result = new List<int>();

        Func<int, int, bool> isDivisibleFunc = (x, y) => x % y == 0;

        for (int number = 1; number <= upperRange; number++)
        {
            bool isDivisible = true;
            foreach (int diviser in dividers)
            {
                if (!isDivisibleFunc(number, diviser))
                {
                    isDivisible = false;
                    break;
                }
            }

            if (isDivisible)
            {
                result.Add(number);
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }
}

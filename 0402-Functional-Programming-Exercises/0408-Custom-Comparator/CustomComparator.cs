using System;
using System.Linq;

class CustomComparator
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse).ToArray();

        Func<long, bool> isEven = x => x % 2 == 1 || x % 2 == -1;
        Func<long, bool> isOdd = x => x % 2 == 0;

        Array.Sort(numbers);

        var oddNumbers = numbers.Where(x => isOdd(x) == true).ToList();
        var evenNumbers = numbers.Where(x => isEven(x) == true).ToList();

        oddNumbers.ForEach(x => Console.Write($"{x} "));
        evenNumbers.ForEach(x => Console.Write($"{x} "));
    }
}

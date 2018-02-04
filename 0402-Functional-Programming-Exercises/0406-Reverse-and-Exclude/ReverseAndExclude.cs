using System;
using System.Linq;

class ReverseAndExclude
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int n = int.Parse(Console.ReadLine());

        Array.Reverse(numbers);

        Func<int, bool> notDivisibleByN = x => x % n != 0;

        numbers = numbers.Where(notDivisibleByN).ToArray();

        foreach (var number in numbers)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();
    }
}

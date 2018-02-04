using System;
using System.Linq;

class SumNumbers
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        Console.WriteLine(numbers.Count());
        Console.WriteLine(numbers.Sum());
    }
}

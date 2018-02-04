using System;
using System.Linq;

class SortEvenNumbers
{
    static void Main()
    {
        Func<string, int> parser = int.Parse;

        var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(parser)
            .Where(x => x % 2 == 0)
            .OrderBy(x => x);

        Console.WriteLine(string.Join(", ", numbers));
    }
}

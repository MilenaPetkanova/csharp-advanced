using System;
using System.Linq;

class PredicateForNames
{
    static void Main()
    {
        int maxLength = int.Parse(Console.ReadLine());

        var names = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Func<string, bool> lesOrEqual = x => x.Length <= maxLength;

        names.Where(lesOrEqual)
            .ToList()
            .ForEach(x => Console.WriteLine(x));

    }
}

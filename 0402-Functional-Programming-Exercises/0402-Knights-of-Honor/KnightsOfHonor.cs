using System;

class KnightsOfHonor
{
    static void Main()
    {
        Action<string> printOutputLine = x => Console.WriteLine($"Sir {x}");

        var names = Console.ReadLine().Split(' ');

        foreach (var name in names)
        {
            printOutputLine(name);
        }
    }
}

using System;

class ActionPoint
{
    static void Main()
    {
        Action<string> printString = x => Console.WriteLine(x);

        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var element in input)
        {
            printString(element);
        }
    }
}

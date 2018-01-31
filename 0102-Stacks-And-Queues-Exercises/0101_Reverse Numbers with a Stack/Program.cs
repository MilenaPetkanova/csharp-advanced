using System;
using System.Collections.Generic;

class ReverseNumbersStack
{
    static void Main()
    {
        var reversedNums = new Stack<string>(Console.ReadLine().Split());
        Console.WriteLine(string.Join(" ", reversedNums));
    }
}

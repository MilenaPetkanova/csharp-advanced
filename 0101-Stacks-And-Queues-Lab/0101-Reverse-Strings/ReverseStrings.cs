using System;
using System.Collections.Generic;

class ReverseStrings
{
    static void Main()
    {
        var input = Console.ReadLine();
        var stack = new Stack<char>();
        foreach (var ch in input)
        {
            stack.Push(ch);
        }
        while (stack.Count != 0)
        {
            Console.Write(stack.Pop());
        }
        Console.WriteLine();

        // Another, better solution:
        var reversedInput = new Stack<char>(Console.ReadLine());
        Console.WriteLine(string.Join("", reversedInput));
    }
}

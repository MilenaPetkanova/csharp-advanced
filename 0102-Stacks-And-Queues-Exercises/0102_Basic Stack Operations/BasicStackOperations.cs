using System;
using System.Collections.Generic;
using System.Linq;

class BasicStackOperations
{
    static void Main()
    {
        var options = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var n = options[0];
        var s = options[1];
        var x = options[2];

        var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            stack.Push(input[i]);
        }
        for (int i = 0; i < s; i++)
        {
            stack.Pop();
        }

        if (stack.Count != 0)
        {
            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
        else
        {
            Console.WriteLine(stack.Count);
        }
    }
}

using System;
using System.Collections.Generic;

class StackFibonacci
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());

        var stack = new Stack<long>();
        stack.Push(0);
        stack.Push(1);

        long firstNum = 0;
        long secondNum = 0;

        for (int i = 2; i <= num; i++)
        {
            firstNum = stack.Peek();
            secondNum = stack.Pop() + stack.Pop();
            stack.Push(firstNum);
            stack.Push(secondNum);
        }

        Console.WriteLine(stack.Peek());
    }
}

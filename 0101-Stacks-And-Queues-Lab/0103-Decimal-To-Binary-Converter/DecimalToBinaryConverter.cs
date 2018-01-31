using System;
using System.Collections.Generic;

class DecimalToBinaryConverter
{
    static void Main()
    {
        int decimalValue = int.Parse(Console.ReadLine());

        var stack = new Stack<int>();

        if (decimalValue == 0)
        {
            Console.WriteLine("0");
            return;
        }

        while (decimalValue > 0)
        {
            stack.Push(decimalValue % 2);
            decimalValue /= 2;
        }

        while (stack.Count > 0)
        {
            Console.Write(stack.Pop());
        }
        Console.WriteLine();

    }
}

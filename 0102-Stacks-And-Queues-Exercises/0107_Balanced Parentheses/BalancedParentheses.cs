using System;
using System.Collections.Generic;

class BalancedParentheses
{
    static void Main()
    {
        var stack = new Stack<char>();

        var input = Console.ReadLine();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(' || input[i] == '[' || input[i] == '{')
            {
                stack.Push(input[i]);
            }
            else if (input[i] == ')')
            {
                if (stack.Count == 0 || stack.Pop() != '(')
                {
                    NotBalanced();
                }
            }
            else if (input[i] == ']')
            {
                if (stack.Count == 0 || stack.Pop() != '[')
                {
                    NotBalanced();
                }
            }
            else if (input[i] == '}')
            {
                if (stack.Count == 0 || stack.Pop() != '{')
                {
                    NotBalanced();
                }
            }
        }
        Console.WriteLine("YES");
    }

    static void NotBalanced()
    {
        Console.WriteLine("NO");
        Environment.Exit(0);
    } 
}

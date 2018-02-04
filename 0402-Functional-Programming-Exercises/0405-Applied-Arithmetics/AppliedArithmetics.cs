using System;
using System.Collections.Generic;
using System.Linq;

class AppliedArithmetics
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        
        Func<int[], int[]> add = x => { return x.Select(n => n + 1).ToArray(); };
        Func<int[], int[]> multiply = x => { return x.Select(n => n * 2).ToArray(); };
        Func<int[], int[]> subtract = x => { return x.Select(n => n - 1).ToArray(); };
        Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

        string command = String.Empty;

        while ((command = Console.ReadLine()) != "end")
        {
            switch (command)
            {
                case "add":
                    numbers = add(numbers);
                    break;
                case "multiply":
                    numbers = multiply(numbers);
                    break;
                case "subtract":
                    numbers = subtract(numbers);
                    break;
                case "print":
                    print(numbers);
                    break;
                default:
                    break;
            }
        }
    }
}

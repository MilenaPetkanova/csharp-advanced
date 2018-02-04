using System;
using System.Linq;

class CustomMinFunction
{
    static void Main()
    {
        Func<string, int> findMin = x => 
            x.Split(' ').Select(int.Parse).ToArray().Min();

        var minNumber = findMin(Console.ReadLine());

        Console.WriteLine(minNumber);
    }
}

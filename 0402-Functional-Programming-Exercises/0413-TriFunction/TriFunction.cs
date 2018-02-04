using System;
using System.Linq;

class TriFunction
{
    static void Main()
    {
        int comparer = int.Parse(Console.ReadLine());
         
        var names = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        Func<string, int, bool> isEqualOrLarger = (s, n) => s.Select(x => (int)x).Sum() >= n;

        //Another option:
        //Func<string, int, bool> isEqualOrLarger = (s, n) => s.ToCharArray().Sum(c => c) >= n;


        Console.WriteLine(names.Find(s => isEqualOrLarger(s, comparer)));
    }
}

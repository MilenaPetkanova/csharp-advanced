using System;
using System.Linq;

class CountUppercaseWords
{
    static void Main()
    {
        Func<string, bool> checker = s => char.IsUpper(s[0]);

        var words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(checker)
            .ToList();

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}

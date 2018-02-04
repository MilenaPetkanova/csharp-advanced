using System;
using System.Linq;

class AddVAT
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => double.Parse(x, System.Globalization.CultureInfo.InstalledUICulture))
            .Select(x => x * 1.2)
            .ToList();

        foreach (var number in numbers)
        {
            Console.WriteLine($"{number:f2}");
        }
    }
}

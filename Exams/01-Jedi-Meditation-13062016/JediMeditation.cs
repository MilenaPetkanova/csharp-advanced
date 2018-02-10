using System;
using System.Collections.Generic;
using System.Linq;

class JediMeditation
{
    static void Main()
    {
        var jedies = new List<string>();
        var result = new List<string>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var newLine = Console.ReadLine().Split(new[] { ' ' } , StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var jedi in newLine)
            {
                jedies.Add(jedi);
            }
        }

        if (jedies.Any(x => x[0] == 'y'))
        {
            foreach (var jedi in jedies.Where(x => x[0] == 'm'))
            {
                result.Add(jedi);
            }
            foreach (var jedi in jedies.Where(x => x[0] == 'k'))
            {
                result.Add(jedi);
            }
            foreach (var jedi in jedies.Where(x => x[0] == 't' || x[0] == 's'))
            {
                result.Add(jedi);
            }
            foreach (var jedi in jedies.Where(x => x[0] == 'p'))
            {
                result.Add(jedi);
            }
        }
        else
        {
            foreach (var jedi in jedies.Where(x => x[0] == 't' || x[0] == 's'))
            {
                result.Add(jedi);
            }
            foreach (var jedi in jedies.Where(x => x[0] == 'm'))
            {
                result.Add(jedi);
            }
            foreach (var jedi in jedies.Where(x => x[0] == 'k'))
            {
                result.Add(jedi);
            }
            foreach (var jedi in jedies.Where(x => x[0] == 'p'))
            {
                result.Add(jedi);
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }
}

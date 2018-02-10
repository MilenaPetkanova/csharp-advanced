using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// 80/100

class JediDreams
{
    static void Main()
    {
        var methods = new SortedDictionary<string, List<string>>();
        string method = null;

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Trim();

            if (Regex.IsMatch(line, @"static\s+.*?\s+([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\("))
            {
                var match = Regex.Match(line, @"static\s+.*?\s+([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(");
                method = match.Groups[1].ToString();

                if (!methods.ContainsKey(method))
                {
                    methods.Add(method, new List<string>());
                }
            }

            else
            {
                var matches = Regex.Matches(line, @"([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(");

                if (matches.Count == 0)
                    continue;

                foreach (Match match in matches)
                {
                    var call = match.Groups[1].ToString();
                    methods[method].Add(call);
                }
            }
        }

        foreach (var methodCalls in methods.OrderByDescending(x => x.Value.Count))
        {
            int callsCount = methodCalls.Value.Count();

            if (callsCount != 0)
            {
                Console.Write($"{methodCalls.Key} -> {callsCount} -> ");

                methods[methodCalls.Key].Sort();

                Console.Write(string.Join(", ", methodCalls.Value));
                Console.WriteLine();
            }
            else
            {
                Console.Write($"{methodCalls.Key} -> None");
            }
        }
    }
}

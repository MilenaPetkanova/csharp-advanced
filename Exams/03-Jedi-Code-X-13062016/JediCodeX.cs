using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

// 20/100

class JediCodeX
{
    static void Main()
    {
        var jediesMessages = new Dictionary<string, string>();

        string input = null;

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            input += Console.ReadLine() + " ";
        }

        var firstPattern = Console.ReadLine();
        int firstPatternLength = firstPattern.Length;
        var secondPattern = Console.ReadLine();
        int secondPatternLength = secondPattern.Length;

        var messIndexes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        string namesPatern = $@"{firstPattern}(?<name>[a-zA-Z]{{{firstPatternLength}}})(?![a-zA-Z])";
        string messagesPatern = $@"{secondPattern}(?<message>[a-zA-Z0-9]{{{secondPatternLength}}})(?![a-zA-Z0-9])";
        var nameMatches = Regex.Matches(input, namesPatern);
        var messagesMatches = Regex.Matches(input, messagesPatern);
        var names = new List<string>();
        var messages = new List<string>();
        foreach (Match match in nameMatches)
        {
            names.Add(match.Groups["name"].ToString());
        }
        foreach (Match match in messagesMatches)
        {
            messages.Add(match.Groups["message"].ToString());
        }

        int length = Math.Max(names.Count, messages.Count);

        for (int i = 0; i < length; i++)
        {
            int currentIndex = messIndexes[i] - 1;

            if (currentIndex < 0 || currentIndex > messages.Count - 1)
            {
                currentIndex = messIndexes[i + 1] - 1;

                if (currentIndex < 0 || currentIndex > messages.Count - 1)
                {
                    jediesMessages.Add(names[i], "no message");
                }
            }
            else
            {
                if (currentIndex > names.Count - 1)
                {
                    continue;
                }
                jediesMessages.Add(names[currentIndex], messages[currentIndex]);
            }
        }

        if (names.Count > messages.Count)
        {
            for (int i = messages.Count; i < names.Count; i++)
            {
                jediesMessages.Add(names[i], messages[messages.Count - 1]);
            }
        }

        foreach (var jedi in jediesMessages)
        {
            Console.WriteLine($"{jedi.Key} - {jedi.Value}");
        }
    }
}

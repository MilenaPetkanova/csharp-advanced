using System;
using System.Text.RegularExpressions;

class TreasureMap
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();

            string pattern = @"(#|!)[^#!]*?(?<![a-zA-Z0-9])(?<strName>([a-zA-Z]){4})(?![a-zA-Z0-9])[^#!]*" + 
                @"(?<!\d)(?<strNumber>(\d{3}))-(?<pass>(\d{4}|\d{6}))(?!\d)[^#!]*?(#|!)";

            var matches = Regex.Matches(input, pattern);

            var correctMatch = matches[matches.Count / 2];

            Console.WriteLine($"Go to str. {correctMatch.Groups["strName"]} {correctMatch.Groups["strNumber"]}. " +
                $"Secret pass: {correctMatch.Groups["pass"]}.");
        }
    }
}

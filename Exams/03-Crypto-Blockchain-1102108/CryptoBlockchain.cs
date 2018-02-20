using System;
using System.Linq;
using System.Text.RegularExpressions;

class CryptoBlockchain.cs
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string input = null;
        string output = null;

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            input += line;
        }
        
        string pattern = @"(?:(?<bracket>{)|\[)[^0-9]*(?<digits>\d*)[^0-9]*(?(bracket)}|\])";

        var matches = Regex.Matches(input, pattern);

        foreach (Match match in matches)
        {
            string digits = match.Groups["digits"].Value;

            if (digits.Length % 3 != 0)
            {
                continue;
            }

            for (int i = 0; i < digits.Length; i += 3)
            {
                int number = int.Parse(digits.ElementAt(i).ToString() + digits.ElementAt(i + 1).ToString() + digits.ElementAt(i + 2).ToString());
                number -= match.Length;
                char ascciValue = Convert.ToChar(number);
                output += ascciValue;
            }
        }

        Console.WriteLine(output);
    }
}
 
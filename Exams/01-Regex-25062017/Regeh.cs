using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Regeh
{
    static void Main()
    {
        var input = Console.ReadLine();

        var pattern = @"\[[^\s\[\]]+<([\d]+)REGEH([0-9]+)>[^\s\[\]]+\]";
        var matches = Regex.Matches(input, pattern);

        int sum = 0;

        var sb = new StringBuilder();

        foreach (Match match in matches)
        {
            var firstNum = int.Parse(match.Groups[1].Value);
            sum += firstNum;
            sb.Append(input[sum % (input.Length - 1)]);

            var secondNum = int.Parse(match.Groups[2].Value);
            sum += secondNum;
            sb.Append(input[sum % (input.Length - 1)]);
        }

        Console.WriteLine(sb.ToString());
    }
}

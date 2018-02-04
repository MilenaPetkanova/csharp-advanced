using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Demo
{
    static void Main()
    {
        Action<string> printLine = text => Console.WriteLine(text);

        Func<string> readLine = () => Console.ReadLine();

        var input = readLine();
        printLine(input);

        Func<string> readLineAsBlock = () =>
        {
            if (DateTime.Now.Day < 12)
                return Console.ReadLine();
            else
                return "after 12";
        };
        var secondInput = readLineAsBlock();
        printLine(readLineAsBlock());
    }

    // Notes:
    // Lambda expression => means goes to

}

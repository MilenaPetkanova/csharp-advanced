using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class SimpleTextEditor
{
    static void Main()
    {
        var text = new StringBuilder();
        var undoText = new Stack<string>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            var line = Console.ReadLine().Split(' ').ToArray();
            var commandName = line[0];
            switch (commandName)
            {
                case "1":
                    undoText.Push(text.ToString());
                    var argument1 = line[1];
                    text.Append(argument1);
                    break;
                case "2":
                    undoText.Push(text.ToString());
                    var argument2 = int.Parse(line[1]);
                    text.Remove(text.Length - argument2, argument2);
                    break;
                case "3":
                    var argument3 = int.Parse(line[1]);
                    Console.WriteLine(text[argument3 - 1]);
                    break;
                case "4":
                    text.Clear();
                    text.Append(undoText.Pop());
                    break;
                default:
                    Console.WriteLine();
                    break;
            }

        }
    }
}

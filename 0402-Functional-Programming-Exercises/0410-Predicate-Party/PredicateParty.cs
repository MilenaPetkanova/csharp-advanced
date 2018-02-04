using System;
using System.Collections.Generic;
using System.Linq;

class PredicateParty
{
    static void Main()
    {
        Func<List<string>> readAndSplit = () => 
            Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var guestList = readAndSplit();

        var commandLine = readAndSplit();

        while (commandLine[0] != "Party!")
        {
            var removeOrDouble = commandLine[0];
            var criteria = commandLine[1];
            var argument = commandLine[2];

            switch (criteria)
            {
                case "StartsWith":
                    ProcessCommand(guestList, removeOrDouble, x => x.StartsWith(argument));
                    break;
                case "EndsWith":
                    ProcessCommand(guestList, removeOrDouble, x => x.EndsWith(argument));
                    break;
                case "Length":
                    int lengthCriteria = int.Parse(argument);
                    ProcessCommand(guestList, removeOrDouble, x => x.Length == lengthCriteria);
                    break;
                default:
                    break;
            }
            
            commandLine = readAndSplit();
        }

        if (guestList.Count == 0)
        {
            Console.WriteLine("Nobody is going to the party!");
            return;
        }

        Console.WriteLine(string.Join(", ", guestList) + " are going to the party!");
    }

    private static void ProcessCommand(List<string> guestList, string removeOrDouble, Func<string, bool> hasCriteria)
    {
        for (int i = guestList.Count - 1; i >= 0; i--)
        {
            if (hasCriteria(guestList[i]))
            {
                switch (removeOrDouble)
                {
                    case "Remove":
                        guestList.Remove(guestList[i]);
                        break;
                    case "Double":
                        guestList.Add(guestList[i]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

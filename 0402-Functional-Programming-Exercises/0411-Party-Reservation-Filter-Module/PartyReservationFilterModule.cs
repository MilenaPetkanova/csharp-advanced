using System;
using System.Collections.Generic;
using System.Linq;

class PartyReservationFilterModule
{
    static void Main()
    {
        var invitations = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var filterList = new List<KeyValuePair<string, string>>();

        var line = Console.ReadLine();
        while (line != "Print")
        {
            var commandLine = line.Split(';').ToList();
            var command = commandLine[0];
            var filterType = commandLine[1];
            var filterParameter = commandLine[2];

            UpdateFilterList(command, filterList, filterType, filterParameter);

            line = Console.ReadLine();
        }

        FilterInvitationList(invitations, filterList);

        Console.WriteLine(string.Join(" ", invitations));
    }

    private static void UpdateFilterList(string command, List<KeyValuePair<string, string>> functionList, string filterType, string filterParameter)
    {
        switch (command)
        {
            case "Add filter":
                functionList.Add(new KeyValuePair<string, string>(filterType, filterParameter));
                break;
            case "Remove filter":
                functionList.RemoveAll(x => x.Key.Equals(filterType) && x.Value.Equals(filterParameter));
                break;
            default:
                break;
        }
    }

    private static void FilterInvitationList(List<string> invitations, List<KeyValuePair<string, string>> filterList)
    {
        for (int i = invitations.Count - 1; i >= 0; i--)
        {
            string guest = invitations[i];

            foreach (var filter in filterList)
            {
                switch (filter.Key)
                {
                    case "Starts with":
                        if (guest.StartsWith(filter.Value))
                            invitations.Remove(guest);
                        break;
                    case "Ends with":
                        if (guest.EndsWith(filter.Value))
                            invitations.Remove(guest);
                        break;
                    case "Length":
                        if (guest.Length == int.Parse(filter.Value))
                            invitations.Remove(guest);
                        break;
                    case "Contains":
                        if (guest.Contains(filter.Value))
                            invitations.Remove(guest);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}


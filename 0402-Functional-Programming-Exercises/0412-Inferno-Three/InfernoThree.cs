using System;
using System.Collections.Generic;
using System.Linq;

class InfernoThree
{
    static void Main()
    {
        var gems = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var exclusionsList = new List<KeyValuePair<string, int>>();

        var commandLine = Console.ReadLine();
        while (commandLine != "Forge")
        {
            UpdateExclusionList(commandLine, exclusionsList);

            commandLine = Console.ReadLine();
        }

        var indexesToExclude = new SortedSet<int>();

        foreach (var exclusion in exclusionsList)
        {
            string filterType = exclusion.Key;
            int filterParameter = exclusion.Value;
            switch (filterType)
            {
                case "Sum Left":
                    FindExclusionsLeft(gems, filterParameter, indexesToExclude);
                    break;
                case "Sum Right":
                    FindExclusionsRight(gems, filterParameter, indexesToExclude);
                    break;
                case "Sum Left Right":
                    FindExclusionsLeft(gems, filterParameter, indexesToExclude);
                    FindExclusionsRight(gems, filterParameter, indexesToExclude);

                    //FindExclusionsLeftRight(gems, filterParameter, indexesToExclude);
                    break;
                default:
                    break;
            }
        }

        ExcludeGems(gems, indexesToExclude);

        Console.WriteLine(string.Join(" ", gems));
    }

    private static void ExcludeGems(List<int> gems, SortedSet<int> indexesToExclude)
    {
        for (int i = gems.Count - 1; i >= 0; i--)
        {
            if (indexesToExclude.Contains(i))
            {
                gems.RemoveAt(i);
            }
        }
    }

    private static void FindExclusionsLeft(List<int> gems, int filterParameter, SortedSet<int> indexesToExclude)
    {
        if (filterParameter == 0)
        {
            indexesToExclude.Add(0);
        }
        else
        {
            for (int index = gems.Count - 1; index >= 1; index--)
            {
                int sumLeft = 0;
                for (int i = index - 1; i >= 0; i--)
                {
                    sumLeft += gems[i];

                    if (sumLeft > filterParameter)
                        break;
                    if (sumLeft == filterParameter)
                        indexesToExclude.Add(index);
                }
            }
        }
    }
    private static void FindExclusionsRight(List<int> gems, int filterParameter, SortedSet<int> indexesToExclude)
    {
        if (filterParameter == 0)
        {
            indexesToExclude.Add(gems.Count - 1);
        }
        else
        {
            for (int index = 0; index < gems.Count - 1; index++)
            {
                int sumRight = 0;
                for (int j = index + 1; j < gems.Count; j++)
                {
                    sumRight += gems[j];

                    if (sumRight > filterParameter)
                        break;
                    if (sumRight == filterParameter)
                        indexesToExclude.Add(index);
                }
            }
        }
    }

    private static void FindExclusionsLeftRight(List<int> gems, int filterParameter, SortedSet<int> indexesToExclude)
    {

    }

    private static void UpdateExclusionList(string inputLine, List<KeyValuePair<string, int>> exclusionsList)
    {
        var commandLine = inputLine.Split(';').ToArray();
        var command = commandLine[0];
        var filterType = commandLine[1];
        var filterParameter = int.Parse(commandLine[2]);

        switch (command)
        {
            case "Exclude":
                exclusionsList.Add(new KeyValuePair<string, int>(filterType, filterParameter));
                break;
            case "Reverse":
                exclusionsList.Remove(exclusionsList.Last(x => x.Key.Equals(filterType) && x.Value.Equals(filterParameter)));
                break;
            default:
                break;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

class HitList
{
    static void Main()
    {
        var hitList = new Dictionary<string, SortedDictionary<string, string>>();

        int targetInfo = int.Parse(Console.ReadLine());

        string line = null;
        while ((line = Console.ReadLine()) != "end transmissions")
        {
            var args = line.Split(new[] { '=', ':', ';' }).ToArray();

            var name = args[0];
            if (!hitList.ContainsKey(name))
            {
                hitList.Add(name, new SortedDictionary<string, string>());
            }

            for (int i = 1; i < args.Length - 1; i += 2)
            {
                var key = args[i];
                var value = args[i + 1];

                if (!hitList[name].ContainsKey(key))
                {
                    hitList[name].Add(key, value);
                }
                else
                {
                    hitList[name][key] = value;
                }
            }
        }

        var command = Console.ReadLine().Split(' ').ToArray();
        var killCommand = command[1];

        int indexInfo = 0;

        Console.WriteLine($"Info on {killCommand}:");

        foreach (var item in hitList[killCommand])
        {
            Console.WriteLine($"---{item.Key}: {item.Value}");
            indexInfo += item.Key.Length + item.Value.Length;
        }

        Console.WriteLine($"Info index: {indexInfo}");

        if (indexInfo >= targetInfo)
        {
            Console.WriteLine("Proceed");
        }
        else
        {
            Console.WriteLine("Need {0} more info.", targetInfo - indexInfo);
        }
    }
}

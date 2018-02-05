using System;
using System.Collections.Generic;
using System.Linq;

class GreedyTimes
{
    static void Main()
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        long bagAmount = 0;

        var items = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        var bag = new Dictionary<string, Dictionary<string, long>>(StringComparer.OrdinalIgnoreCase);

        var totalAmountByType = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
        totalAmountByType.Add("Gold", 0);
        totalAmountByType.Add("Gem", 0);
        totalAmountByType.Add("Cash", 0);

        Func<Dictionary<string, long>, bool> firstRule = x => x["Gold"] >= x["Gem"] && x["Gem"] >= x["Cash"];
        
Func<long, long, long, bool> capacityRule = (x, y, z) => x >= y + z;

        for (int i = 0; i < items.Length; i+=2)
        {
            var item = items[i];
            var quantity = long.Parse(items[i + 1]);

            if (capacityRule(bagCapacity, bagAmount, quantity) == false)
            {
                continue;
            }

            if (item.ToLower() == "Gold".ToLower())
            {
                totalAmountByType["Gold"] += quantity;
                if (firstRule(totalAmountByType) == false)
                {
                    totalAmountByType["Gold"] -= quantity;
                    continue;
                }
                
                if (!bag.ContainsKey("Gold"))
                {
                    bag.Add("Gold", new Dictionary<string, long>());
                    bag["Gold"].Add(item, quantity);
                }
                else
                {
                    if (!bag["Gold"].ContainsKey(item))
                    {
                        bag["Gold"].Add(item, quantity);
                    }
                    else
                    {
                        bag["Gold"][item] += quantity;
                    }
                }
            }

            else if (item.ToLower().EndsWith("Gem".ToLower()))
            {
                totalAmountByType["Gem"] += quantity;
                if (firstRule(totalAmountByType) == false)
                {
                    totalAmountByType["Gem"] -= quantity;
                    continue;
                }

                if (!bag.ContainsKey("Gem"))
                {
                    bag.Add("Gem", new Dictionary<string, long>());
                    bag["Gem"].Add(item, quantity);
                }
                else
                {
                    if (!bag["Gem"].ContainsKey(item))
                    {
                        bag["Gem"].Add(item, quantity);
                    }
                    else
                    {
                        bag["Gem"][item] += quantity;
                    }
                }
            }

            else if (item.Length == 3 && item.All(Char.IsLetter))
            {
                totalAmountByType["Cash"] += quantity;
                if (firstRule(totalAmountByType) == false)
                {
                    totalAmountByType["Cash"] -= quantity;
                    continue;
                }

                if (!bag.ContainsKey("Cash"))
                {
                    bag.Add("Cash", new Dictionary<string, long>());
                    bag["Cash"].Add(item, quantity);
                }
                else
                {
                    if (!bag["Cash"].ContainsKey(item))
                    {
                        bag["Cash"].Add(item, quantity);
                    }
                    else
                    {
                        bag["Cash"][item] += quantity;
                    }
                }
            }

            bagAmount += quantity;
        }


        foreach (var type in totalAmountByType.Where(x => x.Value != 0).OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"<{type.Key}> ${type.Value}");

            foreach (var selectedType in bag.Where(x => x.Key == type.Key))
            {
                var itemsDict = selectedType.Value
                    .OrderByDescending(x => x.Key).ThenBy(x => x.Value);

                foreach (var item in itemsDict)
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}

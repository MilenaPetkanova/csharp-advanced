using System;
using System.Collections.Generic;
using System.Linq;

// 90/100

class GreedyTimes
{
    static void Main()
    {
        long bagCapacity = long.Parse(Console.ReadLine());

        var items = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        var goldBag = new Dictionary<string, long>(StringComparer.InvariantCultureIgnoreCase);
        var gemBag = new Dictionary<string, long>(StringComparer.InvariantCultureIgnoreCase);
        var cashBag = new Dictionary<string, long>(StringComparer.InvariantCultureIgnoreCase);

        long bagAmount = 0;
        long goldAmount = 0;
        long gemAmount = 0;
        long cashAmount = 0;

        Func<long, long, long, bool> firstRule = (gold, gem, cash) => gold >= gem && gem >= cash;
        Func<long, long, long, bool> capacityRule = (x, y, z) => x >= y + z;

        for (int i = 0; i < items.Length; i += 2)
        {
            var item = items[i];
            var quantity = long.Parse(items[i + 1]);

            if (capacityRule(bagCapacity, bagAmount, quantity) == false)
                continue;

            if (item.ToLower() == "gold")
            {
                if (firstRule(goldAmount + quantity, gemAmount, cashAmount) == false)
                    continue;

                if (!goldBag.ContainsKey(item))
                {
                    goldBag.Add(item, quantity);
                }
                else
                {
                    goldBag[item] += quantity;
                }
                goldAmount += quantity;
                bagAmount += quantity;
            }

            else if (item.ToLower().EndsWith("gem"))
            {
                if (firstRule(goldAmount, gemAmount + quantity, cashAmount) == false)
                    continue;

                if (!gemBag.ContainsKey(item))
                {
                    gemBag.Add(item, quantity);
                }
                else
                {
                    gemBag[item] += quantity;
                }
                gemAmount += quantity;
                bagAmount += quantity;
            }

            else if (item.Length == 3 && item.All(Char.IsLetter))
            {
                if (firstRule(goldAmount, gemAmount, cashAmount + quantity) == false)
                    continue;

                if (!cashBag.ContainsKey(item))
                {
                    cashBag.Add(item, quantity);
                }
                else
                {
                    cashBag[item] += quantity;
                }
                cashAmount += quantity;
                bagAmount += quantity;
            }
        }

        if (goldBag.Count != 0)
            Console.WriteLine($"<Gold> ${goldAmount}");
            PrintGoldBag(goldBag);

        if (gemBag.Count != 0)
            Console.WriteLine($"<Gem> ${gemAmount}");
            PrintGemBag(gemBag);

        if (cashBag.Count != 0)
            Console.WriteLine($"<Cash> ${cashAmount}");
            PrintCashBag(cashBag);
    }

    private static void PrintCashBag(Dictionary<string, long> cashBag)
    {
        foreach (var item in cashBag.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
        {
            Console.WriteLine($"##{item.Key} - {item.Value}");
        }
    }

    private static void PrintGemBag(Dictionary<string, long> gemBag)
    {
        foreach (var item in gemBag.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
        {
            Console.WriteLine($"##{item.Key} - {item.Value}");
        }
    }

    private static void PrintGoldBag(Dictionary<string, long> goldBag)
    {
        foreach (var item in goldBag.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
        {
            Console.WriteLine($"##{item.Key} - {item.Value}");
        }
    }
}

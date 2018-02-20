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
    

    //// 100/100

    //static void Main(string[] args)
    //{
    //    long bagCapacity = long.Parse(Console.ReadLine());
    //    string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    //    var bag = new Dictionary<string, Dictionary<string, long>>();
    //    long gold = 0;
    //    long gem = 0;
    //    long cash = 0;

    //    for (int i = 0; i < safe.Length; i += 2)
    //    {
    //        string item = safe[i];
    //        long amount = long.Parse(safe[i + 1]);

    //        string itemType = GetItemType(item);

    //        if (BagExceedRule(itemType, amount, bag, bagCapacity))
    //        {
    //            continue;
    //        }

    //        string itemToCompareWith;
    //        switch (itemType)
    //        {
    //            case "Gem":
    //                itemToCompareWith = "Gold";
    //                if (!SafisfyRules(itemType, amount, bag, itemToCompareWith))
    //                {
    //                    continue;
    //                }
    //                break;
    //            case "Cash":
    //                itemToCompareWith = "Gem";
    //                if (!SafisfyRules(itemType, amount, bag, itemToCompareWith))
    //                {
    //                    continue;
    //                }
    //                break;
    //        }

    //        AddItemInBag(bag, item, amount, itemType);

    //        IncreaseItemAmount(ref gold, ref gem, ref cash, amount, itemType);
    //    }

    //    PrintBagContainings(bag);
    //}

    //private static bool BagExceedRule(string itemType, long amount, Dictionary<string, Dictionary<string, long>> bag, long bagCapacity)
    //{
    //    if (itemType == "")
    //    {
    //        return true;
    //    }
    //    else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    //private static string GetItemType(string item)
    //{
    //    string itemType = string.Empty;

    //    if (item.Length == 3)
    //    {
    //        itemType = "Cash";
    //    }
    //    else if (item.ToLower().EndsWith("gem"))
    //    {
    //        itemType = "Gem";
    //    }
    //    else if (item.ToLower() == "gold")
    //    {
    //        itemType = "Gold";
    //    }

    //    return itemType;
    //}

    //private static bool SafisfyRules(string itemType, long amount, Dictionary<string, Dictionary<string, long>> bag, string itemToCompareWith)
    //{
    //    if (!bag.ContainsKey(itemType))
    //    {
    //        if (bag.ContainsKey(itemToCompareWith))
    //        {
    //            if (amount > bag[itemToCompareWith].Values.Sum())
    //            {
    //                return false;
    //            }
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    else if (bag[itemType].Values.Sum() + amount > bag["Gold"].Values.Sum())
    //    {
    //        return false;
    //    }
    //    return true;
    //}

    //private static void IncreaseItemAmount(ref long gold, ref long gem, ref long cash, long amount, string itemType)
    //{
    //    if (itemType == "Gold")
    //    {
    //        gold += amount;
    //    }
    //    else if (itemType == "Gem")
    //    {
    //        gem += amount;
    //    }
    //    else if (itemType == "Cash")
    //    {
    //        cash += amount;
    //    }
    //}

    //private static void AddItemInBag(Dictionary<string, Dictionary<string, long>> bag, string item, long amount, string itemType)
    //{
    //    if (!bag.ContainsKey(itemType))
    //    {
    //        bag[itemType] = new Dictionary<string, long>();
    //    }

    //    if (!bag[itemType].ContainsKey(item))
    //    {
    //        bag[itemType][item] = 0;
    //    }

    //    bag[itemType][item] += amount;
    //}

    //private static void PrintBagContainings(Dictionary<string, Dictionary<string, long>> bag)
    //{
    //    foreach (var itemType in bag)
    //    {
    //        Console.WriteLine($"<{itemType.Key}> ${itemType.Value.Values.Sum()}");
    //        foreach (var item in itemType.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
    //        {
    //            Console.WriteLine($"##{item.Key} - {item.Value}");
    //        }
    //    }
    //}
}

using System;
using System.Collections.Generic;

class FilterByAge
{
    static void Main()
    {
        var peopleCount = int.Parse(Console.ReadLine());

        var people = new Dictionary<string, int>();

        for (int i = 0; i < peopleCount; i++)
        {
            var person = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            people.Add(person[0], int.Parse(person[1]));
        }

        var condition = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        var format = Console.ReadLine();

        Func<int, bool> filter = GetFiltered(condition, age);
        var printer = GetPrinted(format);

        foreach (var person in people)
        {
            if (filter(person.Value))
                printer(person);
        }
    }

    static Func<int, bool> GetFiltered(string condition, int age)
    {
        if (condition == "younger")
            return x => x < age;
        else
            return x => x >= age;
    }

    static Action<KeyValuePair<string, int>> GetPrinted(string format)
    {
        switch (format)
        {
            case "name":
                return x => Console.WriteLine(x.Key);
            case "age":
                return x => Console.WriteLine(x.Value);
            case "name age":
                return x => Console.WriteLine($"{x.Key} - {x.Value}");
            default:
                throw new NotImplementedException();
        }
    }
}

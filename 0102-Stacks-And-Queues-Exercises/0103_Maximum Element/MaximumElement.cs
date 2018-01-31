using System;
using System.Collections.Generic;
using System.Linq;

class MaximumElement
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var elements = new Stack<int>();

        var maxElements = new SortedSet<int>();
        maxElements.Add(int.MinValue);

        for (int i = 0; i < n; i++)
        {
            var query = Console.ReadLine().Split(' ').ToArray();
            var command = query[0];
            if (command == "1")
            {
                int newElement = int.Parse(query[1]);
                elements.Push(newElement);
                if (newElement > maxElements.Last())
                {
                    maxElements.Add(newElement);
                }
            }
            else if (command == "2")
            {
                int removedElement = elements.Pop();
                if (removedElement == maxElements.Last())
                {
                    maxElements.Remove(removedElement);
                }
            }
            else if (command == "3")
            {
                Console.WriteLine(maxElements.Last());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class BasicQueueOperations
{
    static void Main()
    {
        {
            var options = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = options[0];
            var s = options[1];
            var x = options[2];

            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(input[i]);
            }
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count != 0)
            {
                if (queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(queue.Count);
            }
        }
    }
}

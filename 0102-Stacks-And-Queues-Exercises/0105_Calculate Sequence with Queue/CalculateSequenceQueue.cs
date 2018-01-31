using System;
using System.Collections.Generic;

class CalculateSequenceQueue
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        var queue = new Queue<long>();
        queue.Enqueue(n);

        for (int i = 0; i < 50; i++)
        {
            queue.Enqueue(queue.Peek() + 1);
            queue.Enqueue(queue.Peek() * 2 + 1);
            queue.Enqueue(queue.Peek() + 2);

            Console.Write(queue.Dequeue() + " ");          
        }
    }
}

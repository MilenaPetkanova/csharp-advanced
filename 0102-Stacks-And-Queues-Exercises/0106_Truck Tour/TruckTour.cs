using System;
using System.Collections.Generic;
using System.Linq;

class TruckTour
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var circle = new Queue<long[]>();

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split().Select(long.Parse).ToArray();
            circle.Enqueue(tokens);
        }

        int bestStart = 0;
        for (int i = 0; i < n; i++)
        {
            bool tour = true;
            long petrol = 0;

            for (int j = 0; j < n; j++)
            {
                var pump = circle.Peek();
                var currentPump = pump[0];
                var nextDistance = pump[1];

                petrol += currentPump - nextDistance;
                if (petrol < 0)
                {
                    tour = false;
                    bestStart += j + 1; 
                    break;
                }
                circle.Enqueue(circle.Dequeue());
            }
            if (tour == true)
            {
                Console.WriteLine(bestStart);
                return;
            }
            else
            {
                circle.Enqueue(circle.Dequeue());
            }
        }
    }
}

using System;
using System.Collections.Generic;

class TrafficLight
{
    static void Main()
    {
        int greenLight = int.Parse(Console.ReadLine());
        var traffic = Console.ReadLine();

        var trafficQueue = new Queue<string>();

        var trafficCounter = 0;
        while (traffic != "end")
        {
            if (traffic == "green")
            {
                for (int i = 1; i <= greenLight; i++)
                {
                    if (trafficQueue.Count == 0)
                    {
                        break;
                    }
                    Console.WriteLine($"{trafficQueue.Peek()} passed!");
                    trafficCounter++;
                    trafficQueue.Dequeue();
                }
            }
            else
            {
                trafficQueue.Enqueue(traffic);
            }
            traffic = Console.ReadLine();
        }

        Console.WriteLine($"{trafficCounter} cars passed the crossroads.");
    }
}

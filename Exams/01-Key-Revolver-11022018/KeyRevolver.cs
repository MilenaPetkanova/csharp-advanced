using System;
using System.Linq;

class KeyRevolver
{
    static void Main()
    {
        int bulletPrice = int.Parse(Console.ReadLine());
        
        int sizeBarel = int.Parse(Console.ReadLine());

        var bullets = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();

        bullets.Reverse();

        var locks = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();

        long intelligence = long.Parse(Console.ReadLine());

        int shootBullets = 0;

        while (true)
        {
            if (bullets[0] <= locks[0])
            {
                Console.WriteLine("Bang!");
                locks.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            bullets.RemoveAt(0);
            shootBullets++;

            intelligence -= bulletPrice;

            if (shootBullets == sizeBarel && bullets.Count != 0)
            {
                Console.WriteLine("Reloading!");
                shootBullets = 0;
            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence}");
                break;
            }
            else if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsArr = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locksArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>();
            Queue<int> locks = new Queue<int>();

            for (int i = 0; i < bulletsArr.Length; i++)
            {
                bullets.Push(bulletsArr[i]);
            }

            for (int i = 0; i < locksArr.Length; i++)
            {
                locks.Enqueue(locksArr[i]);
            }

            int bulletsCount = bullets.Count();
            int counter = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int currBullet = bullets.Peek();
                int currLock = locks.Peek();
                bullets.Pop();
                counter++;
                
                if (currBullet > currLock)
                {
                    Console.WriteLine("Ping!");
                }
                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                if (counter == gunBarrel && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    counter = 0;
                }
            }

            if (locks.Count == 0)
            {
                int moneyEarned = intelligence - ((bulletsCount - bullets.Count()) * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
           
        }
    }
}

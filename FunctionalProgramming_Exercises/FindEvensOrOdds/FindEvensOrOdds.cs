using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputNumbers[0];
            int m = inputNumbers[1];
            string command = Console.ReadLine();

            if (command == "odd")
            {
                List<int> numbers = new List<int>();
                for (int i = n; i <= m; i++)
                {
                    numbers.Add(i);
                }
                Console.WriteLine(string.Join(" ", numbers.Where(num => num % 2 != 0)));
            }
            else
            {
                List<int> numbers = new List<int>();
                for (int i = n; i <= m; i++)
                {
                    numbers.Add(i);
                }
                Console.WriteLine(string.Join(" ", numbers.Where(num => num % 2 == 0)));
            }
        }
    }
}

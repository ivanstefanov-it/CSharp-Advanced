using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersCount = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine()); // number of lines

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (numbersCount.ContainsKey(number) == false)
                {
                    numbersCount.Add(number, 1);
                }
                else
                {
                    numbersCount[number]++;
                }
            }

            foreach (var number in numbersCount.Where(x => x.Value % 2 == 0))
            {
                 Console.WriteLine(string.Join("", number.Key));
            }
        }
    }
}

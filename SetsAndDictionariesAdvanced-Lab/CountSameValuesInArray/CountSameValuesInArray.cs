using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> valuesCount = new Dictionary<double, int>();
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (valuesCount.ContainsKey(input[i]) == false)
                {
                    valuesCount.Add(input[i], 1);
                }
                else
                {
                    valuesCount[input[i]]++;
                }
            }

            foreach (var value in valuesCount)
            {
                Console.WriteLine($"{value.Key} - {value.Value} times");
            }
        }
    }
}

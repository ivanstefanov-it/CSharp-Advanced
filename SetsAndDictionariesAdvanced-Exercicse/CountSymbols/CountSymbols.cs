using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> symbolCount = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (symbolCount.ContainsKey(input[i]) == false)
                {
                    symbolCount.Add(input[i], 1);
                }
                else
                {
                    symbolCount[input[i]]++;
                }
            }

            foreach (var symbol in symbolCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}

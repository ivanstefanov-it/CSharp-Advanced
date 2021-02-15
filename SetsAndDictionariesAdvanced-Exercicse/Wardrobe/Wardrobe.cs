using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // number of lines
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(",");

                if (wardrobe.ContainsKey(color) == false)
                {
                    Dictionary<string, int> currDict = new Dictionary<string, int>();
                    wardrobe.Add(color, currDict);
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (wardrobe[color].ContainsKey(clothes[j]) == false)
                    {
                        wardrobe[color].Add(clothes[j], 1);
                    }
                    else
                    {
                        wardrobe[color][clothes[j]]++;
                    }
                }
            }
            string[] dressToFind = Console.ReadLine().Split();
            string dressColor = dressToFind[0];
            string item = dressToFind[1];

            foreach (var colors in wardrobe)
            {
                Console.WriteLine($"{colors.Key} clothes:");

                foreach (var dress in colors.Value)
                {
                    if (colors.Key == dressColor && dress.Key == item)
                    {
                        Console.WriteLine($"    * {dress.Key} - {dress.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"    * {dress.Key} - {dress.Value}");
                    }
                }
            }
        }
    }
}

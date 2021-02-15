using System;
using System.Linq;
using System.Collections.Generic;

namespace CitiesByContinenAndCountry
{
    class CitiesByContinenAndCountry
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continentData = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine()); // number of lines

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (continentData.ContainsKey(continent) == false)
                {
                    continentData.Add(continent, new Dictionary<string, List<string>>());
                    continentData[continent].Add(country, new List<string>());
                }
                if (continentData[continent].ContainsKey(country) == false)
                {
                    continentData[continent].Add(country, new List<string>());
                }
                continentData[continent][country].Add(city);
            }
            
            foreach (var continent in continentData)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}

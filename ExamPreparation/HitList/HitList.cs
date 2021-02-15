using System;
using System.Collections.Generic;
using System.Linq;

namespace HitList
{
    class HitList
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            Dictionary<string, SortedDictionary<string, string>> people = new Dictionary<string, SortedDictionary<string, string>>();
            string input = Console.ReadLine();

            while (input != "end transmissions")
            {
                string[] tokens = input.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string[] kvps = tokens[1].Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (people.ContainsKey(name) == false)
                {
                    people.Add(name, new SortedDictionary<string, string>());
                }
                for (int i = 0; i < kvps.Length; i++)
                {
                    string[] kvp = kvps[i].Split(":");
                    string key = kvp[0];
                    string value = kvp[1];

                    if (people[name].ContainsKey(key) == false)
                    {
                        people[name].Add(key, value);
                    }
                    else
                    {
                        people[name][key] = value;
                    }
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            string personToKill = input.Remove(0, 5);
            Console.WriteLine($"Info on {personToKill}:");
            int infoIndex = 0;

            foreach (var person in people[personToKill])
            {
                Console.WriteLine($"---{person.Key}: {person.Value}");
                infoIndex += person.Key.Length;
                infoIndex += person.Value.Length;
            }

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}

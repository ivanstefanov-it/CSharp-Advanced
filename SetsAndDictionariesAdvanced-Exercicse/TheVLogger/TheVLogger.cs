﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] elements = input.Split();

                string user = elements[0];
                string command = elements[1];
                string targetUser = elements[2];

                if (command == "joined")
                {
                    if (vloggers.ContainsKey(user) == false)
                    {
                        vloggers.Add(user, new Dictionary<string, SortedSet<string>>());
                        vloggers[user].Add("following", new SortedSet<string>());
                        vloggers[user].Add("followers", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    bool isSamePerson = user == targetUser;

                    if (vloggers.ContainsKey(user) && vloggers.ContainsKey(targetUser) && !isSamePerson)
                    {
                        vloggers[user]["following"].Add(targetUser);
                        vloggers[targetUser]["followers"].Add(user);
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVloggers = vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count);

            int counter = 1;

            foreach (var item in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var vloggerName in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {vloggerName}");
                    }
                }
                counter++;
            }
        }
    }
}

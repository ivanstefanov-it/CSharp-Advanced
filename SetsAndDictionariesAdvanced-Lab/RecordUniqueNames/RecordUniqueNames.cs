﻿using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    class RecordUniqueNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // number of lines
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}

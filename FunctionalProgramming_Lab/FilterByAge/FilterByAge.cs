using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // number of lines
            List<KeyValuePair<string, int>> people = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string name = person[0];
                int age = int.Parse(person[1]);

                people.Add(new KeyValuePair<string, int>(name, age));
            }
            string condition = Console.ReadLine();
            int ages = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split();

            people
                .Where(p => condition == "younger" ? p.Value <= ages : p.Value >= ages)
                .ToList()
                .ForEach(p => Printer(p, format));
        }
        static void Printer(KeyValuePair<string, int> person, string[] printPatern)
        {
            if (printPatern.Length == 2)
            {
                Console.WriteLine(printPatern[0] == "name" ?
                    $"{person.Key} - {person.Value}" :
                    $"{person.Value} - {person.Key}");
            }
            else
            {
                Console.WriteLine(printPatern[0] == "name" ?
                    $"{person.Key}" :
                    $"{person.Value}");
            }
        }

    }
}

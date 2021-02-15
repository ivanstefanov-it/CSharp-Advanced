using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] elements = input.Split(":");

                string contestName = elements[0];
                string password = elements[1];

                if (contests.ContainsKey(contestName) == false)
                {
                    contests.Add(contestName, password);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] elements = input.Split("=>");

                string contest = elements[0];
                string password = elements[1];
                string username = elements[2];
                int points = int.Parse(elements[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (students.ContainsKey(username) == false)
                    {
                        students.Add(username, new Dictionary<string, int>());
                    }
                    if (students[username].ContainsKey(contest) == false)
                    {
                        students[username].Add(contest, points);
                    }
                    if (students[username][contest] < points)
                    {
                        students[username][contest] = points;
                    }
                }
                input = Console.ReadLine();
            }

            var topStudent = students.OrderByDescending(x => x.Value.Sum(s => s.Value)).FirstOrDefault();

            Console.WriteLine($"Best candidate is {topStudent.Key} with total {topStudent.Value.Sum(x => x.Value)} points.");

            Console.WriteLine("Ranking:");

            foreach (var names in students.OrderBy(x => x.Key))
            {
                Console.WriteLine(names.Key);

                foreach (var item in names.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}

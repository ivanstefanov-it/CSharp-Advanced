using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // number of lines
            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();
            
            for (int i = 0; i < n; i++)
            {
                string[] grades = Console.ReadLine().Split();
                string name = grades[0];
                double grade = double.Parse(grades[1]);

                if (studentsGrades.ContainsKey(name) == false)
                {
                    studentsGrades.Add(name, new List<double>());
                    studentsGrades[name].Add(grade);
                }
                else
                {
                    studentsGrades[name].Add(grade);
                }
            }

            foreach (var student in studentsGrades)
            {
                string name = student.Key;
                List<double> grade = student.Value;
                double average = grade.Average();

                Console.Write($"{name} -> ");

                foreach (var item in grade)
                {
                    Console.Write($"{item:F2} ");
                }
                Console.WriteLine($"(avg: {average:F2})");
            }
        }
    }
}

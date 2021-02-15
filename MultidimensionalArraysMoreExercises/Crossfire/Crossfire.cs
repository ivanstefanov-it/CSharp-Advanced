using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    class Crossfire
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            List<List<int>> matrix = new List<List<int>>();

            GetMatrix(matrix, rows, cols);

            string command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                int[] coordinates = command.Split().Select(int.Parse).ToArray();

                int row = coordinates[0];
                int col = coordinates[1];
                int radius = coordinates[2];

                Attack(matrix, row, col, radius);

                command = Console.ReadLine();
            }
            Print(matrix);
        }

        private static void Attack(List<List<int>> matrix, int row, int col, int radius)
        {
            for (int i = row - radius; i <= row + radius; i++)
            {
                if (IsInside(matrix, i, col))
                {
                    matrix[i][col] = 0;
                }
            }

            for (int i = col - radius; i <= col + radius; i++)
            {
                if (IsInside(matrix, row, i))
                {
                    matrix[row][i] = 0;
                }
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                matrix[i].RemoveAll(x => x == 0);

                if (matrix[i].Count == 0)
                {
                    matrix.RemoveAt(i);
                    i--;
                }
            }
        }

        private static bool IsInside(List<List<int>> matrix, int i, int col)
        {
            return i >= 0 && i < matrix.Count && col >= 0 && col < matrix[i].Count;
        }

        private static void Print(List<List<int>> matrix)
        {
            foreach (var num in matrix)
            {
                Console.WriteLine(string.Join(" ", num));
            }
        }

        private static void GetMatrix(List<List<int>> matrix, int rows, int cols)
        {
            int counter = 1;
            for (int i = 0; i < rows; i++)
            {
                List<int> currNumbers = new List<int>(); 
                for (int j = 0; j < cols; j++)
                {
                    currNumbers.Add(counter++);
                }

                matrix.Add(currNumbers);
            }
        }
    }
}

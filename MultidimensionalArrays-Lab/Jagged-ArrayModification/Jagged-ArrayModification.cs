using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    class Jagged_ArrayModification
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine()); // size of the array
            int[][] jaggedArray = new int[size][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    jaggedArray[i] = input;
                }
            }

            string[] command = Console.ReadLine().Split();

            while (command[0]?.ToLower() != "end")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 ||
                    row > jaggedArray.Length - 1 ||
                    col < 0 ||
                    col > jaggedArray[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine().Split();
                    continue;
                }
                if (command[0] == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (command[0] == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }
                command = Console.ReadLine().Split();
            }

            foreach (var element in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", element));
            }
        }
    }
}

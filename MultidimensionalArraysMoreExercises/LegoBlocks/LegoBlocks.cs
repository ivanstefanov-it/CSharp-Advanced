using System;
using System.Linq;

namespace LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] firstJaggedArray = new int[n][];
            int[][] secondJaggedArray = new int[n][];

            for (int i = 0; i < n; i++)
            {
                firstJaggedArray[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                secondJaggedArray[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).Reverse().ToArray();
            }

            int rowLenght = firstJaggedArray[0].Length + secondJaggedArray[0].Length;
            int allElements = 0;
            bool isMatch = true;

            for (int i = 0; i < n; i++)
            {
                int currentLenght = firstJaggedArray[i].Length + secondJaggedArray[i].Length;
                if (currentLenght != rowLenght)
                {
                    isMatch = false;
                }

                allElements += currentLenght;
            }

            if (isMatch)
            {
                int[] resultRow = new int[rowLenght];
                for (int i = 0; i < n; i++)
                {
                    resultRow = firstJaggedArray[i].Concat(secondJaggedArray[i]).ToArray();
                    Console.WriteLine($"[{string.Join(", ", resultRow)}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {allElements}");
            }
        }
    }
}

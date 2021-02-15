using System;
using System.Linq;

namespace GroupNumbers
{
    class GroupNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = numbers.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            jaggedArray[1] = numbers.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            jaggedArray[2] = numbers.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            foreach (var number in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", number));
            }

        }
    }
}

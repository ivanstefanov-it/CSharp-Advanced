using System;
using System.Linq;

namespace AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            Action<int[]> print = p => Console.WriteLine(string.Join(" ", p));
            Func<int[], int[]> addOne = nums => nums.Select(x => x + 1).ToArray();
            Func<int[], int[]> subractOne = nums => nums.Select(x => x - 1).ToArray();
            Func<int[], int[]> multiply = nums => nums.Select(x => x * 2).ToArray();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "add")
                {
                    numbers = addOne(numbers);
                }
                else if (input == "subtract")
                {
                    numbers = subractOne(numbers);
                }
                else if (input == "multiply")
                {
                    numbers = multiply(numbers);
                }
                else if (input == "print")
                {
                    print(numbers);
                }

                input = Console.ReadLine();
            }
        }
    }
}

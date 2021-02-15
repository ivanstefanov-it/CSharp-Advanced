using System;
using System.Linq;

namespace CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            Action<int[]> print = p => Console.WriteLine(string.Join(" ", p));
            Func<int, int, int> sortFunc = (a, b) =>
                                (a % 2 == 0 && b % 2 != 0) ? -1 :
                                (a % 2 != 0 && b % 2 == 0) ? 1 :
                                a.CompareTo(b);

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(numbers, new Comparison<int>(sortFunc));

            print(numbers);
        }
    }
}

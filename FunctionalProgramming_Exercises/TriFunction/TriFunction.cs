using System;
using System.Linq;

namespace TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] inputNames = Console.ReadLine().Split();

            Func<string, int, bool> IsEqualSum = (name, totalSum) => name.Sum(x => x) >= totalSum;
            Func<string[], Func<string, int, bool>, string> firstNameFunc = (names, isEqualSumOfAscii) =>
                            names.FirstOrDefault(x => IsEqualSum(x, number));

            string result = firstNameFunc(inputNames, IsEqualSum);
            Console.WriteLine(result);
        }
    }
}

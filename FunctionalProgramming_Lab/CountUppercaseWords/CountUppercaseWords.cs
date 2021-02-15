using System;
using System.Linq;

namespace CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in input)
            {
                if (char.IsUpper(word[0]))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}

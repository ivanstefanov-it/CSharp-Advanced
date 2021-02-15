using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divNumber = int.Parse(Console.ReadLine());

            Action<List<int>> print = p => Console.WriteLine(string.Join(" ", p));
            Action<List<int>> reverse = num => num.Reverse();
            Func<List<int>, List<int>> remove = num => num.Where(x => x % divNumber != 0).ToList();
            
            reverse(numbers);
            numbers = remove(numbers);
            print(numbers);
            
        }
    }
}

using System;
using System.Linq;

namespace PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split().Where(w => w.Length <= n).ToArray();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}

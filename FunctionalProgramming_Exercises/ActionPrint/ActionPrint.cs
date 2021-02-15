using System;

namespace ActionPrint
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}

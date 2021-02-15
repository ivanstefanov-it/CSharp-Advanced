using System;
using System.Collections.Generic;

namespace DecimalToBinaryConverter
{
    class DecimalToBinaryConverter
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            if (decimalNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (decimalNumber != 0)
            {
                stack.Push(decimalNumber % 2);
                decimalNumber /= 2;
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}

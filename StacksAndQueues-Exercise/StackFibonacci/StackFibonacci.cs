using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    class StackFibonacci
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> fibonacci = new Stack<long>();
            fibonacci.Push(0);
            fibonacci.Push(1);

            for (int i = 0; i < n - 1; i++)
            {
                long firstNumber = fibonacci.Pop();
                long secondNumber = fibonacci.Peek();
                fibonacci.Push(firstNumber);
                fibonacci.Push(firstNumber + secondNumber);
            }
            Console.WriteLine(fibonacci.Peek());
        }
    }
}

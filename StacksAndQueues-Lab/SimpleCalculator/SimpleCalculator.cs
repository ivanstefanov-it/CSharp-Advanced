using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] values = input.Split();
            Stack<string> stack = new Stack<string>(values.Reverse());

            while (stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string operant = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                switch (operant)
                {
                    case "+":
                        stack.Push((firstNumber + secondNumber).ToString());
                        break;
                    case "-":
                        stack.Push((firstNumber - secondNumber).ToString());
                        break;
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}

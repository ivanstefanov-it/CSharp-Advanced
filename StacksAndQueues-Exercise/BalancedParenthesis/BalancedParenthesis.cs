using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            Stack<char> bracket = new Stack<char>();
            string input = Console.ReadLine();

            foreach (var ch in input)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    bracket.Push(ch);
                }
                else 
                {
                    if (bracket.Peek() == '(' && ch == ')')
                    {
                        bracket.Pop();
                    }
                    else if (bracket.Peek() == '{' && ch == '}')
                    {
                        bracket.Pop();
                    }
                    else if (bracket.Peek() == '[' && ch == ']')
                    {
                        bracket.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}

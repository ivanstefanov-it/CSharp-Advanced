using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    class MaximumElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> parts = new List<int>();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                parts = Console.ReadLine().Split().Select(int.Parse).ToList();

                if (parts[0] == 1)
                {
                    stack.Push(parts[1]);
                }
                else if (parts[0] == 2)
                {
                    stack.Pop();
                }
                else if (parts[0] == 3)
                {
                    int max = int.MinValue;
                    while (stack.Count != 0)
                    {
                        if (stack.Peek() > max)
                        {
                            max = stack.Pop();
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                    
                    Console.WriteLine(max);
                }
                parts.Clear();
            }
        }
    }
}

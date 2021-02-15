using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            int[] parts = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = parts[0]; // Number of elements to push into the stack
            int s = parts[1]; // Number of element to pop from the stack
            int x = parts[2]; // An element that you should look for in the stack

            Stack<int> stack = new Stack<int>(n);
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (var num in arr)
            {
                stack.Push(num);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }
            bool isFind = stack.Contains(x);

            if (isFind)
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallest = int.MaxValue;
                while (stack.Count != 0)
                {
                    if (smallest > stack.Peek())
                    {
                        smallest = stack.Pop();
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                if (smallest != int.MaxValue)
                {
                    Console.WriteLine(smallest);
                }
                else
                {
                    Console.WriteLine(0);
                }
                
            }
        }
    }
}

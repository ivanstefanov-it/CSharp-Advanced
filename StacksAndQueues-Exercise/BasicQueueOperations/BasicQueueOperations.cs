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

            Queue<int> queue = new Queue<int>(n);
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (var num in arr)
            {
                queue.Enqueue(num);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }
            bool isFind = queue.Contains(x);

            if (isFind)
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallest = int.MaxValue;
                while (queue.Count != 0)
                {
                    if (smallest > queue.Peek())
                    {
                        smallest = queue.Dequeue();
                    }
                    else
                    {
                        queue.Dequeue();
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

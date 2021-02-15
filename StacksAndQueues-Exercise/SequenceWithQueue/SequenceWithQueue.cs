using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceWithQueue
{
    class SequenceWithQueue
    {
        static void Main(string[] args)
        {
            long inputNumber = long.Parse(Console.ReadLine());

            List<long> resultNumbers = new List<long>();
            Queue<long> queue = new Queue<long>();

            queue.Enqueue(inputNumber);
            resultNumbers.Add(inputNumber);

            for (int i = 0; i < 17; i++)
            {
                long currentNumber = queue.Dequeue();

                long a = currentNumber + 1;
                long b = currentNumber * 2 + 1;
                long c = currentNumber + 2;

                queue.Enqueue(a);
                queue.Enqueue(b);
                queue.Enqueue(c);

                resultNumbers.Add(a);
                resultNumbers.Add(b);
                resultNumbers.Add(c);
            }

            Console.WriteLine(string.Join(" ", resultNumbers.Take(50)));
        }
    }
}

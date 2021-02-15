using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class SquareWithMaximumSum
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadInput();
            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] elements = ReadInput();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            int maxSum = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                int currSum = 0;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    currSum += matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        rowIndex = i;
                        colIndex = j;
                    }
                    currSum = 0;
                }
            }

            for (int i = rowIndex; i <= rowIndex  + 1; i++)
            {
                for (int j = colIndex; j <= colIndex  + 1; j++)
                {
                    Console.Write($"{matrix[i , j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);

        }

        private static int[] ReadInput()
        {
            return Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}

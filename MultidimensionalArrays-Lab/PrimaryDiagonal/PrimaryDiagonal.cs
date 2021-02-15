using System;
using System.Linq;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            int primaryDiagonalSum = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (i == j && i == 0 && j == 0)
                    {
                        primaryDiagonalSum += matrix[i, j] + matrix[i + 1, j + 1];
                    }
                    else if (i == j)
                    {
                        primaryDiagonalSum += matrix[i + 1, j + 1];
                    }
                }
            }
            Console.WriteLine(primaryDiagonalSum);
        }
    }
}

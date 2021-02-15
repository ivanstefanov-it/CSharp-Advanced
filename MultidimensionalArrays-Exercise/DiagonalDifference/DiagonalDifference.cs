using System;
using System.Linq;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[][] matrix = new int[matrixSize][];
            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                primaryDiagonalSum += matrix[i][i];
                secondaryDiagonalSum += matrix[i][matrix.Length - 1 - i];
            }

            int result = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(result);
        }
    }
}

using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            string[][] matrix = new string[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[cols];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    char firstLeter = alphabet[row];
                    char middleLeter = alphabet[row + col];

                    matrix[row][col] = $"{firstLeter}{middleLeter}{firstLeter}";

                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

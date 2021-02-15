using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            int[] size = ReadInput();
            string snake = Console.ReadLine();
            int[] target = ReadInput();


            int rows = size[0];
            int cols = size[1];

            char[][] matrix = new char[rows][];

            GetMatrix(matrix, cols, snake);
            Shoot(matrix, target);
            Collapse(matrix);
            Print(matrix);

        }

        private static void Collapse(char[][] matrix)
        {
            Queue<char> element = new Queue<char>(matrix.Length);

            for (int col = 0; col < matrix[0].Length; col++)
            {
                int counter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        element.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = counter; row < matrix.Length; row++)
                {
                    matrix[row][col] = element.Dequeue();
                }
            }
        }

        private static void Shoot(char[][] matrix, int[] target)
        {
            int targetRow = target[0];
            int targetCol = target[1];
            int radius = target[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool isInside = Math.Pow((targetRow - row), 2) + Math.Pow((targetCol - col), 2) <= Math.Pow(radius, 2);

                    if (isInside)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static int[] ReadInput()
        {
            return Console.ReadLine().Split().Select(int.Parse).ToArray();
        }

        private static void Print(char[][] matrix)
        {
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static void GetMatrix(char[][] matrix, int cols, string snake)
        {
            int counter = 0;
            bool isLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];

                if (isLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        counter = SetLetter(matrix, snake, counter, row, col);
                    }
                    isLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        counter = SetLetter(matrix, snake, counter, row, col);
                    }
                    isLeft = true;
                }

                
            }
        }

        private static int SetLetter(char[][] matrix, string snake, int counter, int row, int col)
        {
            if (counter > snake.Length - 1)
            {
                counter = 0;
            }

            matrix[row][col] = snake[counter++];
            return counter;
        }
    }
}

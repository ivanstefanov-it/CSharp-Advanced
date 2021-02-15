using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveBunnies
{
    class RadioactiveBunnies
    {
        static int playerRow;
        static int playerCol;
        static char[][] jaggedArray;
        static bool isOutside;
        static bool isDead;

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            jaggedArray = new char[rows][];

            FillingJaggedArray(cols);
            
            string directions = Console.ReadLine();

            MovePlayer(directions);
        }

        private static void MovePlayer(string directions)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                char currDerectoin = directions[i];

                if (currDerectoin == 'U')
                {
                    Move(-1, 0);
                }
                else if (currDerectoin == 'L')
                {
                    Move(0, -1);
                }
                else if (currDerectoin == 'R')
                {
                    Move(0, 1);
                }
                else if (currDerectoin == 'D')
                {
                    Move(1, 0);
                }

                Spread();
                    
                if (isDead)
                {
                    PrintJaggedArray();
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
                else if (isOutside)
                {
                    PrintJaggedArray();
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        private static void Spread()
        {
            Queue<int[]> indexes = new Queue<int[]>();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (jaggedArray[i][j] == 'B')
                    {
                        indexes.Enqueue(new int[] { i, j });
                    }
                }
            }

            while (indexes.Count > 0)
            {
                int[] currIndex = indexes.Dequeue();
                int targetRow = currIndex[0];
                int targetCol = currIndex[1];

                if (IsInside(targetRow - 1, targetCol))
                {
                    if (IsPlayer(targetRow - 1, targetCol))
                    {
                        isDead = true;
                    }
                    jaggedArray[targetRow - 1][targetCol] = 'B';
                }

                if (IsInside(targetRow + 1, targetCol))
                {
                    if (IsPlayer(targetRow + 1, targetCol))
                    {
                        isDead = true;
                    }
                    jaggedArray[targetRow + 1][targetCol] = 'B';
                }

                if (IsInside(targetRow , targetCol - 1))
                {
                    if (IsPlayer(targetRow, targetCol - 1))
                    {
                        isDead = true;
                    }
                    jaggedArray[targetRow][targetCol - 1] = 'B';
                }

                if (IsInside(targetRow, targetCol + 1))
                {
                    if (IsPlayer(targetRow, targetCol + 1))
                    {
                        isDead = true;
                    }
                    jaggedArray[targetRow][targetCol + 1] = 'B';
                }
            }
        }

        private static bool IsPlayer(int row, int col)
        {
            return jaggedArray[row][col] == 'P';
        }

        private static void Move(int row, int col)
        {
            int targetRow = playerRow + row;
            int targetCol = playerCol + col;

            if (IsInside(targetRow, targetCol) == false)
            {
                jaggedArray[playerRow][playerCol] = '.';
                isOutside = true;
            }
             else if (IsBunny(targetRow, targetCol))
            {
                jaggedArray[playerRow][playerCol] = '.';
                playerRow += row;
                playerCol += col;
                isDead = true;
            }
            else
            {
                jaggedArray[playerRow][playerCol] = '.';

                playerRow += row;
                playerCol += col;

                jaggedArray[playerRow][playerCol] = 'P';
            }
        }

        private static bool IsBunny(int targetRow, int targetCol)
        {
            return jaggedArray[targetRow][targetCol] == 'B';
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length; 
        }

        private static void PrintJaggedArray()
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join("", jaggedArray[i]));
            }
        }

        private static void FillingJaggedArray(int cols)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                string input = Console.ReadLine();
                jaggedArray[i] = new char[cols];

                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = input[j];

                    if (input[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
        }
    }
}

using System;

namespace KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] jaggedArray = new char[n][];

            FillingMatrix(jaggedArray);
            int targetRow = 0;
            int targetCol = 0;
            int removeKnights = 0;

            while (true)
            {
                int maxAttacked = 0;

                for (int i = 0; i < jaggedArray.Length; i++)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        int attacked = 0;
                        if (jaggedArray[i][j] == 'K')
                        {
                            // up left
                            if (IsInside(jaggedArray, i - 2, j - 1) && jaggedArray[i - 2][j - 1] == 'K')
                            {
                                attacked++;
                            }

                            // up right
                            if (IsInside(jaggedArray, i - 2, j + 1) && jaggedArray[i - 2][j + 1] == 'K')
                            {
                                attacked++;
                            }

                            // down left
                            if (IsInside(jaggedArray, i + 2, j - 1) && jaggedArray[i + 2][j - 1] == 'K')
                            {
                                attacked++;
                            }

                            // down right
                            if (IsInside(jaggedArray, i + 2, j + 1) && jaggedArray[i + 2][j + 1] == 'K')
                            {
                                attacked++;
                            }

                            // left up
                            if (IsInside(jaggedArray, i - 1, j - 2) && jaggedArray[i - 1][j - 2] == 'K')
                            {
                                attacked++;
                            }

                            // left down
                            if (IsInside(jaggedArray, i + 1, j - 2) && jaggedArray[i + 1][j - 2] == 'K')
                            {
                                attacked++;
                            }

                            // right up
                            if (IsInside(jaggedArray, i - 1, j + 2) && jaggedArray[i - 1][j + 2] == 'K')
                            {
                                attacked++;
                            }

                            // right down
                            if (IsInside(jaggedArray, i + 1, j + 2) && jaggedArray[i + 1][j + 2] == 'K')
                            {
                                attacked++;
                            }
                        }
                        if (attacked > maxAttacked)
                        {
                            maxAttacked = attacked;
                            targetRow = i;
                            targetCol = j;
                        }
                    }
                }

                if (maxAttacked > 0)
                {
                    jaggedArray[targetRow][targetCol] = '0';
                    removeKnights++;
                }
                else
                {
                    Console.WriteLine(removeKnights);
                    break;
                }
            }
        }

        private static bool IsInside(char[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray.Length;
        }

        private static void FillingMatrix(char[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = Console.ReadLine().ToCharArray();
            }
        }
    }
}

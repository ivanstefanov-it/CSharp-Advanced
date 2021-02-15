using System;
using System.Linq;

namespace ParkingSystem
{
    class ParkingSystem
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] matrix = new int[rows][];
            string[] command = Console.ReadLine().Split();

           

            while (command[0] != "stop")
            {
                int entryRow = int.Parse(command[0]);
                int x = int.Parse(command[1]);      // coordinates of the desired parking spot
                int y = int.Parse(command[2]);      // coordinates of the desired parking spot
                int steps = Math.Abs(entryRow - x) + 1;

                if (matrix[x] == null)              
                {
                    matrix[x] = new int[cols];      
                }

                if (matrix[x][y] == 0)
                {
                    matrix[x][y] = 1;
                    steps += y;                           
                    Console.WriteLine(steps);
                }
                else
                {
                    int counter = 1;                            
                    while (true)
                    {
                        int lowerCell = y - counter;
                        int upperCell = y + counter;

                        if (lowerCell < 1 && upperCell > cols - 1) 
                        {
                            Console.WriteLine($"Row {x} full");
                            break;
                        }
                        if (lowerCell > 0 && matrix[x][lowerCell] == 0)   
                        {                                                 
                            matrix[x][lowerCell] = 1;
                            steps += lowerCell;
                            Console.WriteLine(steps);
                            break;
                        }
                        if (upperCell < cols && matrix[x][upperCell] == 0)
                        {                                                 
                            matrix[x][upperCell] = 1;                                                         
                            steps += upperCell;
                            Console.WriteLine(steps);
                            break;
                        }
                        counter++;
                    }
                }
                command = Console.ReadLine().Split();
            }
        }
    }
}

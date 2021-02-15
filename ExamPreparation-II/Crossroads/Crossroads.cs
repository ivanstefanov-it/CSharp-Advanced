using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int counter = 0;

            while (command != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                    command = Console.ReadLine();
                    continue;
                }
                int currGreenLight = greenLightDuration;
                string currCar = string.Empty;
                string outputcar = string.Empty;

                while (currGreenLight > 0 && cars.Count > 0)
                {
                    currCar = cars.Dequeue();
                    outputcar = currCar;
                    currGreenLight -= currCar.Length;

                    if (currGreenLight >= 0)
                    {
                        counter++;
                        continue;
                    }

                    currCar = currCar.Remove(0, currCar.Length - currGreenLight * -1);
                    currGreenLight += freeWindowDuration;

                    if (currGreenLight >= 0)
                    {
                        counter++;
                        break; ;
                    }

                    currCar = currCar.Remove(0, currCar.Length - currGreenLight * -1);
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{outputcar} was hit at {currCar[0]}.");
                    return;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}

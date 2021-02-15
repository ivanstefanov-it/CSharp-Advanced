using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] input = command.Split(", ");
                string direction = input[0];
                string numbers = input[1];

                if (direction == "IN")
                {
                    carNumbers.Add(numbers);
                }
                else
                {
                    carNumbers.Remove(numbers);
                }
                command = Console.ReadLine();
            }

            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in carNumbers)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            string guest = Console.ReadLine();

            while (guest != "PARTY")
            {
                char firstLetter = guest[0];

                if (char.IsDigit(firstLetter))
                {
                    VIP.Add(guest);
                }
                else
                {
                    regularGuests.Add(guest);
                }
                guest = Console.ReadLine();
            }

            guest = Console.ReadLine();

            while (guest != "END")
            {
                char firstLetter = guest[0];

                if (char.IsDigit(firstLetter))
                {
                    VIP.Remove(guest);
                }
                else
                {
                    regularGuests.Remove(guest);
                }
                guest = Console.ReadLine();
            }

            Console.WriteLine(VIP.Count + regularGuests.Count);

            foreach (var person in VIP)
            {
                Console.WriteLine(person);
            }

            foreach (var person in regularGuests)
            {
                Console.WriteLine(person);
            }
        }
    }
}

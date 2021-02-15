using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicketTrouble
{
    class TicketTrouble
    {
        static void Main(string[] args)
        {
            string firstPattern = @"\[[^\]]*{([A-Z]{3} [A-Z]{2})}.*?{([A-Z]{1}[0-9]{1,2})}[^[]*\]";
            string secondPattern = @"{[^}]*\[([A-Z]{3} [A-Z]{2})\].*?\[([A-Z]{1}[0-9]{1,2})\][^{]*}";
            List<string> seats = new List<string>();

            string destination = Console.ReadLine();
            string input = Console.ReadLine();

            MatchCollection firstMatches = Regex.Matches(input, firstPattern);
            MatchCollection secondMatches = Regex.Matches(input, secondPattern);

            AddSeats(seats, destination, firstMatches);
            AddSeats(seats, destination, secondMatches);

            if (seats.Count == 2)
            {
                Console.WriteLine($"You are traveling to {destination} on seats {seats[0]} and {seats[1]}.");
            }
            else
            {
                for (int i = 0; i < seats.Count; i++)
                {
                    for (int j = i + 1; j < seats.Count; j++)
                    {
                        string firstSeat = seats[i].Substring(1);
                        string secondSeat = seats[j].Substring(1);

                        if (firstSeat == secondSeat)
                        {
                            Console.WriteLine($"You are traveling to {destination} on seats {seats[i]} and {seats[j]}.");
                            return;
                        }
                    }
                }
            }
        }

        private static void AddSeats(List<string> seats, string destination, MatchCollection matches)
        {
            foreach (Match item in matches)
            {
                if (item.Groups[1].Value.Contains(destination))
                {
                    seats.Add(item.Groups[2].Value);
                }
            }
        }
    }
}

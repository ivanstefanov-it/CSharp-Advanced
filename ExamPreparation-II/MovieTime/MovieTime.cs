using System;
using System.Linq;
using System.Collections.Generic;

namespace MovieTime
{
    class MovieTime
    {
        static void Main(string[] args)
        {
            string genre = Console.ReadLine();
            string duration = Console.ReadLine();
            var movies = new Dictionary<string, Dictionary<string, TimeSpan>>();
            string command = Console.ReadLine();
            TimeSpan totalMovieDuration = new TimeSpan();

            while (command != "POPCORN!")
            {
                string[] movieArgs = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string movieName = movieArgs[0];
                string movieGenre = movieArgs[1];
                TimeSpan movieDuration = TimeSpan.Parse(movieArgs[2]);
                totalMovieDuration += movieDuration;

                if (movies.ContainsKey(movieGenre) == false)
                {
                    movies.Add(movieGenre, new Dictionary<string, TimeSpan>());
                }
                if (movies[movieGenre].ContainsKey(movieName) == false)
                {
                    movies[movieGenre].Add(movieName, movieDuration);
                }

                command = Console.ReadLine();
            }
            
            if (duration == "Short")
            {
                movies[genre] = movies[genre]
                    .OrderBy(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, y => y.Value);
            }
            else
            {
                movies[genre] = movies[genre]
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, y => y.Value);
            }

            foreach (var movie in movies[genre])
            {
                Console.WriteLine(movie.Key);
                command = Console.ReadLine();
                if (command == "Yes")
                {
                    Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                    Console.WriteLine($"Total Playlist Duration: {totalMovieDuration}");
                    return;
                }
            }
        }
    }
}

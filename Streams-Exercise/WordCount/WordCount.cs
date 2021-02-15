using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace LinesNumber
{
    class WordCount
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            string path = "../../../../files/words.txt";
            string soursePath = "../../../../files/text.txt";
            string destinationPath = "../../../../files/result.txt";

            using (StreamReader streamReader = new StreamReader(path))
            {
                string line = streamReader.ReadLine();
                line = line.ToLower();

                while (line != null)
                {
                    if (words.ContainsKey(line) == false)
                    {
                        words.Add(line, 0);
                    }

                    line = streamReader.ReadLine();
                }
            }

            using (StreamReader streamReader = new StreamReader(soursePath))
            {
                string line = streamReader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();
                    Regex regex = new Regex("[A-Za-z]+");

                    foreach (Match word in regex.Matches(line))
                    {
                        if (words.ContainsKey(word.Value))
                        {
                            words[word.Value] += 1;
                        }
                    }

                    line = streamReader.ReadLine();
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(destinationPath))
            {
                foreach (var word in words.OrderByDescending(x => x.Value))
                {
                    streamWriter.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}

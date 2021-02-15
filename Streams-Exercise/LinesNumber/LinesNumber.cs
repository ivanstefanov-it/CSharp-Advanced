using System;
using System.IO;

namespace LinesNumber
{
    class LinesNumber
    {
        static void Main(string[] args)
        {
            string path = "../../../../files/text.txt";
            string destinationPath = "../../../../files/output.txt";

            using (StreamReader streamReader = new StreamReader(path))
            {
                using (StreamWriter streamWriter = new StreamWriter(destinationPath))
                {
                    string line = streamReader.ReadLine();
                    int counter = 0;

                    while (line != null)
                    {
                        streamWriter.WriteLine($"Line{++counter}: {line}");

                        line = streamReader.ReadLine();
                    }
                }
            }
        }
    }
}

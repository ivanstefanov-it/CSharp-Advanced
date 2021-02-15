using System;
using System.IO;

namespace OddLines
{
    class AllLines
    {
        static void Main(string[] args)
        {
            string path = "../../../";
            string fileName = "OddLines.cs";

            path = Path.Combine(path, fileName);

            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                int lineNumber = 0;

                while (line != null)
                {
                    Console.WriteLine($"Line {++lineNumber}: {line}");
                    line = reader.ReadLine();
                }
            }
        }
    }
}

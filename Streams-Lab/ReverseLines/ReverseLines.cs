﻿using System;
using System.Linq;
using System.IO;

namespace ReverseLines
{
    class ReverseLines
    {
        static void Main(string[] args)
        {
            string path = "../../../";
            string inputFileName = "ReverseLines.cs";
            string outputFileName = "Reverse.txt";

            path = Path.Combine(path, inputFileName);

            using (StreamReader reader = new StreamReader(path))
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine(string.Join("", line.Reverse()));

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}

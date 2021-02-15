using System;
using System.Collections.Generic;
using System.IO;

namespace SlicingFile
{
    class SlicingFile
    {
        static List<string> paths;

        static void Main(string[] args)
        {
            paths = new List<string>();

            string sourceFile = "../../../../files/sliceMe.mp4";
            string destinationDirectory = "../../../../files/assembled.mp4";
            int parts = 4;

            Slice(sourceFile, destinationDirectory, parts);
            Assemble(paths, destinationDirectory);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream fileRead = new FileStream(sourceFile, FileMode.Open))
            {
                long totalLenght = fileRead.Length;

                byte[] buffer = new byte[totalLenght / parts];

                for (int i = 0; i < parts; i++)
                {
                    long currentBytes = 0;
                    string fileName = $"{destinationDirectory}Part{i + 1}.mp4";

                    paths.Add(fileName);

                    using (FileStream fileWrite = new FileStream(fileName, FileMode.Create))
                    {
                        while (true)
                        {
                            int bytesCount = fileRead.Read(buffer, 0, buffer.Length);
                            currentBytes += bytesCount;

                            if (currentBytes >= buffer.Length)
                            {
                                break;
                            }
                            if (currentBytes == bytesCount)
                            {
                                break;
                            }
                        }
                        fileWrite.Write(buffer);
                    }
                }
            }
        }

        static void Assemble(List<string> paths, string destinationDirectory)
        {
            byte[] buffer = new byte[1024];

            using (FileStream fileWrite = new FileStream(destinationDirectory, FileMode.Create))
            {
                foreach (var path in paths)
                {
                    using (FileStream readFile = new FileStream(path, FileMode.Open))
                    {
                        while (true)
                        {
                            int bytesCount = readFile.Read(buffer, 0, buffer.Length);

                            if (bytesCount == 0)
                            {
                                break;
                            }

                            fileWrite.Write(buffer);
                        }
                    }
                }
            }
        }
    }
}

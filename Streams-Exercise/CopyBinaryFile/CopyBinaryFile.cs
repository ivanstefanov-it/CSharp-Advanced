using System;
using System.IO;

namespace CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string path = "../../../../files/copyMe.png";
            string destinationPath = "../../../../files/copyMe-copy.png";

            using (FileStream readFile = new FileStream(path, FileMode.Open))
            {
                long size = readFile.Length;
                byte[] buffer = new byte[size];

                readFile.Read(buffer, 0, buffer.Length);

                using (FileStream writeFile = new FileStream(destinationPath, FileMode.Create))
                {
                    writeFile.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}

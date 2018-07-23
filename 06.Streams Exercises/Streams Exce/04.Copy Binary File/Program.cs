using System;
using System.IO;

namespace _04.Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream sourceFail = new FileStream("copyMe.png", FileMode.Open))
            {
                using (FileStream destinationFile = new FileStream("destinationCopy.png", FileMode.Create))
                { 
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        var readBytesCount = sourceFail.Read(buffer, 0, buffer.Length);

                        if (readBytesCount == 0)
                            break;

                        destinationFile.Write(buffer, 0, 4096);
                    }
                }
            }
        }
    }
}

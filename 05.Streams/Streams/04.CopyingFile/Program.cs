using System;
using System.IO;

namespace _04.CopyingFile
{
    class Program
    {
        static void Main(string[] args)
        {
           
            using (var sourceFile = new FileStream("streamImg.jpg", FileMode.Open))
            {
                using (var destinationFail = new FileStream("destinationCopy.jpg", FileMode.Create))
                {

                    byte[] buffer = new byte[4096];

                    while (true)
                    { 
                        var readBytesCount = sourceFile.Read(buffer, 0, buffer.Length);

						if (readBytesCount == 0)
                        break;

                        destinationFail.Write(buffer, 0 ,buffer.Length);
                    }
                }
            }
        }
    }
}

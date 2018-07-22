using System;
using System.IO;
using System.Text;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (StreamReader stream = new StreamReader("Program.cs")) {
                string line = "";
                int count = 0;
                while ((line = stream.ReadLine()) != null) {
                    Console.WriteLine($"Line {++count}: {line}");
                }
            }

            using (StreamWriter writeStream = new StreamWriter("reversed.txt"))
            {
                
                using (StreamReader readStream = new StreamReader("Program.cs"))
                {
                    string line;
                    while ((line = readStream.ReadLine()) != null)
                    {

                        for (int counter = line.Length - 1; counter >= 0; counter--)
                        {
                            writeStream.Write(line[counter]);
                        }
						
                        writeStream.WriteLine();
                    }
                }
            }

            Console.WriteLine();

            string text = "Кирилица";
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream("log.txt", FileMode.Create);

                var bytes = System.Text.Encoding.UTF8.GetBytes(text);

                fileStream.Write(bytes, 0, bytes.Length);   
            }
            finally
            {       
                fileStream.Close();   
            }

            Console.WriteLine();

            using (var sourceFile = new FileStream("froachVSgroves.jpg", FileMode.Open))
            {
                using (var destinationFail = new FileStream("copyImg.jpg", FileMode.Create))
                {                  
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        var readBytesCount = sourceFile.Read(buffer, 0, buffer.Length);

                        if (readBytesCount == 0)
                            break;

                        destinationFail.Write(buffer, 0, readBytesCount);
                    }
                }
            }
           
            string latin = "Hello";
            string cirilic = "Хелло";  

            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(cirilic)))
            {

                for (int i = 0; i <  memoryStream.Length; i++)
                {
                    int currentByte = memoryStream.ReadByte();
                    Console.Write((char)currentByte);
                }
                Console.WriteLine();
            }
        }
    }
}

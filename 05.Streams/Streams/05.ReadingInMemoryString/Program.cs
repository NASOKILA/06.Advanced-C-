using System;
using System.IO;
using System.Text;

namespace _05.ReadingInMemoryString
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string latin = "Hello";
            string cirilic = "Хелло"; 

            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(cirilic)))
            {

                for (int i = 0; i < memoryStream.Length; i++)
                {
                    int currentByte = memoryStream.ReadByte();
                    Console.Write((char)currentByte);
                }
                Console.WriteLine();
            }
        }
    }
}

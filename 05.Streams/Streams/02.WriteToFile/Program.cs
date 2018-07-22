using System;
using System.IO;

namespace _02.WriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {

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
        }
    }
}

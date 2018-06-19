using System;
using System.IO;

namespace _01.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader stream = new StreamReader("text.txt"))
            {
                int lineNumber = 0;

                string line = stream.ReadLine();

                while (line != null)
                {

                    if(lineNumber++ % 2 == 1)
                        Console.WriteLine(line);
                    
                    line = stream.ReadLine();
                }

            }
        }
    }
}

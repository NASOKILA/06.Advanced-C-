using System;
using System.IO;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader stream = new StreamReader("text.txt"))
            {

                int lineNumber = 1;

                string line = string.Empty;
                while ((line = stream.ReadLine()) != null)
                {
                    Console.WriteLine($"Line {lineNumber++}: {line}");
                }

            }
        }
    }
}


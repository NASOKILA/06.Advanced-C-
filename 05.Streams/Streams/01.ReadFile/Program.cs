    using System;
using System.IO;

namespace _01.ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader stream = new StreamReader("Program.cs"))
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

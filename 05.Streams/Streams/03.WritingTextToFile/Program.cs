using System;
using System.IO;

namespace _03.WritingTextToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "Nasko";
            using (FileStream stream = new FileStream("resultFile.txt", FileMode.Create))
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(test);
                stream.Write(bytes, 0, bytes.Length);    
            }

        }
    }
}

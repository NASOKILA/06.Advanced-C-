using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        public static Action<List<string>> Print = (strings) => {

            strings.ForEach(s => Console.WriteLine(s));
        };

        static void Main(string[] args)
        {

            Print(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList());
        }
        
    }
}

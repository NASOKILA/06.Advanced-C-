using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        public static Action<List<string>> PrintResult = (list) => {
            list.ForEach(s => Console.WriteLine($"Sir {s}"));
        };

        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            

            PrintResult(input);

        }
    }
}

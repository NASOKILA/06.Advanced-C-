using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        private static Func<List<int>, int> GetSmallestNumber =
            (list) => list.Min();

        static void Main(string[] args)
        {

            Console.WriteLine(GetSmallestNumber(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToList()));
                
        }
    }
}

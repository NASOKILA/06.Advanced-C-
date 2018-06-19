using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Sort_Even_Numbers
{
    class Program
    {
        private static Func<string, int> parser = (num) => int.Parse(num);

        static void Main(string[] args)
        {

            var nums = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => parser(n) % 2 == 0)
                .OrderBy(n => parser(n))
                .ToList();

            Console.WriteLine(string.Join(", ", nums));

        }
    }
}

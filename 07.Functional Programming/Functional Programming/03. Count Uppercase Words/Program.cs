using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, bool> validate = (str) => Char.IsUpper(str[0]);
            
            Console.ReadLine()
                .Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(s => validate(s))
                .ToList()
                .ForEach(e => Console.WriteLine(e));
            
        }
    }
}

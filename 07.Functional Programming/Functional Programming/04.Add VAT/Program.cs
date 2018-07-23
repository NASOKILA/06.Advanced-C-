using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {  
            Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(e => Console.WriteLine((double.Parse(e) * 1.2).ToString("0.00")));
        }
    }
}

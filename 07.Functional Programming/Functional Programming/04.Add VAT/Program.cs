using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             var nums = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            Func<double, double> getVAT = (n) => n + (n / 5);
            Action<List<double>> formatAndPrint = (n) => n.ForEach(num => Console.WriteLine(getVAT(num).ToString("0.00")));

            formatAndPrint(nums);
             */

            /*
              Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList()
                .ForEach(e => Console.WriteLine((e * 1.2).ToString("0.00")));
             */

            /*
               Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(e => double.Parse(e) * 1.2 )
                .ToList()
                .ForEach(e => Console.WriteLine(e.ToString("0.00")));
             */
             
            Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(e => Console.WriteLine((double.Parse(e) * 1.2).ToString("0.00")));
         

            //NAPRAVIJ GO S MNOGO VARIACII VIJ PO GORE AKO ISKASH
        }
    }
}

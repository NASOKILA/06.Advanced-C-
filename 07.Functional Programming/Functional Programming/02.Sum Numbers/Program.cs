using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _02.Sum_Numbers
{
    class Program
    {

        private static Action<List<int>> result = (numbers) 
            => { Console.WriteLine(numbers.Count); Console.WriteLine(numbers.Sum()); };

        static void Main(string[] args)
        {

            var nums = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToList();

            result(nums);

        }
    }
}

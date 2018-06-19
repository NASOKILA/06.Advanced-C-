using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(n => int.Parse(n))
             .ToList();

            var oddNums = nums.Where(e => Math.Abs(e) % 2 == 1).ToArray();

            var evenNums = nums.Where(e => Math.Abs(e) % 2 == 0).ToArray();

            Array.Sort(evenNums);
            Array.Sort(oddNums);

            nums = join(evenNums, oddNums);
            Print(nums);
        }

        private static Action<List<int>> Print = (nums) => 
            Console.WriteLine(string.Join(" ", nums));
        

        private static List<int> join(int[] evenNums, int[] oddNums)
        {
            List<int> result = new List<int>();

            foreach (var num in evenNums)
                result.Add(num);


            foreach (var num in oddNums)
                result.Add(num);


            return result;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {

        public static Action<List<int>> PrintResult = (list) 
            => Console.WriteLine(string.Join(" ", list));
            
        public static Func<string, Predicate<int>> CreatePredicate =
            (str) => {

                if (str == "odd")
                    return (int x) => Math.Abs(x) % 2 == 1;
                else
                    return (int y) => y % 2 == 0;
            };

        static void Main(string[] args)
        {

            var input = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(n => int.Parse(n))
                 .ToList();

            string command = Console.ReadLine();

            Predicate<int> predicate = CreatePredicate(command);

            var nums = new List<int>();
            fillList(input, predicate, nums);

            PrintResult(nums);
        }

        private static void fillList(List<int> input, Predicate<int> predicate, List<int> nums)
        {
            for (int i = input[0]; i <= input[1]; i++)
            {
                if (predicate.Invoke(i))
                    nums.Add(i);
            }
        }
    }
}
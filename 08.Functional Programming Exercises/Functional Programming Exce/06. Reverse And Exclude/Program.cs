using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {

        public static Func<List<int>, Predicate<int>, List<int>> ReverseList = (list, check) =>
        {
            var newList = new List<int>();
            for (int i = list.Count-1; i >= 0 ; i--)
            {
                int num = list[i];
                if (check(num))
                    newList.Add(list[i]);
            }

            return newList;
        };
        
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
              .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(n => int.Parse(n))
              .ToList();

            int num = int.Parse(Console.ReadLine());

            Predicate<int> check = (n) => n % num != 0;

            List<int> result = ReverseList(nums, check);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

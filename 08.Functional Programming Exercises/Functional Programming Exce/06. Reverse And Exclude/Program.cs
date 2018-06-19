using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {

        //Podavame spisuka i predikata koito suzdadohme koito proverqva dali dadeno chislo se deli na 
        //promenlivata 'num' koqto e podadena ot konzolata
        //funkciqta suzdava nov spisuk i go vrushta kato rezultat.
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

            //vrushta tre ako podadenoto chislo ne se deli na 'num' !!!
            Predicate<int> check = (n) => n % num != 0;

            List<int> result = ReverseList(nums, check);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

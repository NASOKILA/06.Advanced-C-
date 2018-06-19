using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {


        public static Func<Predicate<string>, List<string>, List<string>> Filter = (checker, list) => {

            var newList = new List<string>();
            list.ForEach(e => {

                if (checker(e))
                    newList.Add(e);

            });

            return newList;
        };

        static void Main(string[] args)
        {
            
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .ToList();

            //pravim proverka na duljinata na podadeniqt string 
            Predicate<string> checkLength = (str) => str.Length <= length;

            names = Filter(checkLength, names);

            Console.WriteLine(string.Join("\n", names));
        }

    }
}







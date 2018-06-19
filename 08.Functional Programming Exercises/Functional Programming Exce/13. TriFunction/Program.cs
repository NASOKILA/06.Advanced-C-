using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            FindName(n, names);
        }

        private static Action<int, List<string>> FindName = (n, names) =>
        {
            foreach (var name in names)
            {
                if (function(name, n))
                {
                    Console.WriteLine(name);
                    return;
                }
            }
        };

        public static Func<string, int, bool> function = (name, length) => {

            int sum = 0;

            foreach (var ch in name.ToCharArray())
                sum += ch;
            
            return sum >= length ? true : false;
        };

    }
}

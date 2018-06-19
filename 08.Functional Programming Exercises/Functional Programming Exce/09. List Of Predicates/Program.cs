using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            
            PrintElements(n, dividers);
        }

        private static Action<int, List<int>> PrintElements = (n, dividers) =>
        {
            for (int i = 1; i <= n; i++)
                FindElement(dividers, i);
        };

        private static Action<List<int>, int> FindElement = (dividers, i) =>
        {
            bool isDivisible = true;
            for (int j = dividers.Count - 1; j >= 0; j--)
            {
                //Zapochvame ot posledniq zashtoto e po dobra raktika
                //da zapochvame ot po golqmoto
                int divider = dividers[j];

                if (i % divider != 0)
                {
                    isDivisible = false;
                    break;
                }
            }

            //if the element is divisible by all the numbers we print it on the console
            if (isDivisible)
                Console.Write(i + " ");
        };
    }
}   

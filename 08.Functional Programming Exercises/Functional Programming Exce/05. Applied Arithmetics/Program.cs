using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Action<List<int>> printList = (list) => Console.WriteLine(string.Join(" ", list));

            Func<string, Func<int, int>> GenerateFunc = (str) =>
            {
                if (str == "add")
                    return (num) => ++num;
                else if (str == "subtract")
                    return (num) => --num;
                else
                    return (num) => { return num * 2; };

                //last one is Multiply
            };

            var nums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToList();

            string command = Console.ReadLine();
            
            while (command != "end"){

                if (command == "print")
                    printList(nums);
                else
                {
                    Func<int, int> currentFunc = GenerateFunc(command);

                    nums = nums.Select(e => e = currentFunc(e)).ToList();
                }

                command = Console.ReadLine();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Numbers_with_a_Stack
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> numbers = Console.ReadLine()
                .Split(' ')
                .ToList();

            Stack<string> stack = new Stack<string>(numbers);

            
            while (stack.Count > 0) {
                Console.Write(stack.Pop().ToString() + ' ');
            }
            
        }
    }
}

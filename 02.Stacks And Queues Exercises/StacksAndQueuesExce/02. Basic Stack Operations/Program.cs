using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int elementsToPush = input[0];
            int elementsToPop = input[1];
            int elementToFind = input[2];

            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++) 
                stack.Push(numbers[i]);
            

            for (int i = 0; i < elementsToPop; i++)
                stack.Pop();

            if (stack.Count == 0)
                Console.WriteLine(0);
            else if (stack.Contains(elementToFind))
                Console.WriteLine("true");
            else           
                Console.WriteLine(stack.Min());
            

        }
    }
}

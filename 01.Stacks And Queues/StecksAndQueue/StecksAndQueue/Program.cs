using System;
using System.Collections.Generic;
using System.Linq;

namespace StecksAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(new int[] { 1, 2, 3, 4 });

            int count = stack.Count;
            Console.WriteLine("Count = " + count);

            bool exists = stack.Contains(2); 
            Console.WriteLine("Exists = " + exists);

            int[] array = stack.ToArray(); 
            Console.WriteLine(string.Join(", ", array));

            stack.Pop();
            Console.WriteLine(string.Join(", ", stack));

            stack.Peek();
            Console.WriteLine(string.Join(", ", stack));

            Console.WriteLine("Count = " +  stack.Count);
            stack.Clear(); 
            Console.WriteLine("Count = " +  stack.Count);
 
            Stack<int> stack2 = new Stack<int>();
            Queue<int> queue = new Queue<int>();
        }
    }
}
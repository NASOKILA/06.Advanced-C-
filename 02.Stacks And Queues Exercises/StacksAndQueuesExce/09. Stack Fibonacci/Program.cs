using System;
using System.Collections.Generic;

namespace _09._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);
            
            
            for (int i = 0; i < n; i++) {

                int secondNum = stack.Pop();
                int firstNum = stack.Peek();

                stack.Push(secondNum);
                stack.Push(secondNum + firstNum);
            }
            stack.Pop();
            Console.WriteLine(stack.Peek());
           
        }
    }
}





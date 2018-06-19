using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(' ').Reverse().ToArray();
            //Array.Reverse(input);

            Stack<string> stack = new Stack<string>(input);
            
            while (stack.Count != 1) {

                int firstNum = int.Parse(stack.Peek());
                stack.Pop();
                string sign = stack.Peek();
                stack.Pop();
                int secondNum = int.Parse(stack.Peek());
                stack.Pop();

                int result = 0;
                if (sign == "+")
                    result = firstNum + secondNum;
                else if (sign == "-")
                    result = firstNum - secondNum;
                else if (sign == "/")
                    result = firstNum / secondNum;
                else if (sign == "*")
                    result = firstNum * secondNum;
                
                stack.Push(result.ToString());
                
            }

            Console.WriteLine(stack.Pop());

        }
    }
}



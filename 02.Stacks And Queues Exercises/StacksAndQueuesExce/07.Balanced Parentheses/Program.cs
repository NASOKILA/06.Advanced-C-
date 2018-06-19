using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] input = Console.ReadLine().ToCharArray();

            char[] opened = new[] { '(', '[', '{' };
            char[] closed = new[] { ')', ']', '}' };

            Stack<char> stack = new Stack<char>();
            

            for (int i = 0; i < input.Length; i++)
            {

                char currentElement = input[i];

                if (opened.Contains(currentElement))
                    stack.Push(currentElement);
                else
                {
                    // ) ] }
                    if (stack.Count == 0
                        && (closed.Contains(currentElement)))
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    char lastStackElement = stack.Pop();
                    if (currentElement == closed[0])
                    {
                        if (lastStackElement != opened[0])
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    else if (currentElement == closed[1])
                    {
                        if (lastStackElement != opened[1])
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    else if (currentElement == closed[2])
                    {
                        if (lastStackElement != opened[2])
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }

                }
            }

                Console.WriteLine("YES");    
        }
    }
}














using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> maxElements = new Stack<int>();

            maxElements.Push(int.MinValue);

            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (command[0] == 1){

                    stack.Push(command[1]);

                    //Samo ako chisloto e po golqmo ot poslednoto v maxElements go slagame vutre
                    if (command[1] >= maxElements.Peek())
                        maxElements.Push(command[1]);

                }else if (command[0] == 2){
                    
                    if (maxElements.Peek() == stack.Peek()) {
                        maxElements.Pop();
                    }
                    stack.Pop();
                }
                else if (command[0] == 3) {
                    Console.WriteLine(maxElements.Peek());
                }
                
            }
        }
    }
}
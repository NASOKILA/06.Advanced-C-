using System;
using System.Collections.Generic;

namespace _01.Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            //Stack<char> stack = new Stack<char>(input.toCharArray());
            //Taka slagame charovete ot inputa direktno v staka

            foreach (char ch in input)
                stack.Push(ch);

            //dokato staka ne stane prazen.
            while (stack.Count > 0)
                Console.Write(stack.Pop().ToString());
            //triem elementa no predi tova go printirame
        }
    }
}

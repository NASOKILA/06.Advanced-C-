using System;
using System.Collections.Generic;

namespace _03.Decimal_To_Binary
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                Console.WriteLine(0);
                return;
            }

            //TUK POLZVAME STECK ZASHTOTO NI TRQBVA OBRATNIQ RED INACHE MOJE I DA SE NAPRAVI I BEZ STECK !!!
            Stack<int> stack = new Stack<int>();


            while (input > 0) {

                int reminder = input % 2;
                stack.Push(reminder);
                input = input / 2;

            }

            while (stack.Count > 0)             
                Console.Write(stack.Pop());
            
            

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.SimpleTextEditor
{
    class Program
    {

        static void Main(string[] args)
        {

            int n = Convert.ToInt32(Console.ReadLine());

            Stack<string> oldVersons = new Stack<string>();

            string text = string.Empty;

            oldVersons.Push(text);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                int command = Convert.ToInt32(input[0]);

                if (command == 1){

                    text += input[1];
                    oldVersons.Push(text);

                } else if (command == 2){

                    
                    int length = Convert.ToInt32(input[1]);
                    text = text.Remove(text.Length - length, length);
                    oldVersons.Push(text);

                } else if (command == 3){
                    
                    int index = Convert.ToInt32(input[1]);
                    index--;
                    Console.WriteLine(text[index]);

                }else if (command == 4){
                    
                    oldVersons.Pop();

                    text = string.Empty;
                    text += oldVersons.Peek();
                }
            }
            

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace _04.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stackIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++) {

                char currentElem = input[i];

                if (currentElem == '(')
                    stackIndexes.Push(i); 
				
                if (currentElem == ')'){

                    int openBracketIndex = stackIndexes.Pop(); // vzimame go i go mahame

                    int length = i - openBracketIndex;

                    Console.WriteLine(input.Substring(openBracketIndex, length+1));
                }
            }
        }
    }
}

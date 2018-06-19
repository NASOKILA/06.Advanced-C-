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
                    stackIndexes.Push(i); // vkarvame oziciqta na '(' v steka

                if (currentElem == ')'){

                    //VAJNOOOOOOOOOOOOOOOO !!!!!!!!!!!!!
                    //Vzimame posledniq element vkaran v steka koito e indexa na posledniq '(' element a ne na purviq.
                    int openBracketIndex = stackIndexes.Pop(); // vzimame go i go mahame

                    //Trqbva ni duljinata za da otrejem parcheto:
                    //duljinata e = na tekushtiq index - indexa na otvarqshtata skoba
                    int length = i - openBracketIndex;

                    //rejem i printirame parcheto
                    Console.WriteLine(input.Substring(openBracketIndex, length+1));

                }
            }
        }
    }
}

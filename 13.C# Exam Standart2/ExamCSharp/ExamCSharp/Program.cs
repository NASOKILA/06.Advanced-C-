using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExamCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //REGEXES START

            string text = "This is the text to match with regex for examle!!!";

            string patt = (@"\b\[[^ \<]+\<(\d+)REGEH(\d+)\>\S+\]");
            
            Match match = Regex.Match(text, patt);

            MatchCollection matches = Regex.Matches(text, patt);

            Regex regex = new Regex(patt);
            Match match2 = regex.Match(text);
            MatchCollection matches2 = regex.Matches(text);




            //USE JAGGED ARRAY INSTEAD OF MATRIX
/*

5
x x x x x
x x x x x
x x x x x
x x x x x
x x x x x

 */
            int n = int.Parse(Console.ReadLine());
            char[][] jagged = new char[n][];
            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
               
                jagged[i] = input;
            }

            Console.WriteLine();
            Console.WriteLine("Print it:");
            //PRINT JAGGED ARRAY
            for (int i = 0; i < n; i++)
            {
                var row = jagged[i];
                Console.WriteLine(string.Join(" ",row));
            }

             


        }
    }
}

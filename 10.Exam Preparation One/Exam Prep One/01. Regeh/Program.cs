using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string patt = (@"\b\[[^ \<]+\<(\d+)REGEH(\d+)\>\S+\]");

            string patt2 = @"\<(\d+)REGEH(\d+)\>";

            var checkmatch = Regex.Match(input, patt);

            if (!checkmatch.Success)
                return;

            var matches = Regex.Matches(input, patt2);

            List<int> numbers = new List<int>();

            foreach (Match match in matches)
            {
                numbers.Add(int.Parse(match.Groups[1].Value));
                numbers.Add(int.Parse(match.Groups[2].Value));
            }

            string result = "";

            int realNumber = 0;
            
            foreach (int num in numbers)
            {
                realNumber += num;

                if (input.Length > realNumber)
                {
                    result += input[realNumber];
                   
                }
                    
                else {
                    result += input[(realNumber - input.Length)+1];

                }
            }

            Console.WriteLine(result); 
        }
    }
}

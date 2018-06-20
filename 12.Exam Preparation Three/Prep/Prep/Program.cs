using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Prep
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string patt = "(!|#)[^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\\d)(?<streetNumber>\\d{3})-(?<password>\\d{4}|\\d{6})(?!\\d)[^#!]*?!|(!)[^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\\d)(?<streetNumber>\\d{3})-(?<password>\\d{4}|\\d{6})(?!\\d)[^#!]*?#";

            var regex = new Regex(patt);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = regex.Matches(input);

                //vzimame sredniq ako sa necheten broi matchove
                var match = matches[matches.Count / 2];

                Console.WriteLine($"Go to str. {match.Groups["streetName"]} {match.Groups["streetNumber"]}. Secret pass: { match.Groups["password"]}.");               
                
            }

        }
    }
}

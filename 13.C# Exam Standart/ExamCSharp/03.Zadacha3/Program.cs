using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.Zadacha3
{
    class Program
    {
        static void Main(string[] args)
        {
            //CHECK NOTES


            int n = int.Parse(Console.ReadLine());

            //pravim go na edin string !
            string text = string.Empty;
            for (int i = 0; i < n; i++)
            {

                string input = Console.ReadLine();
                text += input;
            }


            Dictionary<string, int> matchesExtracted = new Dictionary<string, int>();

            
            string patt = (@"\[\D*(\d{3,}\n*)\D*\]|{\D*(\d{3,}\n*)\D*}");
            
            MatchCollection matches = Regex.Matches(text, patt);

            foreach (Match match in matches)
            {
                string numbersTaken = "";
                if (match.Groups[1].Length > 0)
                    numbersTaken = match.Groups[1].Value.ToString();

                if (numbersTaken.Length % 3 == 0 && numbersTaken != "")
                {

                    //proveri dali veche ne sushtestvuva
                    matchesExtracted[numbersTaken] = match.Groups[0].Length;
                    numbersTaken = "";
                }
                if (match.Groups[2].Length > 0)
                    numbersTaken = match.Groups[2].Value.ToString();

                if (numbersTaken.Length % 3 == 0 && numbersTaken != "")
                {
                    //proveri dali veche ne sushtestvuva
                    matchesExtracted[numbersTaken] = match.Groups[0].Length;
                    numbersTaken = "";
                }
                
            }


            string finalResult = "";
            foreach (var item in matchesExtracted)
            {
                List<int> piecesOfThreePerItem = new List<int>();

                int itemLength = item.Key.Length;
                int index = 0;
                //split the minto threes
                while (itemLength >= 3)
                {

                    string currentpairOfThrees = item.Key.Substring(index, 3);
                    index += 3;
                    piecesOfThreePerItem.Add(int.Parse(currentpairOfThrees));

                    itemLength -= 3;
                }


                //Get the actual characters

                foreach (var num in piecesOfThreePerItem)
                {
                    finalResult += (char)(num - item.Value);
                }


                
            }



            Console.WriteLine(finalResult);

        }
    }
}

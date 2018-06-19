using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jaggedOne = new int[n][];
            int[][] jaggedTwo = new int[n][];

            //One
            for (int row = 0; row < n; row++)
            {
                jaggedOne[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            //Two
            for (int row = 0; row < n; row++)
            {
                jaggedTwo[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            

            //reverse the second jaggeed array
            for (int row = 0; row < jaggedTwo.GetLength(0); row++)
                Array.Reverse(jaggedTwo[row]);
            

            //proverqvame dali duljinite sa kato duljnata na purviq red
        
            List<int> totalRowLength = new List<int>();

            for (int row = 0; row < n; row++)
            {
                int jaggedOneRowLength = jaggedOne[row].Length;
                int jaggedTwoRowLength = jaggedTwo[row].Length;
                totalRowLength.Add(jaggedOneRowLength + jaggedTwoRowLength);
            }

            if (totalRowLength.Any(e => e != totalRowLength[0]))
            {
                //Ako ne suvpadat elementite
                int totalLength = 0;
                for (int row = 0; row < n; row++)
                    totalLength += jaggedOne[row].Length + jaggedTwo[row].Length;
                
                Console.WriteLine($"The total number of cells is: {totalLength}");
            }
            else
            {
                for (int row = 0; row < n; row++)
                {
                    Console.Write("[" + string.Join(", ", jaggedOne[row]) + ", ");
                    Console.WriteLine(string.Join(", ", jaggedTwo[row]) + "]");
                }
            }


        }
    }
}

using System;
using System.Linq;

namespace _01.Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int[,] matrix = new int[rows,cols];
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    string piece = (((char)alphabet[row])).ToString() + ((char)alphabet[row + counter]).ToString() + ((char)alphabet[row]).ToString();
                    Console.Write(piece + " ");
                    counter++;
                }
                Console.WriteLine();
                counter = 0;
            }


           

        }
    }
}

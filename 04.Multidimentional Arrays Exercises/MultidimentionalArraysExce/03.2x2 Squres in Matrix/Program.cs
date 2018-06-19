using System;
using System.Linq;

namespace _03._2x2_Squres_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1]; 
            long[,] matrix = new long[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = row[j];
                
            }
        
            /*
            //print just to see
            Console.WriteLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write((char)matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            */
            int matchesCount = 0;
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1]) {

                        matchesCount++;
                    }
                }
                
            }
            
                Console.WriteLine(matchesCount);



        }
    }
}

using System;
using System.Linq;

namespace _2._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            long[,] matrix = new long[n,n];

            for (int i = 0; i < n; i++) {

                long[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i,j] = row[j];
                }

            }

            /*
            //print just to see
            Console.WriteLine();
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
            */

            long leftDiagonalSum = 0;
            int counterRow = 0;
            for (int row = 0; row < n; row++)
            {

                leftDiagonalSum += long.Parse(matrix[row, counterRow].ToString());
                counterRow++;
            }

            long rightDiagonalSum = 0;
            int counter = n-1;
            for (int row = 0; row < n; row++)
            {
                rightDiagonalSum += long.Parse(matrix[row, counter].ToString());
                counter--;
            }
            
            Console.WriteLine(Math.Abs(leftDiagonalSum - rightDiagonalSum));
        }
    }
}

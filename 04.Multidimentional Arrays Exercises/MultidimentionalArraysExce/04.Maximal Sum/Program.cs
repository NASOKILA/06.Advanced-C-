using System;
using System.Linq;

namespace _04.Maximal_Sum
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
                long[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
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
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
            */



            long sumOfMax3x3Square = 0;
            long[,] maxSquare = new long[3, 3];

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {

                    //Take the 3x3 square
                    long currentSquareSum = 0;
                    long[,] square = new long[3, 3];

                    square[0, 0] = long.Parse(matrix[row, col].ToString());
                    square[0, 1] = long.Parse(matrix[row, col+1].ToString());
                    square[0, 2] = long.Parse(matrix[row, col+2].ToString());

                    square[1, 0] = long.Parse(matrix[row+1, col].ToString());
                    square[1, 1] = long.Parse(matrix[row+1, col+1].ToString());
                    square[1, 2] = long.Parse(matrix[row+1, col+2].ToString());

                    square[2, 0] = long.Parse(matrix[row+2, col].ToString());
                    square[2, 1] = long.Parse(matrix[row+2, col+1].ToString());
                    square[2, 2] = long.Parse(matrix[row+2, col+2].ToString());


                    currentSquareSum += long.Parse(matrix[row, col].ToString());
                    currentSquareSum += long.Parse(matrix[row, col + 1].ToString());
                    currentSquareSum += long.Parse(matrix[row, col + 2].ToString());

                    currentSquareSum += long.Parse(matrix[row + 1, col].ToString());
                    currentSquareSum += long.Parse(matrix[row + 1, col + 1].ToString());
                    currentSquareSum += long.Parse(matrix[row + 1, col + 2].ToString());

                    currentSquareSum += long.Parse(matrix[row + 2, col].ToString());
                    currentSquareSum += long.Parse(matrix[row + 2, col + 1].ToString());
                    currentSquareSum += long.Parse(matrix[row + 2, col + 2].ToString());

                    if (currentSquareSum > sumOfMax3x3Square)
                    {
                        sumOfMax3x3Square = currentSquareSum;
                        maxSquare = square;
                    }


                }

            }

            Console.WriteLine("Sum = " + sumOfMax3x3Square);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write( maxSquare[i,j] + " "); 
                }
                Console.WriteLine();
            }



        }
    }
}

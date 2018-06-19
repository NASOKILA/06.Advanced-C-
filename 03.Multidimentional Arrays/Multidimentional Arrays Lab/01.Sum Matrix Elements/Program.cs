using System;
using System.Linq;

namespace _01.Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            int rows = input[0];
            int cols = input[1];
            
            //suzdavam si matricata  REALNO NE NI E NUJNA ZA TAZI ZADACHA NO SEGA TOVA UCHIM.
            int[,] matrix = new int[rows, cols];
            int sum = 0;

            for (int row = 0; row < rows; row++) {

                int[] matrixNums = Console.ReadLine()
                .Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++){
                    matrix[row, col] = matrixNums[col];  //Pulnim si matricata
                    sum += matrixNums[col]; //smqtame si sumata

                }
            }

            Console.WriteLine(matrix.GetLength(0)); // rols
            Console.WriteLine(matrix.GetLength(1)); // cols
            Console.WriteLine(sum);
        }
    }
}

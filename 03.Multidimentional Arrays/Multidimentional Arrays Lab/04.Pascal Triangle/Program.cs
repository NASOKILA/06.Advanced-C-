using System;

namespace _04.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine("1");
                return;
            }

            long[][] pascal = new long[n][];

            for (int i = n-1; i >= 0; i--){
                pascal[i] = new long[i+1];
            }

            pascal[0][0] = 1;
            pascal[1][0] = 1;
            pascal[1][1] = 1;

            for (int row = 2; row < n; row++){

                pascal[row][0] = 1;
                pascal[row][pascal[row].Length - 1] = 1;

                for (int col = 1; col < row; col++)
                    pascal[row][col] = 
                        pascal[row - 1][col] + pascal[row - 1][col - 1];         
            }

            for (int row = 0; row < pascal.Length; row++){

                for (int col = 0; col < pascal[row].Length; col++){
                    Console.Write(pascal[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
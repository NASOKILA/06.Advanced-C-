using System;
using System.Linq;

namespace _03.Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse).ToArray();

            int[][] jagged = new int[3][];

            int[] sizes = new int[3];
            
			foreach (var num in numbers){
                int index = num % 3;
                sizes[Math.Abs(index)]++; 
            }
            
            for (int c = 0; c < jagged.Length; c++){
                jagged[c] = new int[sizes[c]];
            }

            for (int row = 0; row < jagged.Length; row++){ 
                jagged[row] = numbers.Where(n => Math.Abs(n % 3) == row).ToArray();
            }

            for (int row = 0; row < jagged.GetLength(0); row++){
                for (int col = 0; col < jagged[row].Length; col++){
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

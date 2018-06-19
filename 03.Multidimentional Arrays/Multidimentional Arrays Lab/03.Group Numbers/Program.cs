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
            //Pravim si pomoshten masiv NO MOJE I BEZ NEGO !!!!!!!!!!!!!!!!!!!!!!!!
            //Pravim tova za da znaem kakvi da ni budat duljinite na Jagga, gledaiki indexite
            foreach (var num in numbers){
                int index = num % 3;
                sizes[Math.Abs(index)]++; // ako  chisloto % 3 vrusht 1 otiva v 1 index, ako 0 otiva v 0 ako 2 otiva v 2
            }
            
            //kazvame mu kolko duljina da ima na vseki red KTO SI POLZVAME MASIVA    sizes
            //NO MOJE I BEZ TOVA !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            for (int c = 0; c < jagged.Length; c++){
                jagged[c] = new int[sizes[c]];
            }

            //Pulnim mu DIREKTNO REDOVETE KATO FILTRIRAME ELEMENTITE.
            //Polzvame Math.Abs() v sluchai che ima nedorazomenie.
            for (int row = 0; row < jagged.Length; row++){ 
                jagged[row] = numbers.Where(n => Math.Abs(n % 3) == row).ToArray();
            }

            //Printirame
            for (int row = 0; row < jagged.GetLength(0); row++){
                for (int col = 0; col < jagged[row].Length; col++){
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }
            

        }
    }
}

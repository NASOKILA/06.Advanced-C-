using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var knightsIndexesAndAttacks = new Dictionary<int[], int>();


            int kingsCount = 0;

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                var currentRow2 = Console.ReadLine().ToCharArray();
                char[] currentRow = currentRow2.Where(e => e != ' ').ToArray();


                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'K')
                        kingsCount++;
                }
            }

            if (n < 3)
            {
                Console.WriteLine(0);
                return;
            }

            //iterate the matrix
            IterateTheMatrix(n, knightsIndexesAndAttacks, matrix);


            //Remove the most aggressive horse and try again
            //oder dictionary by highest value

            int removedKnights = 0;


            //ako vsichkite sa nuli izlizame

            while (knightsIndexesAndAttacks.Values.Any(e => e != 0))
            {
                var myList = knightsIndexesAndAttacks.ToList();
                myList
                    .Sort((a, b) => b.Value.CompareTo(a.Value));

                //vzimame row i col i mahame ot matricata
                    int row = myList.First().Key.First();
                    int col = myList.First().Key.Last();

                    matrix[row, col] = (char)48;
                    removedKnights++;



                

                knightsIndexesAndAttacks = new Dictionary<int[], int>();
                    //iterate the matrix
                    IterateTheMatrix(n, knightsIndexesAndAttacks, matrix);

                

            }

            Console.WriteLine(removedKnights);


            //Print(matrix);



            /*
8
0K0KKK00
0K00KKKK
00K0000K
KKKKKK0K
K0K0000K
KK00000K
00K0K000
000K00KK

5 
0K0K0
K000K
00K00
K000K
0K0K0



            */

        }

        private static void IterateTheMatrix(int n, Dictionary<int[], int> knightsIndexesAndAttacks, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'K')
                    {

                        int attacks = 0;
                        int[] indexes = new int[] { row, col };


                        if (knightsIndexesAndAttacks.ContainsKey(indexes))
                            attacks = knightsIndexesAndAttacks[indexes];

                        /*
                         Attack types:
                         .1 row+1 col-2
                         .2 row+1 col+2
                         .3 row-1 col-2
                         .4 row-1 col+2

                         .5 row+2 col-1
                         .6 row+2 col+1
                         .7 row-2 col-1
                         .8 row-2 col+1

                         */


                        //Za vseki kon proverqvame za ataki.

                        //GLEDAME DVE NA STRANI I EDNO NA DOLO ILI NA GORE
                        try
                        {

                            char piece = matrix[row + 1, col - 2];
                            if (piece == 'K')
                                attacks++;
                        }
                        catch
                        { }

                        try
                        {

                            char piece = matrix[row + 1, col + 2];
                            if (piece == 'K')
                                attacks++;
                        }
                        catch
                        { }

                        try
                        {
                            char piece = matrix[row - 1, col - 2];
                            if (piece == 'K')
                                attacks++;
                        }
                        catch
                        { }

                        try
                        {

                            char piece = matrix[row - 1, col + 2];
                            if (piece == 'K')
                                attacks++;
                        }
                        catch
                        { }

                        //GLEDAME DVE NA DOLO ILI NA GORE I EDNO NA STRANI
                        try
                        {

                            char piece = matrix[row + 2, col - 1];
                            if (piece == 'K')
                                attacks++;
                        }
                        catch
                        { }

                        try
                        {
                            char piece = matrix[row + 2, col + 1];

                            if (piece == 'K')
                                attacks++;
                        }
                        catch
                        { }
                        try
                        {
                            char piece = matrix[row - 2, col - 1];
                            if (piece == 'K')
                                attacks++;
                        }
                        catch
                        { }
                        try
                        {
                            char piece = matrix[row - 2, col + 1];
                            if (piece == 'K')
                                attacks++;
                        }
                        catch
                        { }
                        knightsIndexesAndAttacks[indexes] = attacks;

                    }

                }

            }
        }

        private static void Print(char[,] matrix)
        {
            Console.WriteLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

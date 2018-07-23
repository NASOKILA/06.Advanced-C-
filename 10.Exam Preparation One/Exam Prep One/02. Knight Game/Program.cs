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

            IterateTheMatrix(n, knightsIndexesAndAttacks, matrix);

            int removedKnights = 0;

            while (knightsIndexesAndAttacks.Values.Any(e => e != 0))
            {
                var myList = knightsIndexesAndAttacks.ToList();
                myList
                    .Sort((a, b) => b.Value.CompareTo(a.Value));

                    int row = myList.First().Key.First();
                    int col = myList.First().Key.Last();

                    matrix[row, col] = (char)48;
                    removedKnights++;

                knightsIndexesAndAttacks = new Dictionary<int[], int>();         
                    IterateTheMatrix(n, knightsIndexesAndAttacks, matrix);
            }

            Console.WriteLine(removedKnights);

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

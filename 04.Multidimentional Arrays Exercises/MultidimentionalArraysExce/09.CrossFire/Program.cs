using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.CrossFire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<List<int>> matrix = new List<List<int>>();

            int rows = dimentions[0];
            int cols = dimentions[1];
            //fill the lists
            int counter = 0;
            for (int row = 0; row < rows; row++)
            {
                List<int> currentRow = new List<int>();

                for (int col = 0; col < cols; col++)
                    currentRow.Add(++counter);

                matrix.Add(currentRow);
            }
 
            //Follow and apply the commands
            string input = Console.ReadLine();
            while (input != "Nuke it from orbit") {

                int[] destroyData = input
                .Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                int rowIndex = destroyData[0];
                int colIndex = destroyData[1];
                int radius = destroyData[2];


                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < matrix[i].Count; j++)
                    {

                        var cell = matrix[i][j];
                        int distance = 0;


                        if (i == rowIndex && j == colIndex)
                        {
                            //delete the elements by using the radius
                           
                            //remove the elements above it
                            for (int ii = 1; ii <= radius; ii++)
                            {
                                try
                                {
                                    matrix[i - ii]
                                        .Remove(matrix[i - ii][j]);
                                }
                                catch { }
                            }

                            //remove elements below it
                            for (int i = 1; i <= radius; i++)
                            {
                                try
                                {
                                    matrix[row + i]
                                        .Remove(matrix[row + i][col]);
                                }
                                catch { }
                            }

                            //remove elements on the left
                            int removedLeftElements = 0;
                            for (int i = 1; i <= radius; i++)
                            {
                                try
                                {
                                    matrix[row]
                                        .Remove(matrix[row][col - i]);
                                    removedLeftElements++;
                                }
                                catch { }
                            }
                            col = col - removedLeftElements;

                            //remove elements on the right + the elements itself

                            for (int i = 1; i <= radius; i++)
                            {
                                try
                                {
                                    matrix[row]
                                        .Remove(matrix[row][col]);
                                    
                                }
                                catch { }
                            }
                            
                            
                        }
                    }
                }



                input = Console.ReadLine();
            }

            //Print
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Count; col++)
                    Console.Write(matrix[row][col] + " ");

                Console.WriteLine();
            }

        }
    }
}

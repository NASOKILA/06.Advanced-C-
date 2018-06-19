using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Rubiks_Matrix
{
    class Program
    {

        private static int[][] matrix = new int[1][];
        private static int rows = 0;
        private static int cols = 0;

        static void Main(string[] args)
        {

            

            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            rows = input[0];
            cols = input[1];
            long[,] matrix = new long[rows, cols];


            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ++counter;
                }
            }



            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {

                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int index = int.Parse(command[0]);
                string direction = command[1];
                long rotations = long.Parse(command[0]);


                //shte mestim cql red nagore ili na dolo
                if (direction == "down" || direction == "up")
                {

                    moveUpOrDown(index, rotations, direction);
                }
                else if (direction == "left" || direction == "right")
                {
                    moveLeftOrRight(index, rotations, direction);
                }
                

                // 1 2 3
                // 4 5 6
                // 7 8 9



            }


            //print just to see
            // matrix
            Console.WriteLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
            

            long[,] initialMatrix = new long[rows, cols];
            int counter2 = 1;
            for (int i = 0; i < initialMatrix.GetLength(0); i++)
            {

                for (int j = 0; j < initialMatrix.GetLength(1); j++)
                {
                    initialMatrix[i, j] = counter2;
                    counter2++;
                }
            }
            

            //print just to see
            //initial matrix
            Console.WriteLine();
            for (int row = 0; row < initialMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < initialMatrix.GetLength(1); col++)
                {
                    Console.Write(initialMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }
            

            //we changd the matrix now lets proceed
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    long changedElement = matrix[r, c];
                    long normalElemnt = initialMatrix[r, c];
                    if (changedElement == normalElemnt)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {

                        for (int r2 = 0; r2 < matrix.GetLength(0); r2++)
                        {
                            for (int c2 = 0; c2 < matrix.GetLength(1); c2++)
                            {
                                
                                if (matrix[r2, c2] == normalElemnt) {
                                    //WE HAVE TO ACTUALLY SWAP THE ELEMENT
                                    matrix[r, c] = normalElemnt;
                                    matrix[r2, c2] = changedElement;
                                    Console.WriteLine($"Swap ({r},{c}) with ({r2}, {c2})");
                                }
                                
                            }
                        }

                    }
                }
            }

        }

        private static void moveLeftOrRight(int line, long moves, string direction)
        {
            int m = (int)(moves % cols);
            var colValues = new Queue<int>();

            if (direction == "right")
            {
                for (int i = cols - 1; i >= 0; i--)
                {
                    colValues.Enqueue(matrix[line][i]);
                }
            }
            else
            {
                for (int i = 0; i < cols; i++)
                {
                    colValues.Enqueue(matrix[line][i]);
                }
            }
            for (int i = 0; i < m; i++)
            {
                int t = colValues.Dequeue();
                colValues.Enqueue(t);
            }
            if (direction == "right")
            {
                for (int i = cols - 1; i >= 0; i--)
                {
                    matrix[line][i] = colValues.Dequeue();
                }
            }
            else
            {
                for (int i = 0; i < cols; i++)
                {
                    matrix[line][i] = colValues.Dequeue();
                }
            }
        }

        private static void moveUpOrDown(int line, long moves, string direction)
        {
            int m = (int)(moves % cols);
            var colValues = new Queue<int>();

            if (direction == "down")
            {
                for (int i = rows - 1; i >= 0; i--)
                {
                    colValues.Enqueue(matrix[i][line]);
                }
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    colValues.Enqueue(matrix[i][line]);
                }
            }
            for (int i = 0; i < m; i++)
            {
                int t = colValues.Dequeue();
                colValues.Enqueue(t);
            }
            if (direction == "down")
            {
                for (int i = rows - 1; i >= 0; i--)
                {
                    matrix[i][line] = colValues.Dequeue();
                }
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    matrix[i][line] = colValues.Dequeue();
                }
            }
        }

    }
}
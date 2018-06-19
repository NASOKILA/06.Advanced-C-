using System;
using System.Linq;

namespace _06.Targer_Practice
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] dimantions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int rows = dimantions[0];
            int cols = dimantions[1];

            string snake = Console.ReadLine();

            int[] shot = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            //TRQBVA DA Q NAPULNIM PO ZIG ZAG
            char[,] matrix = fillMatrix(snake, rows, cols);

            matrix = FireShot(shot, matrix);

             matrix = Gravity(matrix);


            //Print
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                    Console.Write(matrix[row, col]);

                Console.WriteLine();
            }

        }

        private static char[,] Gravity(char[,] matrix)
        {
            //minavame prez vsichki koloni i za vsqka da proverqvame za prazni mesta
            
            for (int col = 0; col < matrix.GetLength(1); col++)
            {

                int emptyRows = 0;
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    if (matrix[row, col] == ' ')
                    {
                        emptyRows++;
                    }
                    else if (emptyRows > 0) {
                        
                        matrix[row + emptyRows, col] = matrix[row, col];
                        matrix[row, col] = ' ';
                    }
                }
            }   

            return matrix;
        }

        private static char[,] FireShot(int[] shot, char[,] matrix)
        {
            int row = shot[0];
            int column = shot[1];
            int radius = shot[2];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    int a = row - r;
                    int b = column - c;
                    double distance = Math.Sqrt(a * a + b * b);

                    if (distance <= radius)
                    {
                        matrix[r, c] = ' ';
                    }
                }
            }

            return matrix;
        }

        private static char[,] fillMatrix(string snake, int rows, int cols)
        {
            var matrix = new char[rows, cols];

            bool isGoingLeft = true;

            int snakeIndex = 0;
            //Sega zapochvame da q pulnim

            for (int row = rows - 1; row >= 0; row--)
            {
                //Ako zapochvame ot lqvo znachi zapohvame ot indexa na maximalniq broi koloni
                //Inache  zapochvame ot index 0
                int index = isGoingLeft ? matrix.GetLength(1) - 1 : 0;

                //Ako otivame nalqvo shte e -1 a ako otivame na dqsno shte e ravno na 1
                int increment = isGoingLeft ? -1 : 1;
                
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, index] = snake[snakeIndex++];
                    
                    if (snakeIndex >= snake.Length)
                        snakeIndex = 0;

                    index += increment;
                }

                //Kato stignem kraq na reda se obrushtame na drugata strana.
                isGoingLeft = !isGoingLeft;
            }

            return matrix;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('(').ToArray();
            
            int rotation = int.Parse(input[1].Substring(0, input[1].Length - 1));
            //Console.WriteLine(rotation);

            List<string> commands = new List<string>();
            string command = Console.ReadLine();

            int matrixRows = 0;
            while (command != "END") {

                commands.Add(command);
                matrixRows++;
                command = Console.ReadLine();
            }

            int matrixColumns = commands.OrderByDescending(c => c.Length).First().Length;
            
            //create and fill the matrix
            char[,] matrix = new char[matrixRows, matrixColumns];
            int column = -1;
            for(int row = 0; row < commands.Count; row++){

                foreach (char ch in commands[row])
                    matrix[row, ++column] = ch;

                column = -1;
                
            }


            //VIJ KAK DA SMQTASH ROTATIONA
           
            //rotate
            if (rotation == 90 || rotation % 360 == 90)
            {
                //                                rows           cols
                char[,] rotatedMatrix = new char[matrixColumns, matrixRows];
                commands.Reverse();


                int col = 0;
                for (int i = 0; i < rotatedMatrix.GetLength(1); i++) // do 3
                {
                    string elementToMove = commands[i];

                    int index = 0;
                    for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
                    {

                        if (row >= elementToMove.Length)
                            break;

                        char letter = (char)elementToMove[index++];


                        rotatedMatrix[row, col] = letter;
                    }

                    col++;
                }

                //print final matrix
                for (int i = 0; i < rotatedMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < rotatedMatrix.GetLength(1); j++)
                    {
                        Console.Write(rotatedMatrix[i, j]);
                    }
                    Console.WriteLine();
                }

            }
            else if (rotation == 180 || rotation % 360 == 180)
            {
                char[,] rotatedMatrix = new char[matrixRows, matrixColumns];
                commands.Reverse();

                for (int i = 0; i < rotatedMatrix.GetLength(0); i++)
                {

                    string reverseElement = commands[i];

                    int index = 0;
                    for (int j = rotatedMatrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (index >= reverseElement.Length)
                            break;
                        rotatedMatrix[i, j] = reverseElement[index++];
                    }

                }


                //print final matrix
                for (int i = 0; i < rotatedMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < rotatedMatrix.GetLength(1); j++)
                    {
                        Console.Write(rotatedMatrix[i, j]);
                    }
                    Console.WriteLine();
                }

            }
            else if (rotation == 270 || rotation % 360 == 270)
            {

                char[,] rotatedMatrix = new char[matrixColumns, matrixRows];



                int col = 0;
                for (int i = 0; i < rotatedMatrix.GetLength(1); i++) // do 3
                {
                    string elementToMove = commands[i];

                    int index = 0;
                    for (int row = rotatedMatrix.GetLength(0) - 1; row >= 0; row--)
                    {

                        if (index >= elementToMove.Length)
                            break;

                        char letter = (char)elementToMove[index++];
                        rotatedMatrix[row, col] = letter;
                    }

                    col++;
                }


                //print final matrix
                for (int i = 0; i < rotatedMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < rotatedMatrix.GetLength(1); j++)
                    {
                        Console.Write(rotatedMatrix[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else if (rotation == 0 || rotation == 360 || rotation % 360 == 0)
            {
                //print final matrix
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j]);
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}

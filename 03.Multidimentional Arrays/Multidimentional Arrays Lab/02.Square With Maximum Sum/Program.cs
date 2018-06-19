using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                .Split(new char[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //Pravim matricata
            int[,] matrix = new int[input[0], input[1]];

            //Pulnim matricata
            for (int row = 0; row < matrix.GetLength(0); row++) {

                int[] matrixRow = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


                for (int col = 0; col < matrix.GetLength(1); col++){
                    matrix[row, col] = matrixRow[col];
                }
            }

            //printirame kuba s nai golqma suma i sumata mu
            int maxSumOfCube = 0;
            Queue<int> cubeWithMaxSumIndexes = new Queue<int>();

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    int currentCubeSum = matrix[row, col] + matrix[row, col + 1] 
                        + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentCubeSum > maxSumOfCube) {

                        maxSumOfCube = currentCubeSum;

                        //Trqbva da zapazim indexite na cuba s nai golqmata suma :

                        //purvo chistim opashkata
                        cubeWithMaxSumIndexes.Clear();

                        //x1, y1
                        cubeWithMaxSumIndexes.Enqueue(matrix[row, col]);
                        cubeWithMaxSumIndexes.Enqueue(matrix[row, col + 1]);
                        
                        //x2, y2
                        cubeWithMaxSumIndexes.Enqueue(matrix[row + 1 , col]);
                        cubeWithMaxSumIndexes.Enqueue(matrix[row + 1, col + 1]);

                    }
                }
            }

            Console.WriteLine(cubeWithMaxSumIndexes.Dequeue() + " " + cubeWithMaxSumIndexes.Dequeue());
            Console.WriteLine(cubeWithMaxSumIndexes.Dequeue() + " " + cubeWithMaxSumIndexes.Dequeue());
            Console.WriteLine(maxSumOfCube);
        }
    }
}

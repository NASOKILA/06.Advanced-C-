

namespace Multidimentional_Arrays_Lab
{
    using System;
    using System.Linq;

    class Program
    {
        
        static void Main(string[] args)
        {
            int[,] intMatrix;  

            float[,] floatMatrix; 

            string[,,] stringCube;

            int[,] intMatrix2 = new int[3, 4]; 

            float[,] floatMatrix2 = new float[8, 2]; 

            string[,,] stringCube2 = new string[5, 5, 5];

            int[,] intMatrix3 = {     
                { 1, 2, 3, 4},
                { 5, 6, 7, 8}
            };

            int im3 = intMatrix3[0, 3];
            Console.WriteLine(im3);

            float[,] floatMatrix3 = {
                { 2.5f, 6.12f, 65.23f, 5.111f},
                { 2.12f, 78.11f, 43.66f, 453.1f}
            };

            float f3 = floatMatrix3[1, 2];
            Console.WriteLine(f3);

            string[,,] stringMatrix3 = {
                {
                    { "a1","a2","a3","a4","a5"},
                    { "a6","a7","a8","a9","a10"}
                },
                {
                    { "b1","b2","b3","b4","b5"},
                    { "b6","b7","b8","b9","b10"}
                },
                {
                    { "c1","c2","c3","c4","c5"},
                    { "c6","c7","c8","c9","c10"}
                }
            };
           
            string sm3 = stringMatrix3[1, 0, 3];
            Console.WriteLine(sm3); 

            sm3 = "b555";
            Console.WriteLine(sm3); 

            Console.WriteLine();
            Console.WriteLine("Print Matrix:");

            int[,] matrixToPrint = {
                {1, 2, 3, 4, 5},
                {6, 7, 8, 9, 10},
                {11, 12, 13, 14, 15}
            };

            for (int row = 0; row < matrixToPrint.GetLength(0); row++) {

                for (int col = 0; col < matrixToPrint.GetLength(1); col++)
                {
                    Console.Write(matrixToPrint[row,col] + " ");
                }
				
                Console.WriteLine();
            }

            Console.WriteLine();
			
            Console.WriteLine("Print 3D Cube :");
			
            int[,,] cube3d = {
                {{1,2,3}, {4,5,6}, {7,8,9}},
                {{10,11,12}, {13,14,15},{16,17,18}},
                {{19,20,21},{22,23,24},{25,26,27}}
            };

            for (int row = 0; row < cube3d.GetLength(0); row++)
            {
                for (int col = 0; col < cube3d.GetLength(1); col++)
                {
                    for (int elem = 0; elem < cube3d.GetLength(2); elem++)
                    {
                        Console.Write(cube3d[row, col, elem] + " ");
                    }
					
                    Console.Write(" ");
                }
				
                Console.WriteLine();
            }


            Console.WriteLine();
			
            Console.WriteLine("Jagged Arrays:");
            
            int[][] jagged = new int[3][];
			
            jagged[0] = new int[3];
            jagged[1] = new int[2];
            jagged[2] = new int[1];

            Console.WriteLine(jagged[0][0] = 1);
            Console.WriteLine(jagged[0][1] = 2);
            Console.WriteLine(jagged[0][2] = 3);
            
            Console.WriteLine(jagged[1][0] = 4);
            Console.WriteLine(jagged[1][1] = 5);
            
            Console.WriteLine(jagged[2][0] = 6);

            Console.WriteLine();
            
            int[][] jaggedArray = new int[3][];

            for (int row = 0; row < 3; row++) {
                Console.WriteLine("Write some numbers separated by ',' to fill one of the rows of the Jagged array :");
                jaggedArray[row] = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            }

            Console.WriteLine();
            Console.WriteLine("Print jagged array:");
            for (int row = 0; row < jaggedArray.GetLength(0); row++){
                for (int col = 0; col < jaggedArray[row].Length; col++){
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Linq;

namespace _02.Zadacha2
{
    class Program
    {
        static void Main(string[] args)
        {
            //CHECK NOTES

            int n = int.Parse(Console.ReadLine());
            char[][] jagged = new char[n][];
            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                jagged[i] = input;
            }

            char[] turns = Console.ReadLine().ToCharArray();


            foreach (var turn in turns)
            {

                //firet MOVE THE enemies
                for (int i = 0; i < n; i++)
                {
                    var row = jagged[i];




                    //check if sam is on the same row as nikolay
                    if (jagged[i].Contains('N') && jagged[i].Contains('S'))
                    {
                        Console.WriteLine("Nikoladze killed!");


                        //get index of nicolai
                        int nikolayindex = 0;

                        for (int jjj = 0; jjj < row.Length; jjj++)
                        {
                            int item2 = jagged[i][jjj];
                            if (item2 == 'N')
                            {
                                nikolayindex = jjj;
                                break;
                            }

                        }


                        jagged[i][nikolayindex] = 'X';

                        for (int r = 0; r < n; r++)
                        {
                            var rowToPrint = jagged[r];
                            Console.WriteLine(rowToPrint);
                        }
                        return;

                    }


                    for (int j = 0; j < row.Length; j++)
                    {
                        
                        char item = jagged[i][j];
                        //right
                        if (item == 'b')
                        {

                            //check if its on the edje

                            try
                            {
                                jagged[i][j] = '.';
                                jagged[i][j + 1] = 'b';
                            }
                            catch
                            {
                                jagged[i][j] = 'd';
                            }
                            break;
                        }
                        //left
                        else if (item == 'd')
                        {


                            

                            if (jagged[i][0] == 'd')
                                jagged[i][0] = 'b';
                            else
                            {

                                jagged[i][j] = '.';
                                jagged[i][j - 1] = 'd';

                            }


                            break;
                        }


                    }

                }

                //Sam moves

                if (turn == 'U')
                {

                    for (int i = 0; i < n; i++)
                    {
                        var row = jagged[i];
                        for (int j = 0; j < row.Length; j++)
                        {
                            if (jagged[i][j] == 'S')
                            {

                                //sam automatically kills an enemy when he steps on it

                                

                              

                                //Check if SAM is killed by an enemy
                                
                                if (jagged[i].Contains('d'))
                                {


                                    //get enemy column
                                    int enemyColumn = -1;

                                    //get index of the enemy
                                    for (int ii = 0; ii < jagged[i].Length; ii++)
                                    {
                                        if (jagged[i][ii] == 'd')
                                        {
                                            enemyColumn = ii;
                                            break;
                                        }

                                    }


                                    if (j < enemyColumn)
                                    {
                                        Console.WriteLine($"Sam died at {i}, {j}”");

                                        jagged[i][j] = 'X';
                                        //PRINT JAGGED ARRAY
                                        for (int r = 0; r < n; r++)
                                        {
                                            var rowToPrint = jagged[r];
                                            Console.WriteLine(rowToPrint);
                                        }
                                        return;
                                    }


                                }


                                if (jagged[i].Contains('b'))
                                {
                                    int enemyColumn = 1111111;

                                    for (int ii = 0; ii < jagged[i].Length; ii++)
                                    {
                                        if (jagged[i][ii] == 'b')
                                        {
                                            enemyColumn = ii;
                                            break;
                                        }

                                    }

                                    if (enemyColumn < j)
                                    {
                                        Console.WriteLine($"Sam died at {i}, {j}");

                                        jagged[i][j] = 'X';
                                        //PRINT JAGGED ARRAY
                                        for (int r = 0; r < n; r++)
                                        {
                                            var rowToPrint = jagged[r];
                                            Console.WriteLine(rowToPrint);
                                        }
                                        return;
                                    }
                                }

                             
                                //NAMIRAME SAM
                                jagged[i][j] = '.';
                                jagged[i - 1][j] = 'S';


                                //check if sam is on the same row as nikolay
                                if (jagged[i - 1].Contains('N') && jagged[i - 1].Contains('S'))
                                {
                                    Console.WriteLine("Nikoladze killed!");


                                    //get index of nicolai
                                    int nikolayindex = 0;

                                    for (int jjj = 0; jjj < row.Length; jjj++)
                                    {
                                        int item2 = jagged[i - 1][jjj];
                                        if (item2 == 'N')
                                        {
                                            nikolayindex = jjj;
                                            break;
                                        }

                                    }


                                    jagged[i - 1][nikolayindex] = 'X';

                                    for (int r = 0; r < n; r++)
                                    {
                                        var rowToPrint = jagged[r];
                                        Console.WriteLine(rowToPrint);
                                    }
                                    return;

                                }





                                break;
                            }

                        }
                    }

                }
                else if (turn == 'D')
                {

                    //namirame sam i go dvijim na dolo
                    for (int i = 0; i < n; i++)
                    {
                        var row = jagged[i];
                        bool samMovedDown = false;
                        for (int j = 0; j < row.Length; j++)
                        {
                            if (jagged[i][j] == 'S')
                            {
                                jagged[i][j] = '.';
                                jagged[i+1][j] = 'S';
                                samMovedDown = true;
                                break;
                            }
                        }



                        //check if sam is on the same row as nikolay
                        if (jagged[i+1].Contains('N') && jagged[i+1].Contains('S'))
                        {
                            Console.WriteLine("Nikoladze killed!");


                            //get index of nicolai
                            int nikolayindex = 0;

                            for (int jjj = 0; jjj < row.Length; jjj++)
                            {
                                int item2 = jagged[i+1][jjj];
                                if (item2 == 'N')
                                {
                                    nikolayindex = jjj;
                                    break;
                                }

                            }


                            jagged[i+1][nikolayindex] = 'X';

                            for (int r = 0; r < n; r++)
                            {
                                var rowToPrint = jagged[r];
                                Console.WriteLine(rowToPrint);
                            }
                            return;

                        }



                        if (samMovedDown)
                            break;
                    }
                }
                else if (turn == 'L')
                {
                    for (int i = 0; i < n; i++)
                    {
                        var row = jagged[i];
                        for (int j = 0; j < row.Length; j++)
                        {
                            if (jagged[i][j] == 'S')
                            {
                                jagged[i][j] = '.';
                                jagged[i][j - 1] = 'S';
                                break;
                            }
                        }
                    }

                }
                else if (turn == 'R')
                {
                    for (int i = 0; i < n; i++)
                    {
                        var row = jagged[i];
                        for (int j = 0; j < row.Length; j++)
                        {
                            if (jagged[i][j] == 'S')
                            {
                                jagged[i][j] = '.';
                                jagged[i][j + 1] = 'S';
                                break;
                            }
                        }
                    }

                }
                else if (turn == 'W')
                {
                    //ne pravim nishto
                }




                
            }

          

        }
    }
}
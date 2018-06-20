using System;
using System.Linq;

namespace _01.Dangerous_Floor
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] jagged = new char[8][];
            for (int i = 0; i < 8; i++)
            {
                char[] input = Console.ReadLine().Split(new string[] {","},StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                jagged[i] = input;
            }

            string[] command = Console.ReadLine().Split(new string[] { "-" },StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (command[0] != "END")
            {

                char piece = command[0].First();

                int currentRow = int.Parse(command[0].Skip(1).First().ToString());
                int currentCol = int.Parse(command[0].Skip(2).First().ToString());

                int finalRow = int.Parse(command[1].First().ToString());
                int finalCol = int.Parse(command[1].Skip(1).First().ToString());


                if (jagged[currentRow][currentCol] != piece)
                {
                    //piece is not there
                    Console.WriteLine("There is no such a piece!");
                    command = Console.ReadLine().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    continue;
                }

                //check if its out of the board
                if (finalRow > 7 || finalCol > 7)
                {
                    Console.WriteLine("Move go out of board!");
                    command = Console.ReadLine().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    continue;
                }

                
                //if we want to move a piece in the same position
                if (currentRow == finalRow && currentCol == finalCol)
                {
                    Console.WriteLine("Invalid move!");
                    command = Console.ReadLine().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    continue;
                }
                

                //Check if the piece can move there

                if (piece == 'K')
                {
                    if ((finalRow == currentRow - 1 || finalRow == currentRow + 1 || finalRow == currentRow)
                        && (finalCol == currentCol - 1 || finalCol == currentCol + 1 || finalCol == currentCol))
                    {
                        //mestim figurata i slagame x na predishnata i poziciq
                        jagged[currentRow][currentCol] = 'x';
                        jagged[finalRow][finalCol] = piece;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (piece == 'R')
                {
                    if (finalRow == currentRow || finalCol == currentCol)
                    {
                        jagged[currentRow][currentCol] = 'x';
                        jagged[finalRow][finalCol] = piece;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }

                }
                else if (piece == 'B')
                {
                    if (((finalRow == currentRow - 1 && finalCol == currentCol - 1)
                        || (finalRow == currentRow - 2 && finalCol == currentCol - 2)
                        || (finalRow == currentRow - 3 && finalCol == currentCol - 3)
                        || (finalRow == currentRow - 4 && finalCol == currentCol - 4)
                        || (finalRow == currentRow - 5 && finalCol == currentCol - 5)
                        || (finalRow == currentRow - 6 && finalCol == currentCol - 6)
                        )|| 
                        ((finalRow == currentRow - 1 && finalCol == currentCol + 1)
                        || (finalRow == currentRow - 2 && finalCol == currentCol + 2)
                        || (finalRow == currentRow - 3 && finalCol == currentCol + 3)
                        || (finalRow == currentRow - 4 && finalCol == currentCol + 4)
                        || (finalRow == currentRow - 5 && finalCol == currentCol + 5)
                        || (finalRow == currentRow - 6 && finalCol == currentCol + 6)
                        )|| 
                        ((finalRow == currentRow + 1 && finalCol == currentCol - 1)
                        || (finalRow == currentRow + 2 && finalCol == currentCol - 2)
                        || (finalRow == currentRow + 3 && finalCol == currentCol - 3)
                        || (finalRow == currentRow + 4 && finalCol == currentCol - 4)
                        || (finalRow == currentRow + 5 && finalCol == currentCol - 5)
                        || (finalRow == currentRow + 6 && finalCol == currentCol - 6)
                        )|| 
                        ((finalRow == currentRow + 1 && finalCol == currentCol + 1)
                        || (finalRow == currentRow + 2 && finalCol == currentCol + 2)
                        || (finalRow == currentRow + 3 && finalCol == currentCol + 3)
                        || (finalRow == currentRow + 4 && finalCol == currentCol + 4)
                        || (finalRow == currentRow + 5 && finalCol == currentCol + 5)
                        || (finalRow == currentRow + 6 && finalCol == currentCol + 6)))
                    {
                        jagged[currentRow][currentCol] = 'x';
                        jagged[finalRow][finalCol] = piece;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                        
                }
                else if (piece == 'Q')
                {

                    if ((finalRow == currentRow || finalCol == currentCol)
                        || ((finalRow == currentRow - 1 && finalCol == currentCol - 1)
                        || (finalRow == currentRow - 2 && finalCol == currentCol - 2)
                        || (finalRow == currentRow - 3 && finalCol == currentCol - 3)
                        || (finalRow == currentRow - 4 && finalCol == currentCol - 4)
                        || (finalRow == currentRow - 5 && finalCol == currentCol - 5)
                        || (finalRow == currentRow - 6 && finalCol == currentCol - 6)
                        ) ||
                        ((finalRow == currentRow - 1 && finalCol == currentCol + 1)
                        || (finalRow == currentRow - 2 && finalCol == currentCol + 2)
                        || (finalRow == currentRow - 3 && finalCol == currentCol + 3)
                        || (finalRow == currentRow - 4 && finalCol == currentCol + 4)
                        || (finalRow == currentRow - 5 && finalCol == currentCol + 5)
                        || (finalRow == currentRow - 6 && finalCol == currentCol + 6)
                        ) ||
                        ((finalRow == currentRow + 1 && finalCol == currentCol - 1)
                        || (finalRow == currentRow + 2 && finalCol == currentCol - 2)
                        || (finalRow == currentRow + 3 && finalCol == currentCol - 3)
                        || (finalRow == currentRow + 4 && finalCol == currentCol - 4)
                        || (finalRow == currentRow + 5 && finalCol == currentCol - 5)
                        || (finalRow == currentRow + 6 && finalCol == currentCol - 6)
                        ) ||
                        ((finalRow == currentRow + 1 && finalCol == currentCol + 1)
                        || (finalRow == currentRow + 2 && finalCol == currentCol + 2)
                        || (finalRow == currentRow + 3 && finalCol == currentCol + 3)
                        || (finalRow == currentRow + 4 && finalCol == currentCol + 4)
                        || (finalRow == currentRow + 5 && finalCol == currentCol + 5)
                        || (finalRow == currentRow + 6 && finalCol == currentCol + 6))
                        )
                    {
                        jagged[currentRow][currentCol] = 'x';
                        jagged[finalRow][finalCol] = piece;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (piece == 'P')
                {
                    if (finalRow == currentRow -1 && finalCol == currentCol)
                    {
                        //mestim figurata i slagame x na predishnata i poziciq
                        jagged[currentRow][currentCol] = 'x';
                        jagged[finalRow][finalCol] = piece;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }



                command = Console.ReadLine().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            



        }
    }
}

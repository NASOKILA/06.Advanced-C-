using System;
using System.Collections.Generic;

namespace _06.Traffic_Light
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
 
            Queue<string> queue = new Queue<string>();

            int carsPassed = 0;
            while (command != "end") {

                if (command == "green")
                {

                    int carsToPass = Math.Min(n, queue.Count);
                    for(int i = 0; i < carsToPass; i++){

                        carsPassed++;
                        Console.WriteLine(queue.Dequeue() + " passed!");
                    }  
                }
               else
                queue.Enqueue(command);


                command = Console.ReadLine();
            }
            

            Console.WriteLine(carsPassed + " cars passed the crossroads.");

        }
    }
}

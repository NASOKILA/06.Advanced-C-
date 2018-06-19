using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //Opashka ot int masivi
            var queue = new Queue<int[]>();


            //Pulnim si opashkata s vsichki pompi
            for (int i = 0; i < n; i++)
            {
                int[] pompInfo = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(pompInfo);
            }

            
                //Proverqvame vsichki pompi edna po edna
                for (int start = 0; start < n - 1; start++)
                {
                    //gorivoto zapochva ot 0
                    int fuel = 0;
                    bool isSolution = true;

                    for (int pumpsPassed = 0; pumpsPassed < n; pumpsPassed++)
                    {

                        // vzimame purvata vkarana pompa ot opashkata i q vadim
                        int[] currentPomp = queue.Dequeue();
                        int fuelAmount = currentPomp[0];
                        int distanceUntillNextPomp = currentPomp[1];

                        queue.Enqueue(currentPomp);

                        //zapisvame presmetnatoto gorivo
                        fuel += fuelAmount - distanceUntillNextPomp;

                        if (fuel < 0)
                        {
                            start += pumpsPassed;
                            isSolution = false;
                            break;
                        }
                    }

                    if (isSolution) {
                        Console.WriteLine(start);
                        return;
                    }
                }
            
        }
    }
}

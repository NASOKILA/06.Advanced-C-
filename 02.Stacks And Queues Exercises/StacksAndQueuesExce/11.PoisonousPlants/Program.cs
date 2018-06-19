using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = Convert.ToInt32(Console.ReadLine());

            List<int> plantsInput = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int days = 0;

            Queue<int> deathPlants = new Queue<int>();

            while (true) {

                

                for (int i = 0; i < plantsInput.Count - 1; i++)
                {
                    int currentPlant = plantsInput[i];
                    int plantOnTheRight = plantsInput[i + 1];

                    if (plantOnTheRight > currentPlant){
                        deathPlants.Enqueue(plantOnTheRight);
                    }   
                }

                if (deathPlants.Count == 0)
                    break;

                plantsInput = removePlants(plantsInput, deathPlants);
                days++;
            }

            Console.WriteLine(days);
        }

        private static List<int> removePlants(List<int> plantsInput, Queue<int> deathPlants)
        {
            while (deathPlants.Count > 0){
                plantsInput.Remove(deathPlants.Dequeue());
            }

            return plantsInput;
        }

    }
}

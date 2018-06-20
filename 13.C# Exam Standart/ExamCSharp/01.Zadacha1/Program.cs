using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Zadacha1
{
    class Program
    {
        static void Main(string[] args)
        {

            //CHECK NOTES

            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());

            int[] bulletsIndex = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] locksIndex = Console.ReadLine()
               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();

            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Queue<int> bullets = new Queue<int>(bulletsIndex.Reverse());

            Queue<int> locks = new Queue<int>(locksIndex);





            int bulletCost = 0;
            int bullersUsed = 0;
            
            //locks front to back
            for (int i = 0; i < locks.Count; i++)
            {
                int currentLock = locks.Peek();

                //bullets back to front
                for (int j = 0; j < bullets.Count; j++)
                {
                    

                    int currentBullet = bullets.Dequeue();
                    bullersUsed++;
                    bulletCost += priceOfBullet;
                    
                    //If the bullet has a smaller or equal size to the current lock, print “Bang!”, then remove the lock. 
                    if (currentLock >= currentBullet)
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                        i--;

                        if (bullersUsed == sizeOfGunBarrel && bullets.Count > 0)
                        {
                            Console.WriteLine("Reloading!");
                            bullersUsed = 0;
                        }
                        break;
                    }
                    else 
                        Console.WriteLine("Ping!");

                    if (bullersUsed == sizeOfGunBarrel && bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        bullersUsed = 0;
                    }

                    

                }

            }


            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int earned = valueOfIntelligence - bulletCost;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earned}");
            }

        }
    }
}

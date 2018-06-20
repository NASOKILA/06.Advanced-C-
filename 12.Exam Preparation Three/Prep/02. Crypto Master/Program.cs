using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            var safeNumbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            int maxSequence = 0;

            //pravim cikul za vsichki stupki
            for (int step = 1; step < safeNumbers.Length; step++)
            {
                //vzimame si elementa
                for (int i = 0; i < safeNumbers.Length; i++)
                {
                    int currentIndex = i;
                    int nextIndex = (i + step) % safeNumbers.Length;
                    int currentSequence = 0;

                    //proverqvame dali tekushtoto chislo e po malko ot sledvashtoto kato smqtame stupkata
                    while(safeNumbers[currentIndex] < safeNumbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % safeNumbers.Length;
                        currentSequence++;
                    }

                    if (currentSequence > maxSequence)
                        maxSequence = currentSequence;

                    
                }
            }
            Console.WriteLine(++maxSequence);

            
        }
    }
}

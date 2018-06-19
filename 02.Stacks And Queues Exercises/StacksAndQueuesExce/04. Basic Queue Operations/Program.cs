using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int elementsToPush = input[0];
            int elementsToPop = input[1];
            int elementToFind = input[2];

            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < elementsToPush; i++)
                queue.Enqueue(numbers[i]);


            for (int i = 0; i < elementsToPop; i++)
                queue.Dequeue();

            if (queue.Count == 0)
                Console.WriteLine(0);
            else if (queue.Contains(elementToFind))
                Console.WriteLine("true");
            else
                Console.WriteLine(queue.Min());

        }
    }
}

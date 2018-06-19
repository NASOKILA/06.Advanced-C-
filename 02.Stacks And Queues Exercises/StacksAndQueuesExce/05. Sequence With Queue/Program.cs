using System;
using System.Collections.Generic;

namespace _05._Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<long> queue = new Queue<long>();
            Queue<long> realNumbers = new Queue<long>();

            long s1 = long.Parse(Console.ReadLine());

            queue.Enqueue(s1);
            realNumbers.Enqueue(s1);

            while (true)
            {

                realNumbers.Enqueue(queue.Peek() + 1);
                realNumbers.Enqueue((2 * queue.Peek()) + 1);
                realNumbers.Enqueue(queue.Peek() + 2);

                queue.Enqueue(queue.Peek() + 1);
                queue.Enqueue((2 * queue.Peek()) + 1);
                queue.Enqueue(queue.Peek() + 2);

                queue.Dequeue(); // mahame predishnoto

                if (realNumbers.Count >= 50)
                    break;
            }

            for (long i = 0; i < 50; i++)
                Console.Write(realNumbers.Dequeue().ToString() + ' ');

        }
    }
}

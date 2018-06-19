using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Hot_Potatoe
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> children = Console.ReadLine()
                .Split(' ')
                .ToList();
            
            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(children);

            while (queue.Count != 1){

                for (int i = 1; i < n; i++)
                       queue.Enqueue(queue.Dequeue()); //MAHAME PURVIQ I GO DOBAVQNE NAKRAQ

                //Sled kato go napravim 'n-1' puti, na n-tiq put mahame posledniq i produljavame
                Console.WriteLine("Removed " + queue.Dequeue());
            }

            //Kogato ostane samo edin chovek go printirame
            Console.WriteLine("Last is " + queue.Dequeue());
            
        }
    }
}

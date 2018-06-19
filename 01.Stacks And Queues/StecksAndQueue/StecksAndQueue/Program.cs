using System;
using System.Collections.Generic;
using System.Linq;

namespace StecksAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(new int[] { 1, 2, 3, 4 });

            int count = stack.Count;// proverqvame kolko mu e broq
            Console.WriteLine("Count = " + count);

            bool exists = stack.Contains(2); //proverqvame dali sudurja '2'
            Console.WriteLine("Exists = " + exists);

            int[] array = stack.ToArray(); //prevrushta go na string
            Console.WriteLine(string.Join(", ", array));

            //Sus pop() triem samo nai gorniq element !!!
            stack.Pop();
            Console.WriteLine(string.Join(", ", stack));

            //Sus peek() samo vzimame nai gorniq element BEZ DA GO TRIEM!!!
            stack.Peek();
            Console.WriteLine(string.Join(", ", stack));

            Console.WriteLine("Count = " +  stack.Count);
            stack.Clear(); //triem vsichki elementi ot staka
            Console.WriteLine("Count = " +  stack.Count);


            /*Comments:
	        Stack<T> last in first out:
	            Pop()- trie posledniq slojen element v steka, 
                Push(...) - slaga element v steka, 
                ToArray() - prevrushta go v masiv, 
                Contains(...) - proverqva dali se sudurja daden element, 
                Count() - proverqva broq na elementite v steka
	        
	        Queue<T> first in, first out:
	            Enqueue() - Dobavq element na opashkata, 
                Dequeue() - Premahva purviq slojen element v opashkata, 
	            Peek() - vrushta purviq element, 
	            ToArray(), Contains(), Count()
            
            
            PO BURZI SA OT SPISUCITE.
            Hubavo e da znaem che gi ima dori i da ne gi polzvame v realnata praktika.
            */


            //Kak se definirat
            Stack<int> stack2 = new Stack<int>();
            Queue<int> queue = new Queue<int>();

            //Za poveche primeri proveri zadachite, daje gi debugni ako trqbva
            //inache trudno shte se setish kak stawa !!!!!!!!!!!!!!!!!!!!!!!!!

            

        }
    }
}






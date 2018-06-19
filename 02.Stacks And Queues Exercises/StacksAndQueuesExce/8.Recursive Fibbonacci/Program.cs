using System;

namespace _8.Recursive_Fibbonacci
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++){

                int fibonacci = getFibonacci(i+1);
                if(i == n-1)
                    Console.WriteLine(fibonacci);
            }
            
        }

        public static int getFibonacci(int number)
        {

            if (number == 0)
                return 0;
            else if (number == 1)
                return 1;
            else
            {
                int toReturn = getFibonacci(number - 2) + getFibonacci(number - 1);
                return toReturn;
            }

        }
    }
}

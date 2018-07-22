using System;

namespace _08._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            fibNumbers = new long[n];
            long fibonacci = getFibonacci(n);
            Console.WriteLine(fibonacci);
        }

        public static long getFibonacci(int number)
        {
            if (number <= 2)
                return 1;

            if (fibNumbers[number - 1] != 0)
                return fibNumbers[number - 1];

            long toReturn = getFibonacci(number - 1) + getFibonacci(number - 2);
            return fibNumbers[number - 1] = toReturn;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Functional_Programming
{
    class Program
    {
        static void Main(string[] args)
        {

            new List<int> { 1, 2, 3, 4, 5, 6 }
                .Where(n => n % 2 == 0)
                .ToList()
                .ForEach(n => Console.WriteLine(n));

            var timer = System.Diagnostics.Stopwatch.StartNew();

            var nums = Enumerable.Range(1, 100_00);
            var filtered = nums
                .Where(n => n % 1 == 0)
                .Where(n => n % 2 == 0)
                .Where(n => n % 3 == 0)
                .Where(n => n % 5 == 0)
                .Where(n => n % 7 == 0)
                .ToList();
            Console.WriteLine(timer.Elapsed);

            var timer2 = System.Diagnostics.Stopwatch.StartNew();

            var filtered2 = nums
                .Where(n => n % 7 == 0)         
                .Where(n => n % 5 == 0)         
                .Where(n => n % 3 == 0)         
                .Where(n => n % 2 == 0)         
                .Where(n => n % 1 == 0)         
                .ToList();
            Console.WriteLine(timer2.Elapsed); 

            var timer3 = System.Diagnostics.Stopwatch.StartNew();

            var filtered3 = nums
                .Where(n => n % 1 == 0
                && n % 2 == 0
                && n % 3 == 0
                && n % 5 == 0
                && n % 7 == 0)
                .ToList();

            Console.WriteLine(timer3.Elapsed); 

            var timer4 = System.Diagnostics.Stopwatch.StartNew();

            var filtered4 = nums
                .Where(n => n % 7 == 0
                && n % 5 == 0
                && n % 3 == 0
                && n % 2 == 0
                && n % 1 == 0)
                .ToList();

            Console.WriteLine(timer4.Elapsed); 

            Func<string, int> ParseStringsToInt = (string str) => int.Parse(str);

            Func<string, int> ParseStringsToInt2 = (str) => int.Parse(str);
            
			Func<string, int> ParseStringsToInt3 = int.Parse;
            
            int nn = ParseStringsToInt("5");
            Console.WriteLine(nn);
            Console.WriteLine(ParseStringsToInt2("5"));
            Console.WriteLine(ParseStringsToInt3("5"));

            Func<int, int, int> sumTwoNums = (x, y) => { return x + y; };
            Console.WriteLine(sumTwoNums(5, 25));
            
            Func<string, List<int>, double> getAverageGrade = (name, gradeList) => gradeList.Average();
            double res = getAverageGrade("Toni", new List<int>() { 5, 2, 4, 6, 6, 5, 5, 6, 3 });
            Console.WriteLine(res);
            
            Func<string, float, string> studentInfo = (name, averageGrade) => $"Student: {name} has average grade: {averageGrade} IN FUNC !";
            string res2 = studentInfo("Asen Kambitov", 5.35f);
            Console.WriteLine(res2);
            
            Func<string> readFromConsole = () => Console.ReadLine();
            Console.Write("Write something on the console: ");
            
            Action<string> printOnTheConsole = (something) => Console.WriteLine(something);
            string input = readFromConsole();
            printOnTheConsole(input);

            Action<string, decimal> studentInfoWithAction = (name, averageGrade) => Console.WriteLine($"Student: {name} has average grade: {averageGrade} IN ACTION!");
            studentInfoWithAction("Atanas Kambitov", (decimal)5.55);
            
            Action<string, string> printFullName = (firstName, lastName) => { Console.WriteLine($"FullName: {firstName} {lastName} !"); };
            printFullName("Dimitrinka", "Gramoshenova");
            
            Func<string, int> parse = myParse;
           
            Console.WriteLine();

            var nums2 = new List<int>() { 1, 2, 3, 4, 5 };

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var filtered5 = new List<int>();

            for (int i = 0; i < nums2.Count; i++)
            {
                filtered.Add(nums2[i]++);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();

            var filtered6 = nums.Select(n => n++).ToList();

            stopwatch2.Stop();

            Console.WriteLine(stopwatch2.Elapsed);
            
            Console.WriteLine();

            List<int> nums3 = new List<int>() { 1, 2, 3 };

            var query = nums3.Where(n => n > 2);

            foreach (var item in query)
                Console.Write(item + " ");
           
            Console.WriteLine();

            nums3.Add(4);

            foreach (var item in query)
                Console.Write(item + " ");
            
            Console.WriteLine();

            var newQuery = nums3.AsQueryable();  
        }

        static int myParse(string num) { return int.Parse(num); }
    }
}







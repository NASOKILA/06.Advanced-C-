using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Filter_by_Age
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            Dictionary<string, int> people
                = new Dictionary<string, int>();

            FillDictionary(peopleCount, people);

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            var filter = GetFilter(condition, age);

            var printer = CreatePrinter(format);

            PrintPeople(people, filter, printer);
        }

        public static Func<int, bool> GetFilter(string condition, int age)
        {

            if (condition == "younger")
                return x => x < age;        
            else
                return x => x >= age;

        }
 
        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name": 
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine(x.Key + " - " + x.Value);
                default:
                    throw new NotImplementedException();
            }
        }

        private static void FillDictionary(int peopleCount, Dictionary<string, int> people)
        {
            for (int i = 0; i < peopleCount; i++)
            {
                string[] nameAndAge =
                    Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                people[nameAndAge[0]] = int.Parse(nameAndAge[1]);
            }
        }

        private static void PrintPeople(Dictionary<string, int> people, Func<int, bool> filter, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (filter(person.Value)) 
                    printer(person); 
            }
        }
    }
}

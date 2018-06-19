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

            //Vzimame si nujnata funkciq ot GetFilter(); v zavisimost ot condition, i q slagame v promenliva !!!
            var filter = GetFilter(condition, age);

            //Zapisvame si i formata na printirane (AKTIONA) v promenliva v zavisimost ot formata !!!
            var printer = CreatePrinter(format);

            PrintPeople(people, filter, printer);

            //people.Where(p => filter(p.Value)).ToList().ForEach(printer);    // I TAKA SHTE STANE !!!   

        }

        //Suzdavame funkciq koqto vrushta funkciq ot tip Func<int, bool> !!!!!!!!!!!
        //podaveme string i int i polucavame funkciq koqto priqma int i vrushta bool
        public static Func<int, bool> GetFilter(string condition, int age)
        {

            if (condition == "younger")
                return x => x < age;        // vrushtame funkciq koqto vrushta danni po malki ot x
            else
                return x => x >= age;

        }

        //Funkciq koqto vrushta razlichen action v zavisimost ot formata !!!
        //podavame formata i poluchavame edna ot funkciite opisani dolo
        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {

            switch (format)
            {

                case "name": //ako formata e "name" vrushta taq funkciq
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine(x.Key + " - " + x.Value);
                default:
                    throw new NotImplementedException();
                    //kazvame da hvurli exception che oshte ne sme go napravili !!!
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
                if (filter(person.Value)) // ako age otgovarq na funkciqta vuv filtera 
                    printer(person); //Printirame s funkciqta koqto zapisahme v printera 
            }
        }
    }
}

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

            /*
              Comments:
                01.Funkcionalno programirane vs Konvenkcionlno programirane
                    ,Lambda expressions LINQ
                02. Action<T> i Func<T> funkcii
                03.Passing functions and methods, creating our own methods
                04.Delegeti
            
             
                FUNKCIQTA VRUSHTA REZULTAT A METODA NE !!!!!!!!!!!!!!!
             
             */

            /*VAJNO !!!

            MOJE DINAMICHNO DA GENERIRAME DADENI Func<T> i Action<T> V 
            ZAVISIMOST OT DADENI REZULTATI.
            VIJ ZADACHA 5 !!!!!!!!!!!!!!!!
            */

            /*
             01. Functionalno programirane:
                polzvame nai veche LINQ i gotovi metodi na dadeni klasove
                
                PO BURZO E OT NORMALNIQ NACHIN SUS CIKLI I DR.
                OBACHE AKO IMA PROBLEM E MNOGO PO TRUFNO ZA DEBUGVANE !!!    

             */


            //IMA OGROMNO ZNACHENIQ ZA PERFORMANSA KAK POLZVAME LINQ FUNKCIITE:

            //print even numbers of list
            new List<int> { 1, 2, 3, 4, 5, 6 }
                .Where(n => n % 2 == 0)
                .ToList()
                .ForEach(n => Console.WriteLine(n));


            //filtrirame chislata ot 1 do 10 000 koito se delqt na 1, 2, 3, 5 i 7

             /* VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO :
                KOGATO ISKAME DA PRESMQTAME VREME NA DADENQ PROGRAMA
                POLZVAME STOPWATCH */
            var timer = System.Diagnostics.Stopwatch.StartNew();

            var nums = Enumerable.Range(1, 100_00);
            var filtered = nums
                .Where(n => n % 1 == 0)
                .Where(n => n % 2 == 0)
                .Where(n => n % 3 == 0)
                .Where(n => n % 5 == 0)
                .Where(n => n % 7 == 0)
                .ToList();
            Console.WriteLine(timer.Elapsed); //00:00:00.0012478

            var timer2 = System.Diagnostics.Stopwatch.StartNew();

            //Purvo slagame nai selektivnite TAKA TAVA MNOGO PO BURZO ZASHTOTO
            //SLED VSEKI .Where() SE VRUSHTAT PO MALKO RESULTATI
            var filtered2 = nums
                .Where(n => n % 7 == 0)         //Vrushta 10 000 / 7 rezultati
                .Where(n => n % 5 == 0)         //Vrushta 10 000 / 7 / 5 rezultati
                .Where(n => n % 3 == 0)         //Vrushta 10 000 / 7 / 5 / 3 rezultati
                .Where(n => n % 2 == 0)         //Vrushta 10 000 / 7 / 5 / 3 / 2 rezultati
                .Where(n => n % 1 == 0)         //Vrushta 10 000 / 7 / 5 / 3 / 2  / 1 rezultati
                .ToList();
            Console.WriteLine(timer2.Elapsed); //00:00:00.0007757

            //VTORIQ NACHIN E MNOGO PO BURS !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //OBACHE MOJEM I OSHTE PO BURZO OT TOVA !!!!!!!!!!!!!!!!!!!!!!

            //Prosto slagame vsicho v edin Where() !!!!!!!!!
            var timer3 = System.Diagnostics.Stopwatch.StartNew();

            var filtered3 = nums
                .Where(n => n % 1 == 0
                && n % 2 == 0
                && n % 3 == 0
                && n % 5 == 0
                && n % 7 == 0)
                .ToList();

            Console.WriteLine(timer3.Elapsed); //00:00:00.0003190

            //DVA PUTI PO BURZO E OT GORNOTO !!!


            //MOJE I OSHTE PO BURZO KATO GI PODREDIM OT PO GOLQMO KUM PO MALKO
            //SAMO V EDIN .Where();
            var timer4 = System.Diagnostics.Stopwatch.StartNew();

            var filtered4 = nums
                .Where(n => n % 7 == 0
                && n % 5 == 0
                && n % 3 == 0
                && n % 2 == 0
                && n % 1 == 0)
                .ToList();

            Console.WriteLine(timer4.Elapsed); //00:00:00.0003023




            /*
             Action<T> i Func<T> funkcii:
                Action<T> NE VRUSHTAT NISHTO, TE SAMO OBRABOtVAT NESHTO I toVA E,
                KAKTO E Console.WriteLine() KOQTO PRINTIRA NA KONZOLATA.

                Func<T> VECHE VRUSHTA DADEN REZULTAT, PRIMERNO MOJEM DA ZAPISVAME REZULTAT
                OT FUNKCIQ V PROMENLIVA.
             
             */

            //SUZDAVAME FUNKCIQ KOQTO DA PROEMA STRING I DA VRUSHA INTEGER I I KAZVAME CHE E = NA int.Parse
            Func<string, int> ParseStringsToInt = (string str) => int.Parse(str);

            //moje i taka:     MOJEM DA POLZVAME I BLOCK SUS return !!!!!!!
            Func<string, int> ParseStringsToInt2 = (str) => int.Parse(str);
            //Func<string, int> ParseStringsToInt2 = (str) => { return int.Parse(str); };


            //moje idirektno taka
            Func<string, int> ParseStringsToInt3 = int.Parse;
            
            //Vijdame che i trite rabotat
            int nn = ParseStringsToInt("5");
            Console.WriteLine(nn);
            Console.WriteLine(ParseStringsToInt2("5"));
            Console.WriteLine(ParseStringsToInt3("5"));


            //sum 2 numbers
            Func<int, int, int> sumTwoNums = (x, y) => { return x + y; };
            Console.WriteLine(sumTwoNums(5, 25));
            
            Func<string, List<int>, double> getAverageGrade = (name, gradeList) => gradeList.Average();
            double res = getAverageGrade("Toni", new List<int>() { 5, 2, 4, 6, 6, 5, 5, 6, 3 });
            Console.WriteLine(res);
            
            Func<string, float, string> studentInfo = (name, averageGrade) => $"Student: {name} has average grade: {averageGrade} IN FUNC !";
            string res2 = studentInfo("Asen Kambitov", 5.35f);
            Console.WriteLine(res2);

            //Funkciq koqt prochita ot konzolata NE PRIEMA PARAMETRI
            
            Func<string> readFromConsole = () => Console.ReadLine();
            Console.Write("Write something on the console: ");
            


            //Action<T> NE VRUSHTA NISHTO A SAMO PRAVI DADENO DEISTVIE TE SA Void() FUNKCII:

            //Action<> KOito da printira na konzolata
            Action<string> printOnTheConsole = (something) => Console.WriteLine(something);
            string input = readFromConsole();
            printOnTheConsole(input);

            Action<string, decimal> studentInfoWithAction = (name, averageGrade) => Console.WriteLine($"Student: {name} has average grade: {averageGrade} IN ACTION!");
            studentInfoWithAction("Atanas Kambitov", (decimal)5.55);
            
            //I tuk mojem da polzvame blok obche BEZ return !!!!
            Action<string, string> printFullName = (firstName, lastName) => { Console.WriteLine($"FullName: {firstName} {lastName} !"); };
            printFullName("Dimitrinka", "Gramoshenova");
            


            //Mojem direktno da si pravim nie funkcii i da gi assinvame na 
            //drugi funkcii suzdadeni s func<T>
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
            //Queryta VAJNOOOOOOOOOOOO !!!!!!

            List<int> nums3 = new List<int>() { 1, 2, 3 };

            var query = nums3.Where(n => n > 2);
            //Sega ako promenim spisuka avtomatichno promenqme i query-to 
            //NO, MNOGO VAJNO: 
            //AKO NAKRAQ DOBAVIM .ToArray() ili .ToList() NQMA DA STANE ZASHTOTO VECHE NE E QUERY !!!!!!


            foreach (var item in query)
                Console.Write(item + " ");
           
            Console.WriteLine();

            //AKO IMAME .ToList() ili .ToArray NAKRAQ NA PROMENLIVATA 'query', 
            //TOVA DOBAVENO CHISLO KUM SPISUKA NE SE OTRAZQVA NA QUERYTO !!!
            nums3.Add(4);

            foreach (var item in query)
                Console.Write(item + " ");
            
            Console.WriteLine();



            //VAJNO .AsQuariable();

            var newQuery = nums3.AsQueryable(); 
            //SEGA newQuery NE E SPSUK A NESHTO PO RAZLICHNO I MOJEM DA GO POLZVAME  KATO QUERY !!!



            //MOJEM AVTOMATICHNO DA GENERIRAME RAZLICHNI FUNKCII V ZAVISIMOST OT DADENI REZULTATI.



            /*
             Summary: 
             Razgledahme :
             01.LINQ 
             02.LAMBDA 
             03.Acttion<T>               KATO VOID FUNKCIQ
             04.Func<T, resultT>         KATO NORMALNA FUNKCIQ
            
            Polzvahme stopWatch za da smqtame vremeto na rogramata
             
            Ima golqm smisul v tova kak da si formolirame koda za po dobur 
            performance

            MOJEM AVTOMATICHNO DA GENERIRAME RAZLICHNI FUNKCII I DA GI POLZVAME
            DORI I KATO PARAMETRI !!!

            */

        }

        static int myParse(string num) { return int.Parse(num); }

    }
}







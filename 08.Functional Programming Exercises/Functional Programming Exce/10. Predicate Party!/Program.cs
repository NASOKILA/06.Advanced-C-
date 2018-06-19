using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleComing = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] commandTokens = Console.ReadLine()
                .Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (commandTokens[0] != "Party!")
            {

                string action = commandTokens[0];
                string criteria = commandTokens[1];
                string element = commandTokens[2];

                Func<List<string>, string, List<string>> function = GenerateFunc(action, criteria, element);

                peopleComing = function(peopleComing, element);
                
                commandTokens = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Print(peopleComing);
            
        }

        private static Action<List<string>> Print = (list) => {

            if (list.Count == 0)
                Console.WriteLine($"Nobody is going to the party!");
            else
                Console.WriteLine(string.Join(", ", list) + " are going to the party!");
        };

        private static Func<string, string, string, Func<List<string>, string, List<string>>> 
            GenerateFunc = (action, criteria, element) =>
        {

            if (action == "Remove")
            {
                if (criteria == "StartsWith")
                {
                    Func<List<string>, string, List<string>> func = (list, elem) => {

                        var newlist = list.Where(e => !e.StartsWith(elem)).ToList();

                        return newlist;
                    };


                    return func;
                }
                else if (criteria == "EndsWith")
                {
                    Func<List<string>, string, List<string>> func = (list, elem) => {

                        var newlist = list.Where(e => !e.EndsWith(elem)).ToList();

                        return newlist;
                    };
                    return func;

                }
                else
                {
                    //Length
                    Func<List<string>, string, List<string>> func = (list, elem) => {
                        
                        var newlist = list.Where(e => e.Length != int.Parse(elem)).ToList();

                        return newlist;
                    };

                    return func;
                }
            }
            else 
            {
                //double

                if (criteria == "StartsWith")
                {

                    Func<List<string>, string, List<string>> DoubleFunc = (list, elem) => {

                        var newlist = new List<string>();

                        list.ForEach(e => {

                            newlist.Add(e);

                            if (e.StartsWith(elem))
                                newlist.Add(e);
                        });

                        return newlist;
                    };

                    return DoubleFunc;

                }
                else if (criteria == "EndsWith")
                {

                    Func<List<string>, string, List<string>> DoubleFunc = (list, elem) => {

                        var newlist = new List<string>();

                        list.ForEach(e => {

                            newlist.Add(e);

                            if (e.EndsWith(elem))
                                newlist.Add(e);
                        });

                        return newlist;
                    };
                    
                    return DoubleFunc;
                }
                else
                {
                    //Length
                    Func<List<string>, string, List<string>> DoubleFunc = (list, elem) => {

                        var newlist = new List<string>();

                        list.ForEach(e => {

                            newlist.Add(e);

                            if (e.Length == int.Parse(elem))
                                newlist.Add(e);
                        });

                        return newlist;
                    };

                    return DoubleFunc;
                    
                }
                
            }
            
        };
    }
}

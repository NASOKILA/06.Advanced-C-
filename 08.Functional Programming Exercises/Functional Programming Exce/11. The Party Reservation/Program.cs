using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation
{
    class Program
    {
        static void Main(string[] args)
        {

            var names = Console.ReadLine()
               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            string[] commandTokens = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            Dictionary<string, List<string>> filterNameAndRemovedElements = new Dictionary<string, List<string>>();

            while (commandTokens[0] != "Print")
            {
                string command = commandTokens[0];
                string filterType = commandTokens[1];
                string parameter = commandTokens[2];

                var func = GenerateFunc(command, filterType, parameter);

                names = func(filterNameAndRemovedElements, names, parameter);

                commandTokens = Console.ReadLine()
                    .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            Console.WriteLine(string.Join(" ", names));

        }


        public static Func<string, string, string, Func<Dictionary<string, List<string>>, List<string>, string, List<string>>>
            GenerateFunc = (command, filterType, parameter) =>
            {

                if (command == "Add filter")
                {

                    if (filterType == "Starts with")
                    {
                        Func<Dictionary<string, List<string>>, List<string>, string, List<string>>
                        AddFuncSW = (dictionary, list, param) =>
                        {

                            var newList = list.Where(e => !e.StartsWith(param)).ToList();

                            var removedElements = list.Where(e => e.StartsWith(param)).ToList();

                            if (dictionary.Keys.Contains(filterType))
                                dictionary[filterType].ForEach(e => removedElements.Insert(0, e));

                            dictionary[filterType] = removedElements;

                            return newList;
                        };

                        return AddFuncSW;
                    }
                    else if (filterType == "Ends with")
                    {
                        Func<Dictionary<string, List<string>>, List<string>, string, List<string>> AddFuncEW = (dictionary, list, param) =>
                        {

                            var newList = list.Where(e => !e.EndsWith(param)).ToList();
                            var removedElements = list.Where(e => e.EndsWith(param)).ToList();

                            if (dictionary.Keys.Contains(filterType))
                                dictionary[filterType].ForEach(e => removedElements.Insert(0, e));

                            dictionary[filterType] = removedElements;


                            return newList;
                        };

                        return AddFuncEW;
                    }
                    else if (filterType == "Length")
                    {
                        Func<Dictionary<string, List<string>>, List<string>, string, List<string>> AddFuncLength = (dictionary, list, param) =>
                        {

                            var newList = list.Where(e => e.Length != int.Parse(param)).ToList();
                            var removedElements = list.Where(e => e.Length == int.Parse(param)).ToList();

                            if (dictionary.Keys.Contains(filterType))
                                dictionary[filterType].ForEach(e => removedElements.Insert(0, e));

                            dictionary[filterType] = removedElements;


                            return newList;
                        };

                        return AddFuncLength;
                    }

                    //Contains

                    Func<Dictionary<string, List<string>>, List<string>, string, List<string>>
                    AddFuncContains = (dictionary, list, param) =>
                    {

                        var newList = list.Where(e => !e.Contains(param)).ToList();

                        var removedElements = list.Where(e => e.Contains(param)).ToList();

                        if (dictionary.Keys.Contains(filterType))
                            dictionary[filterType].ForEach(e => removedElements.Insert(0, e));

                        dictionary[filterType] = removedElements;

                        return newList;
                    };

                    return AddFuncContains;
                }

                //remove filter

                if (filterType == "Starts with")
                {
                    Func<Dictionary<string, List<string>>, List<string>, string, List<string>>
                    RemoveFuncSW = (dictionary, list, param) =>
                    {

                        var newList = list.Where(e => !e.StartsWith(param)).ToList();

                            //vzimme ot dictionary vsichki SPORED filterType i gi dobavqme OTPRED NA  newList
                            List<string> elementsToRestore = dictionary[filterType];

                        for (int i = elementsToRestore.Count - 1; i >= 0; i--)
                        {
                            string element = elementsToRestore[i];
                            if (element.StartsWith(param))
                                newList.Insert(0, element);
                        }


                        return newList;
                    };

                    return RemoveFuncSW;
                }
                else if (filterType == "Ends with")
                {

                    Func<Dictionary<string, List<string>>, List<string>, string, List<string>>
                    RemoveFuncEW = (dictionary, list, param) =>
                    {

                        var newList = list.Where(e => !e.EndsWith(param)).ToList();

                            //vzimme ot dictionary vsichki SPORED filterType i gi dobavqme OTPRED NA  newList
                            List<string> elementsToRestore = dictionary[filterType];

                        for (int i = elementsToRestore.Count - 1; i >= 0; i--)
                        {
                            string element = elementsToRestore[i];
                            if (element.EndsWith(param))
                                newList.Insert(0, element);
                        }

                        return newList;
                    };

                    return RemoveFuncEW;
                }
                else if (filterType == "Length")
                {
                    Func<Dictionary<string, List<string>>, List<string>, string, List<string>>
                RemoveFuncLength = (dictionary, list, param) =>
                {

                    var newList = list.Where(e => e.Length != int.Parse(param)).ToList();

                    List<string> elementsToRestore = dictionary[filterType];

                    for (int i = elementsToRestore.Count - 1; i >= 0; i--)
                    {
                        string element = elementsToRestore[i];
                        if (element.Length == int.Parse(param))
                            newList.Insert(0, element);
                    }

                    return newList;
                };

                    return RemoveFuncLength;
                }


                //Contains

                Func<Dictionary<string, List<string>>, List<string>, string, List<string>> RemoveFuncContains = (dictionary, list, param) =>
                {

                    var newList = list.Where(e => !e.Contains(param)).ToList();

                    List<string> elementsToRestore = dictionary[filterType];

                    for (int i = elementsToRestore.Count - 1; i >= 0; i--)
                    {
                        string element = elementsToRestore[i];
                        if (element.Contains(param))
                            newList.Insert(0, element);
                    }

                    return newList;
                };

                return RemoveFuncContains;



            };

    }
}



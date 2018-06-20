using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Zadacha4
{
    class Program
    {
        static void Main(string[] args)
        {

            int targetInfoIndex = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            Dictionary<string, Dictionary<string, string>> 
                namesAndInfo = new Dictionary<string, Dictionary<string, string>>();

            while (command != "end transmissions")
            {
                string[] nameAndInformation = command
                    .Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = nameAndInformation[0];

                List<string> information = nameAndInformation[1]
                    .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var infoKeyAndValue = new Dictionary<string, string>();

                if (!namesAndInfo.ContainsKey(name))
                {

                    
                    foreach (var item in information)
                    {
                        var tokens = item.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                        string key = tokens[0];
                        string value = tokens[1];
                        infoKeyAndValue[key] = value;

                    }

                    namesAndInfo[name] = infoKeyAndValue;


                }
                else
                {
                    //ako sudurja klucha NAME

                    //vzimame si vsichko vutre v toq kluch
                    infoKeyAndValue = namesAndInfo[name];


                    
                    foreach (var item in information)
                    {
                        var tokens = item
                            .Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                        string key = tokens[0];
                        string value = tokens[1];


                        //AKO GO NQMA TOZI KLUCH
                        infoKeyAndValue[key] = value;
                        

                    }

                    namesAndInfo[name] = infoKeyAndValue;


                }

                command = Console.ReadLine();
            }

            var target = Console.ReadLine()
                .Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string nameToKill = target[1];


            int infoIndex = 0;

            Console.WriteLine($"Info on {nameToKill}:");
            foreach (var item in namesAndInfo[nameToKill].OrderBy(kvp => kvp.Key))
            {
                infoIndex += item.Key.Length;
                infoIndex += item.Value.Length;

                Console.WriteLine($"---{item.Key}: {item.Value}");
            }


            Console.WriteLine($"Info index: {infoIndex}");
            
            
            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                int infoNeeded = Math.Abs(targetInfoIndex - infoIndex);

                Console.WriteLine($"Need {infoNeeded} more info.");
            }



        }
    }
}

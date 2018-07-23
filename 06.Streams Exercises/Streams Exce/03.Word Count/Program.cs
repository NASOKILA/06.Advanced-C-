using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsAndCount = new Dictionary<string, int>();
            
            using (StreamReader stream = new StreamReader("words.txt"))
            {
                string word = string.Empty;

                while ((word = stream.ReadLine()) != null)
                    wordsAndCount.Add(word, 0);
            }

            string[] words = wordsAndCount.Keys.ToArray();

            using (StreamReader stream = new StreamReader("text.txt"))
            {
                string line = string.Empty;

                while ((line = stream.ReadLine()) != null) {

                    foreach (var word in words)
                    {     
                        string[] lineArray = line
                            .Split(new char[] { ' ', '-', ',', '.', '!', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                        foreach (var item in lineArray)
                        {
                            if(item.ToLower() == word.ToLower())
                                wordsAndCount[word]++; 
                        }
                    }
                }              
            }

            foreach (var kvp in wordsAndCount.OrderByDescending(e => e.Value))
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }
    }
}

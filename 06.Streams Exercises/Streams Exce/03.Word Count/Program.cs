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
            
            //cheta si purviq fail i zapisvam dumite v rechnik
            using (StreamReader stream = new StreamReader("words.txt"))
            {
                string word = string.Empty;

                while ((word = stream.ReadLine()) != null)
                    wordsAndCount.Add(word, 0);
            }

            //Prava s kolekciq samo ot kluchoveta za da go polzvame pri proverkite!
            string[] words = wordsAndCount.Keys.ToArray();


            //cheta vroriq fail s texta
            using (StreamReader stream = new StreamReader("text.txt"))
            {
                string line = string.Empty;
                //vzimam si redovete red po red
                while ((line = stream.ReadLine()) != null) {

                    //za vsqka duma v kolekciqta ot kluchovete
                    foreach (var word in words)
                    {     
                        //delq celiq red za da polucha masiv samo s dumichkite
                        string[] lineArray = line
                            .Split(new char[] { ' ', '-', ',', '.', '!', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                        //i proverqvam dali vsqka duma ot masiva suvpada s tazi ot 'words'
                        foreach (var item in lineArray)
                        {
                            if(item.ToLower() == word.ToLower())
                                wordsAndCount[word]++; //ako suvpada promenqm originalniq rechnik
                        }

                    }
                }
                    
            }

            //podrejdam rechnika i go printiram
            foreach (var kvp in wordsAndCount.OrderByDescending(e => e.Value))
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            

        }
    }
}

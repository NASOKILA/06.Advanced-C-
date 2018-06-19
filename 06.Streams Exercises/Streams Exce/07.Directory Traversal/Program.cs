using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();

            //VZIMAME VSICHKI FAILOVE OT TOZI path
            var filesDirectory = Directory.GetFiles(path);

            //Trqbva da vzemem ime, extention, razmer ot vseki fail i da gi slojim v rechnika

            foreach (var file in filesDirectory)
            {
                
                //Vzimame cqlata informaciq za tekushtiq fail
                FileInfo fileInfo = new FileInfo(file);

                string name = fileInfo.Name;
                string extention = fileInfo.Extension;
                long size = fileInfo.Length;

                if (!filesDictionary.ContainsKey(extention))
                    filesDictionary[extention] = new List<FileInfo>();

                filesDictionary[extention].Add(fileInfo);
                
            }


            //sortirame 
            filesDictionary = filesDictionary
                .OrderByDescending(e => e.Value.Count)
                .ThenBy(e => e.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            

            //Sega trqbva da napravim fail report.txt i da go slojin na desktopa
            //vzimame putq do desktopa
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //dobavqme kum nego imeto na faila koito iskame da izleze na desktopa
            string fileName = desktop + "/report.txt";

            using (var writer = new StreamWriter(fileName))
            {
                foreach (var pair in filesDictionary)
                {
                    string extention = pair.Key;
                    
                    writer.WriteLine(extention);

                    //podrejdame i failovete vutre po dukjina
                    var filesInfos = pair.Value.OrderByDescending(f => f.Length);

                    foreach (var info in filesInfos)
                    {
                        //vzimame razmera v kb 
                        double fileSize = (double)info.Length / 1024;

                        //printiram vuv faila kato razmera ni e zakruglen do 3 
                        writer.WriteLine($"--{info.Name} - {fileSize:f3}kb");
                    }

                }
            }

            
        }
    }
}

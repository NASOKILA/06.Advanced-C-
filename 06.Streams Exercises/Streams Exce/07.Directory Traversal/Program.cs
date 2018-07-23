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

            var filesDirectory = Directory.GetFiles(path);

            foreach (var file in filesDirectory)
            {
                FileInfo fileInfo = new FileInfo(file);

                string name = fileInfo.Name;
                string extention = fileInfo.Extension;
                long size = fileInfo.Length;

                if (!filesDictionary.ContainsKey(extention))
                    filesDictionary[extention] = new List<FileInfo>();

                filesDictionary[extention].Add(fileInfo);
            }

            filesDictionary = filesDictionary
                .OrderByDescending(e => e.Value.Count)
                .ThenBy(e => e.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string fileName = desktop + "/report.txt";

            using (var writer = new StreamWriter(fileName))
            {
                foreach (var pair in filesDictionary)
                {
                    string extention = pair.Key;
                    
                    writer.WriteLine(extention);

                    var filesInfos = pair.Value.OrderByDescending(f => f.Length);

                    foreach (var info in filesInfos)
                    {
                        double fileSize = (double)info.Length / 1024;

                        writer.WriteLine($"--{info.Name} - {fileSize:f3}kb");
                    }
                }
            }   
        }
    }
}

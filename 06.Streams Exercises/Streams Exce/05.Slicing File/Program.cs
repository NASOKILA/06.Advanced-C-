using System;
using System.Collections.Generic;
using System.IO;

namespace _05.Slicing_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = "./VideoParts/";
            string sourceFile = "sliceMe.mp4";
            int parts = 5;

            Slice(sourceFile, directory, parts);

            var files = new List<string>() {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4"
            };

            Assemble(files, directory);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {

            string extention = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;

                    if (destinationDirectory == string.Empty)
                        destinationDirectory = "./";

                    string currentPartName = destinationDirectory + $"Part-{i}.{extention}";

                    using (FileStream writer = new FileStream(currentPartName, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];

                        while (reader.Read(buffer, 0, 4096) == 4096)
                        {
                            writer.Write(buffer, 0, 4096);
                            currentPieceSize += 4096;

                            if (currentPieceSize >= pieceSize)
                                break;
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extention = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
                destinationDirectory = "./";

            if (!destinationDirectory.EndsWith("/"))
                    destinationDirectory += "/";
            
            string assembleFile = destinationDirectory + $"Assembled.{extention}";

            using (FileStream writer = new FileStream(assembleFile, FileMode.Create))
            {
                byte[] buffer = new byte[4096];

                foreach (var file in files)
                {
                    using (var reader = new FileStream(destinationDirectory + file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, 4096) == 4096)
                        {                        
                            writer.Write(buffer, 0, 4096);
                        }
                    }
                }
            }
        }
    }
}

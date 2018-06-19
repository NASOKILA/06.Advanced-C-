using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _06.Zipping_Sliced_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = "./VideoParts/";

            string sourceFile = "sliceMe.mp4";

            int parts = 5;

            Slice(sourceFile, directory, parts);

            Zip(sourceFile, directory, parts);

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

            //rejem go ot poslednata tochka do kraq tova shte ni e extentiona shte ni tqbva za imenata na parchetata
            string extention = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {

                //vzimame razmera koito trqbva da ima edno parche
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);


                //shte podavame  vsichki chasti edna po edena
                for (int i = 0; i < parts; i++)
                {

                    long currentPieceSize = 0;

                    //ako e prazna direkctoriqta q zamenqme s tazi na proekta
                    if (destinationDirectory == string.Empty)
                        destinationDirectory = "./";

                    //pravim si imeto na tekushtoto parche
                    string currentPartName = destinationDirectory + $"Part-{i}.{extention}";

                    //Pravim si file Writera i slagame v imeto na faila koito shte suzdadem
                    using (FileStream writer = new FileStream(currentPartName, FileMode.Create))
                    {
                        //pravim si puffera
                        byte[] buffer = new byte[4096];

                        while (reader.Read(buffer, 0, 4096) == 4096)
                        {
                            //zapisvame go
                            writer.Write(buffer, 0, 4096);
                            currentPieceSize += 4096;

                            //trqbva da sprem pri vsqko zapulvane:
                            if (currentPieceSize >= pieceSize)
                                break;

                        }

                    }
                }
            }
        }

        static void Zip(string sourceFile, string destinationDirectory, int parts)
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

                    string currentPartName = destinationDirectory + $"Part-{i}.{extention}.gz";
 
                    using (GZipStream zip = new GZipStream(new FileStream (currentPartName, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[4096];

                        while (reader.Read(buffer, 0, 4096) == 4096)
                        {
                            //zapisvame go
                            zip.Write(buffer, 0, 4096);
                            currentPieceSize += 4096;

                            //trqbva da sprem pri vsqko zapulvane:
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

            //ako ne zavurshva s "/", mu go dobavqme !
            if (!destinationDirectory.EndsWith("/"))
                destinationDirectory += "/";

            string assembleFile = destinationDirectory + $"Assembled.{extention}";

            
            using (FileStream writer = new FileStream(assembleFile, FileMode.Create))
            {
                byte[] buffer = new byte[4096];

                foreach (var file in files)
                {
                    //prochitame vseki fails
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

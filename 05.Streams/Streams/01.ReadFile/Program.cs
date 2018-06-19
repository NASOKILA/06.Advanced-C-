    using System;
using System.IO;

namespace _01.ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {

            //za Streamovete polzvame using(){}
            //puskame System.IO; bibliotekata

            //opisvame putq kum faila, TOVA E FAILA V KOITO V MOMENTA PISHEM !!!
            using (StreamReader stream = new StreamReader("Program.cs"))
            {
                //pravim promenliva da ni pazi redovete
                int lineNumber = 1;

                //pochveme da chetem red po red ot faila dokato mu svurshat redovete
                //VMESTO V while() CIKULA DA SLAGAME 'line' MOJEM DIREKTNO V USLOVIETO NA while()
                string line = string.Empty;
                while ((line = stream.ReadLine()) != null)
                {

                    Console.WriteLine($"Line {lineNumber++}: {line}");
                    
                }

            }

        }
    }
}

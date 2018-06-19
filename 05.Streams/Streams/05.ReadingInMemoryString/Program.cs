using System;
using System.IO;
using System.Text;

namespace _05.ReadingInMemoryString
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ZAPISVANETO NA DANNI NA KIRILICA E RAZLICHNO ON NA LATINICA :
           ENKODVAT SE PO RAZLICHEN NACHIN, VSEKI SINVOL ZAPISAN NA KIRILICA
           SE ENCODVA KATO DVA BAITA. 
           AKO CHETEM BAITOVETE EDIN PO EDIN NQMA DA STANE NISHTO.
           NO IMA NACHINI KAK DA SE ENKODVAT 2 x 2 NAVEDNUJ I DA NI VURNE PRAVILEN REZILTAT.*/

            //suzdavame si nqkkuv string
            string latin = "Hello";
            string cirilic = "Хелло";  //PROBVaI I TOZI STRING 

            //direktno pri suzdavaneto na MEmoryStream mojem da mu vzemem baitovete i da gi zapishem v memoryStreama
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(cirilic)))
            {

                //tuk se raboti taka, vzimame vsichki baitove edin po edin sus .ReadByte()

                for (int i = 0; i < memoryStream.Length; i++)
                {
                    //vzimame vseki bait edin po edin i mu printirame sinvoa na konzolata
                    int currentByte = memoryStream.ReadByte();
                    Console.Write((char)currentByte);

                    /*
                       Vijdame che ako imame tekst na latinski si mu printira samite sinvoli kakto sa si
                       obache ako teksta ni e na kirilica vijdame che ima dvoino poveche sinvoli i pri printiraneto
                       sa suvsem razlichni s texsta.
                    */
                }
                Console.WriteLine();

            }


        }
    }
}

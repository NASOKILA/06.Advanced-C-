using System;
using System.IO;

namespace _02.WriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {

            //Read each line from this file, reverse it and save it in a new reversed.txt file :


            //Pravim si StreamWriter i mu kazvame v koi fail shte pishem:
            //VAJNO: KATO PUSNEM PROGRAMATA AKO NQMAME TAKUV FAIL DIREKTNO SHTE NI GO SUZDADE 
            //I SHTE NI SE POZVI OTSTRANI V PROEKTA.
            using (StreamWriter writeStream = new StreamWriter("reversed.txt"))
            {
                /*
                 VUV using (){} MOJEM DA DOBAVQME OSHTE PARAMETRI ZA SUZDAVANETO NA FAILA
                 new StreamWriter("reversed.txt", ...))
                 MOJEM DA MU KAJEM DA HVURLQ EXCEPTION AKO VECHE IMA TAKUV FAIL
                 DALI DA GO OVERWITVA I MNOGO DRUGI NESHTA ...
                 */

                //VAJNO !!!
                //MOJEM PURVO DA DEFINIRAME READERA I V NEGO WRITERA !!!
                using (StreamReader readStream = new StreamReader("Program.cs"))
                {
                    string line;
                    while ((line = readStream.ReadLine()) != null)
                    {

                        for (int counter = line.Length - 1; counter >= 0; counter--)
                        {
                            //Kakto v konzolata imame metod .write za zapisvane samoche 
                            //tozi put shte pishem vuv posocheniq fail: reversed.txt
                            writeStream.Write(line[counter]);
                        }
                        //Kakto v konzolata mu davame nov red:
                        writeStream.WriteLine();
                    }
                }
            }



        }
    }
}

using System;
using System.IO;

namespace _04.CopyingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Po princip ima i po lesen nachin, mojem da polzvame File.Copy()
            //vmesto FileStream

            //Otvarqme faila, moje da e i snimka kakto v sluchaq sus FileStream
            using (var sourceFile = new FileStream("streamImg.jpg", FileMode.Open))
            {
                // i sega go zapisvame v drug fail
                using (var destinationFail = new FileStream("destinationCopy.jpg", FileMode.Create))
                {
                    //Ne mogem da polzvame streamReader ili StreamWriter zashtoto te rabotat s text.

                    //Shte polzvame buffer: sus duljina 4096 zashtoto tova e duljnata NA EDIN KLUSTER
                    //Tova chislo ne e sluchaino prosto WINDOWS SHTE GO OTDELI TAKA ILI INACHE PROSTO TAKA RABOTI
                    //Ako dadem duljina 1024 shte trqbva da zapisvame 4 puti edin kluster, ako e 4096 shte go zapishem navednuj
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        //OT SOURSE FAILA SHTE CHETEM V BUFERA
                        var readBytesCount = sourceFile.Read(buffer, 0, buffer.Length);

                        //ako e 0 znachi veche nqma kakvo da kopira i sledovatelno breakvame
                        if (readBytesCount == 0)
                            break;

                        //inache go zapisvame v nov fail
                        destinationFail.Write(buffer, 0 ,buffer.Length);

                    }

                    //VAJNO !!!
                    //MNOGO PO LESNO STAWA S File.Copy(. . .);
                }
            }

        }
    }
}

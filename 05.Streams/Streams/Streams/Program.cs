using System;
using System.IO;
using System.Text;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             COMMENTS:

            NQMA DA IMA STREAMOVE NA IZPITA JUDJA NE GI PODDURJA

             Streams and Files: (POTOCI I FAILOVE)
             Potocite sa po bogati ot failovete zashtoto mogat da 
             rabotat i s RAM pametta i sus samata mreja sus ustroistvoto.

             Shte razgledame Reader i Writer Streams.
             Streams nasledqvat daden klas.

             Ima i Streams(POTOCI) koito zipvat failove
             ima i za kriptirane
             


            Streams types:
                1.File, Memory, Network Streams
                2.Crypto, Zip Streams



            /*What is Stream?
             tova sa naredeni baitove, naredeni nuli i edinici
             VSICHKO E NULI I EDINICI.
             
             Kato otvorim daden potok zapochvame da izbroqvame ot 
             nachaloto do kraq na potoka.
             MOJE I DA ZAPOCHVAME I OT SREDATA PRIMERNO, NE E ZADULJITELNO DA
             ZAPOCHVAME OT NACHALOTO.

             POTOCITE se polzvat za transfer na danni ot daden fail primerno
             do nashata programa.

             Otvarqme Stream za da :
                01. Chetem danni 
                02. Pishem danni
             
            
            VAJNO !!!
                Youtube polzvat stream za gledaneto na klipcheta.
                Ne zarejda cqloto klipche navednuj a se dava na usera tolkova 
                kolkoto da zapochne da gleda klipa i dokato go gleda 
                se zarejdat ostanalite danni ot klipa.
                Taka ne se nalaga da chakame dokato se zaredi cqloto klipche i 
                ako reshim da izlezem ot klipa sme zaredili po malko danni.
            
             */

            /*
             Streamovete sa posledovatelni potoci ot danni !!!!!!

             Ako iskame da chetem ot daden fail sus Stream nie ne go zarejdame celiq fail
             a samo go podgotvqme za chetene i posle mojem da prochetem kolkoto si iskame ot nego,
             ne sme zaduljeni da chetem celiq fail.
            */

            /*
             C# ni dava razlichni klasove za razlichni streamove:
             Types of streams:
                01.Filetream : e za chetene na danni ot failove 
                02.NetworkStream : e za chetene na danni ot mrejovi ustroistva
                03.MemoryStream : e za chetene na danni ot RAM pametta koito shte izcheznat.


            Buffer:
                Bufera durji 'n' na broi baita ot nashata poziciq v streama.
                Mojem da gledame napred. 
                Nie realno chetem ot buffera zashtoto toi zarejda dannite ot streama.
            


            VAJNO !!! POLZVA SE USING BLOK !!!!!!!
                Za rabota s potoci v  C# e vajno da polzvame bloka 
                using(){ . . . } zashtoto znaem che izvun nego potoka spira.
             
            
            Za chetene polzvame reder klas a za pisane writer klas
            Nikoga ne otvarqme stream i s dvete ednovremenno, ili samo pishem
            ili samo chetem ot daden fail primerno.
            Ima takiva i za dvete no ne se polzva mnogo
            
            BinaryReader i BynaryWrited sa podhodqshti za chetene i za pisane 
            na kartinki, videa i drugi koito ne sa tekstovi failove.


             */
             

            //Stream example:
            //Printirame vseki red ot nashiq fail s nomer do nego.
            using (StreamReader stream = new StreamReader("Program.cs")) {

                string line = "";
                int count = 0;
                while ((line = stream.ReadLine()) != null) {
                    Console.WriteLine($"Line {++count}: {line}");
                }
            }


            /*
             
            V StreamReader ima npolzvame, nie polzvahme samo ReadLine() no ima oshte mnogo
            proveri kato napravish nova instanciq na tozi klas i napishi .   shte ti izlqzat mnogo.
            */



            //PRIMER SUS StreamWriter :

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






            /*
             
            V .NET 
             Za chetene i pisane na fail vuv C#mojem da polzvame i :
                01.File.ReadAllText("filename");
                02.File.WriteAllLines("filename");

            File klasa ima mnogo neshta za polzvane.
            


            V .NET Streamovete rabotat taka:

            StreamReaders / StreadWriters:
                01.StreamReader / StreamWriter
                02.BinaryReader / BinaryWriter   -   Tova e za kartinki primerno
                03.XmlREader / XmlWriter      -     polzvahme go v kursa po bazi danni
            
            Decorator Streams: (Funkcionalnosti)
                01.GZipStream       -     kompresita
                02.CryptoStream     -     kriptira
                03.BufferedStream

            Base Backing Store:  (Bazovi klasove)
                01.FileStream
                02.MemoryStream
                03.NetworkStream

            Backing Store:
                Hardware: failove, pamet, mrejovi ustroistva
             
             
             
             Vsichki Streamove nasledqvat biblitekata System.IO.Stream;
             Streamovete chett, pishat, proverqvat i dr. Mogat da peekvat t.e. samo 
             da gledat bez da pravat nishto.
            
            
            Stream metods:
                01.Close()     -     zatvarq streama
                02.Seek();     -     premestvame nashata poziciq v streama, mojem da zapochnem da chetem t sredata primerno !!!

                Ako polzvame buffer, sus metoda .Flush() mojem da izchistim buffera
                
            Sus FileStream() mojem da chetem i da pishem ednovremenno v daden fail NO E LOSHA PRAKTIKA.
            I DAVA MNOGO EXCEPTIONI !!!
            Mojem da go napravim taka che dokato nie chetem ili pishem vuv faila nqkoi drug da moje da go pravi 
            na sushtiq fail.

            Ima razlichni konstruktori:
                File name
                File open mode
                File access mode



            Po napred shte se nauchim da overwritvame metodi i da si definirame 
            sami nashi si metodi.

             */

            Console.WriteLine();

            //AKO NE POLZVAME using(){} TRQBVA DA POLZVAME SLEDNOTO:

            //FileStream Example:
            string text = "Кирилица";
            FileStream fileStream = null;
            try
            {
                //s vtoriq parametur mu podavame mode, koeto e za suzdavane na fail.
                fileStream = new FileStream("log.txt", FileMode.Create);

                //za da zapishem texta ni trqbvat baitovete mu, tova stava po sledniq nachin
                //Polzvame UTF, vsqka bukva se opisva s po dva baita t.e. za 8 bukvi imame 16 baita
                var bytes = System.Text.Encoding.UTF8.GetBytes(text);

                //podavame baitovete na streama
                //podavame mu offset 0 za da zapochne ot nuleviq element 
                //i za count mu kazvame da vzeme vsichki t.e. do bytes.length
                fileStream.Write(bytes, 0, bytes.Length);
                
                //SEGA IMAME SUZDADEN FAIL log.txt V KOITO PISHE Кирилица
            }
            finally
            {
                //Ako ne polzvame using
                //zaduljitelno trqbva da zatvorim streama 
                fileStream.Close();   
            }


            //NQKOI SINVOLI OT ASCII TABLICATA VZIMAT I PO 3, 4 BAITA


            Console.WriteLine();


            /*KOPIRANE NA FAILOVE, SNIMKI I DR. OT VUNSHEN FAIL KUM NOV SUZDADEN OT NAS FAIL:*/
            //Po princip ima i po lesen nachin, mojem da polzvame File.Copy()
            //vmesto FileStream

            //Otvarqme faila, moje da e i snimka kakto v sluchaq 
            using (var sourceFile = new FileStream("froachVSgroves.jpg", FileMode.Open))
            {
                // i sega go zapisvame v drug fail
                using (var destinationFail = new FileStream("copyImg.jpg", FileMode.Create))
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
                        destinationFail.Write(buffer, 0, readBytesCount);

                    }

                    //VAJNO !!!
                    //MNOGO PO LESNO STAWA S File.Copy(. . .);
                }
            }

           


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

                for (int i = 0; i <  memoryStream.Length; i++)
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

            //SEGA ZNAESH CHE KO PISHESH SMS-i NA KIRILICA ZAEMAT MDVOINO POVECHE BAYTOVE (SINVOLI)




            //NETWORK STREAM:
            //Simulaciq na networkStream ne e lesno neshto !!!!!!!

            //WEB SERVER EXAMPLE RAZGLEDAI ZADACHA 06.WebServer

            //NASHIQ SERVER POLUCHAVA ZAQVKA KOQTO Q PRINTIRA NA KONZOLATA 
            //I VRUSHTA RESPONSE KUM BRAWSERA, DNESHNATA DATA.



            /*
            Buffered Stream:
                Polzvat se kogato iskame da rabotim s failove ili streamove.

                Buferiraneto na dannite e dobra praktika kato cqlo.
                KAK STAVA ?
                Ami mnogo e prosto, primerno chetem samo 10 megabaita ot daden fail
                i gi zapisvame v buffera, posle rabotim s tezi danni zapisani v bufera
                vmesto da se obrushtame kum fila vseki put.

             Zarejdaneto do bufera stava po bavno no posle cheteneto stava adski burzo.

            .Flush() e mnogo vajen metod ako NE polzvame using(){...}!!!
                
             */


            // .ReadToEnd() e metod ot StreamReadera koito ni vrushta vsichko ot faila kato string


            /*
             Other Streams:
                01.CryptoStream  -  Ideqta e tova koeto kriptirame da mojem da go dekriptirame, ima mnogo algoritmi v neta
                02.GZipStream  -  Kompresire i Dekompresira, ima i po prosti biblioteki za tova !!!
                03.PipedStream  -  Pozvolqva da svurjem konzolno prilojenie kum web server no e trudno !!!

            TEZI STREAMOVE SA MALKO ZA PO NAPREDNALI !!!
             */



            /*
             Summary:
                01.Streamovete sa poredici ot baitove, mojem da chetem bez da sme gi 
                    zaredili izcqlo a samo tezi koito sa ni zaredeni v bufera,
                    streamovete sa poredica ot nuli i edinici, polzvai go v using(){...}
                
                02.Moje da chetem, pishem ili i dvete ednovremenno koeto obache ne e mnogo dobra praktika.
                
                03.Vidove streamove: File, Network, Memory etc...

                04.Imame readeri i writteri za streamovete za da ni e po qsno dali iskame da chetem ili pishem
                    mojem da chetem samo edin red, vsichki na vednij koeto vrushta string, imame i drugi metodi ...
             
             */


        }
    }
}

using System;
using System.IO;

namespace _04.Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream sourceFail = new FileStream("copyMe.png", FileMode.Open))
            {
                using (FileStream destinationFile = new FileStream("destinationCopy.png", FileMode.Create))
                {
                    //pravim si buffer za da slagame prochetenoto v nego ! 
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        //chetem ot source faila ot 0 do 4096 i zapisvame v bufera
                        var readBytesCount = sourceFail.Read(buffer, 0, buffer.Length);

                        //ako veche nqma kakvo da chetem izlizame ot cikula
                        if (readBytesCount == 0)
                            break;

                        //i zapisvame v destination faila
                        destinationFile.Write(buffer, 0, 4096);
                    }
                }
            }
        }
    }
}

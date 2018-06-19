using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _06.WebServer
{
    //WEB SERVER SIMULATOR : WEB SERVERITE NE SE PRAVAT TAKA, CELTA E TUK DA VIDIM NETWORK STREAM !!!
    class Program
    {
        //Pravim si port na koito da zakachim programata ni
        private const int PortNumber = 1337;

        // VAJNO E DA ZNAEM CHE REALNITE SERVERI SA NA PORT 80 ILI 443
        // Za http:// serverite sa na port 80    -   probvai da napishesh v searchbara na brawsera: https://www.dir.bg:80/
        // Za https:// serverite sa na port 443  -   probvai da napishesh v searchbara na brawsera: https://www.google.bg:443/

        static void Main(string[] args)
        {
            //Trqbva ni LISTENER koito da slusha za idvashti requesti na dadeniq ot nas PORT:
            var tcpListener = new TcpListener(IPAddress.Any, PortNumber);

            //Startirame go :
            tcpListener.Start();
            Console.WriteLine("Listening on port {0}...", PortNumber);

            //Kogato doide nqakuv request trqbv da go obrabotim:
            while (true)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    //01.Purvo go prochitame
                    byte[] request = new byte[4096];
                    int readBytes = stream.Read(request, 0, 4096);

                    //02.Decodvame go kato polzvame .GetString()
                    var encodedRequest = Encoding.UTF8.GetString(request, 0, readBytes);

                    //03.Printirame go
                    Console.WriteLine(encodedRequest);


                    //04 Sega iskame da printirame neshto na nashiq brawser za da vidim che
                    //toi se e svurzal s nashata programka i tq mu vrushta daden response.
                    //Shte printirame dneshnata data i nqkakvi stringove !!!
                    string html = string.Format("HTTP/1.1 200 OK\nContent-Type:text\n\n" + 
                        "{0}{1}{2}{3}<br>{4}{2}{1}{0}", 
                        "<html>", "<body>", "<h1>", "Welcome to my awesome site!", DateTime.Now);

                    //vzimame baitovete ot html
                    byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                    
                    //i gi vrushtame v stream
                    stream.Write(htmlBytes, 0, htmlBytes.Length);
                    
                }
            }


        }
    }
}

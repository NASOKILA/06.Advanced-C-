

namespace Multidimentional_Arrays_Lab
{
    using System;
    using System.Linq;

    class Program
    {
        
        static void Main(string[] args)
        {
            /*
             DATA STRUCTURES:
                1.Arrays
                2.Lists
                3.Objects
                4.Steck
                5.Queue
                6.Dictionary
                7.Hashset
                ...
             
             */

            /*
             Multidimentional Arrays:
                Te sa kato tablici
                Tova e kato kub, NE SE POLZVA MNOGO, NAI VECHE V PRAVENETO NA IGRI.
                
                MOGAT DA IMAT POVECHE OT EDNO IZMERENIE.

                AKO IMA 2 IZMERENIQ ZNACHI E KATo MATRICA I 
                se dostupvat sus ROW i COL kakto matricite.
                 [...][...]


                AKO IMA 3 IZMERENIQ ZNACHI STAVA KATO KUB.
                [...][...][...]
                
            
             */


            /*
            Matrixes:
               TOVA E MASIV OT MASIVI S EDNAKKUV BROI REDOVE 
                I KOLONI!!!!!!!!!!!!!!!!!
                
            */

            

            //PRI DEFINIRANETO SE SLAGAT ZAPETAI MEJDU SKOBITE
            int[,] intMatrix;  //Dvoizmeren masiv

            float[,] floatMatrix;  //Dvoizmeren masiv

            string[,,] stringCube;  //Triizmeren masiv sus DVE ZAPETAI [,,]



            //ZA DEKLARACIQ I INICIALIZIRANE MOJE DA SE POLZVA I 'new' !!!!!!!!!!!!

            int[,] intMatrix2 = new int[3, 4]; //kazvame i kolko redove i kolonki ima !!!

            float[,] floatMatrix2 = new float[8, 2]; //kazvame i kolko redove i kolonki ima !!!

            string[,,] stringCube2 = new string[5, 5, 5];

            //VSICHKI TEZI REDOVE I KOLONI SHTE BUDAT 0 !!!!!!



            //Inline Inicialization:  
            //MOJEM DIREKTNO I DA POPULNIM STOINOSTITE !!!!!!!!!!!!!!

            int[,] intMatrix3 = {  
                //Direktno si vkarvame stonostite vutre !!!
                { 1, 2, 3, 4},
                { 5, 6, 7, 8}
            };

            //                  row,col
            int im3 = intMatrix3[0, 3];
            Console.WriteLine(im3); //4

            float[,] floatMatrix3 = {
                //Direktno si vkarvame stonostite vutre !!!
                { 2.5f, 6.12f, 65.23f, 5.111f},
                { 2.12f, 78.11f, 43.66f, 453.1f}
            };

            //                  row, col
            float f3 = floatMatrix3[1, 2];
            Console.WriteLine(f3); //43.66


            string[,,] stringMatrix3 = {

                {
                    { "a1","a2","a3","a4","a5"},
                    { "a6","a7","a8","a9","a10"}
                },
                {
                    { "b1","b2","b3","b4","b5"},
                    { "b6","b7","b8","b9","b10"}
                },
                {
                    { "c1","c2","c3","c4","c5"},
                    { "c6","c7","c8","c9","c10"}
                }
            };
            //                       1D,  2D,  3D
            //                      row, col, elem
            string sm3 = stringMatrix3[1, 0, 3];
            Console.WriteLine(sm3); // b4


            //Mojem i da smenqvame stoinotsi, MNOGO E LESNO.

            sm3 = "b555";
            Console.WriteLine(sm3); // b555


            Console.WriteLine();
            Console.WriteLine("Print Matrix:");
            //Printirane na matrica:

            int[,] matrixToPrint = {
                {1, 2, 3, 4, 5},
                {6, 7, 8, 9, 10},
                {11, 12, 13, 14, 15}
            };


            //Sus .GetLength(...)  PODAVAME IZMERENIETO TAM
            //NE TRQBVA DA POLZVAME .Length
            for (int row = 0; row < matrixToPrint.GetLength(0); row++) {

                for (int col = 0; col < matrixToPrint.GetLength(1); col++)
                {
                    Console.Write(matrixToPrint[row,col] + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine();
            Console.WriteLine("Print 3D Cube :");
            //KAK SE PRINTIRA 3D KUB ?
            int[,,] cube3d = {
                {{1,2,3}, {4,5,6}, {7,8,9}},
                {{10,11,12}, {13,14,15},{16,17,18}},
                {{19,20,21},{22,23,24},{25,26,27}}
            };

            for (int row = 0; row < cube3d.GetLength(0); row++)
            {
                for (int col = 0; col < cube3d.GetLength(1); col++)
                {
                    for (int elem = 0; elem < cube3d.GetLength(2); elem++)
                    {
                        Console.Write(cube3d[row, col, elem] + " ");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }


            /*
             * VAJNO !!!
                Matricite ne sa statichni kato spisucite, ne mojem sled inicializaciqta 
                prosto da dobavim nov red i kolona !!!
                Za da go napravim trqbva da napravim nova matrica koqto da sudurja 
                starata plus novite elementi koito iskame da dobavim.
            
                I ne mojem da prezpisvame cql red na vednuj kato mu podadem masiv zashtoto ochakva 
                dva parametura !!!
             
             */



            Console.WriteLine();
            Console.WriteLine("Jagged Arrays:");
            /*
             Jagged Arrays:   Nazuben masiv !!!
                
                TOVA E MASIV OT MASIVI KOITO NQMAT EDNAKKUV BROI REDOVE 
                I KOLONI!!!!!!!!!!!!!!!!!
                
                S tqh mojem da napravim poveche neshta ot kolkoto s matrica, 
                obache matricite ni davat ogranicheniq CompileTimeError i ne ni 
                pozvolqva da pravim BUGOVE.
                
                
                Razlichni sa ot matricite zashtoto moje redicite da ne sa s ednakuv 
                broi kakto kolonite.

                Te sa bukvalno MASIV OT MASIVI i vseki masiv ima razlichna duljina.
                
                
             */
             
            int[][] jagged = new int[3][];
            jagged[0] = new int[3];
            jagged[1] = new int[2];
            jagged[2] = new int[1];

            //V masiva imam tri masiva, vseki s razlichna duljina

            //purviq masiv ima length 3
            Console.WriteLine(jagged[0][0] = 1);
            Console.WriteLine(jagged[0][1] = 2);
            Console.WriteLine(jagged[0][2] = 3);
            
            //vtoriq masiv ima length 2
            Console.WriteLine(jagged[1][0] = 4);
            Console.WriteLine(jagged[1][1] = 5);
            
            //tretiq masiv ima length 1
            Console.WriteLine(jagged[2][0] = 6);


            Console.WriteLine();
            
            //Mojem i da go napulnim s for cikul:
            //shte ima 3 redici (MOJE DA E I 'n' OT KONZOLTA) i neznaino kolko koloni
            int[][] jaggedArray = new int[3][];

            for (int row = 0; row < 3; row++) {
                Console.WriteLine("Write some numbers separated by ',' to fill one of the rows of the Jagged array :");
                jaggedArray[row] = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            }


            //Printirame cqliq NAZUBEN MASIV (Jagged Array)
            Console.WriteLine();
            Console.WriteLine("Print jagged array:");
            for (int row = 0; row < jaggedArray.GetLength(0); row++){
                for (int col = 0; col < jaggedArray[row].Length; col++){
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }




            //VAJNO !!!
            //Po proncip pri matricite se polzva .GetLength(...) zashtoto ima dimenciq
            //A pri Jagged Arrays se polzva samo .Length zashtoto e masiv ot masivi no moje i sus .GetLength()



            /*
                
                    VAJNO !!!!! : 
                        Matricite sa razlichni ot nazubenite masivi, nqmat nishto
                        obshto, nazubenite masivi sa masivi s masivi i nqmat ednakkuv broi row i cols !
                    
                SUMMARY:
                    Matrices: They have more than one dimention, 2D Matrixes are like tables 
                        with rows and cols
                        3D Matrices have x, y and z 
                    Matrixes are NOT that hard to understand
                    
                    Jagged Arrays:
                        They are very deferent from the matrixes, they are arrays of arrays,
                        Each row is an array itself with deferent length !!!

            */


        }
    }
}






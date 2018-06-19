using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> input2 = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Queue<string> PlayerOneDeck = new Queue<string>();

            Queue<string> PlayerTwoDeck = new Queue<string>();

            foreach (var num in input)
                PlayerOneDeck.Enqueue(num);

            foreach (var num in input2)
                PlayerTwoDeck.Enqueue(num);

            int turns = 0;

            //Dokato na nqkoi ne mu svurshat kartite
            while (PlayerOneDeck.Count > 0 && PlayerTwoDeck.Count > 0)
            {
                string playerOneCurrentCard = PlayerOneDeck.Peek();
                string playerTwoCurrentCard = PlayerTwoDeck.Peek();

                // check if they are equal;

                int cardNumberPlayerOne = int.Parse(playerOneCurrentCard.Remove(playerOneCurrentCard.Length - 1));
                int cardNumberPlayerTwo = int.Parse(playerTwoCurrentCard.Remove(playerTwoCurrentCard.Length - 1));

                if (cardNumberPlayerOne == cardNumberPlayerTwo)
                {

                    //WAR:
                    var PlayerOneFullCards = new List<string>();
                    var PlayerTwoFullCards = new List<string>();

                    var listOfCharsForPlayerOne = new List<char>();
                    var listOfCharsForPlayerTwo = new List<char>();


                    //vzimame purvite 4 karti AKO SE SCHUPI NQMA PROBLEM
                    //Igracha moje da nqma 4 karti v testeto
                    try
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            PlayerOneFullCards.Add(PlayerOneDeck.Peek());
                            char currentChar = PlayerOneDeck.Dequeue().ToString().Last();
                            listOfCharsForPlayerOne.Add(currentChar);
                        }
                    }
                    catch { }

                    try
                    {
                        //vzimame purvite 4 karti AKO SE SCHUPI NQMA PROBLEM
                        for (int j = 0; j < 4; j++)
                        {
                            PlayerTwoFullCards.Add(PlayerTwoDeck.Peek());
                            char currentChar = PlayerTwoDeck.Dequeue().ToString().Last();
                            listOfCharsForPlayerTwo.Add(currentChar);
                        }
                    }
                    catch { }



                    int playerOneSumOfChars = listOfCharsForPlayerOne.Sum(e => e);
                    int playerTwoSumOfChars = listOfCharsForPlayerTwo.Sum(e => e);


                    if (playerOneSumOfChars > playerTwoSumOfChars)
                    {
                        //PlayerOne Wins takes all 4 cards from player one
                        foreach (var card in PlayerTwoFullCards)
                            PlayerOneFullCards.Add(card);

                        //Sega trqbva da gi sortirame i da gi slojim v opashkata
                        var sortedFullCardsP1 = new List<string>();
                        sortedFullCardsP1 = PlayerOneFullCards
                            .OrderByDescending(c => int.Parse(c.Remove(c.Length - 1)))
                            .ThenByDescending(e => e.Last()).ToList();

                        foreach (var card in sortedFullCardsP1)
                            PlayerOneDeck.Enqueue(card);

                    }
                    else if (playerTwoSumOfChars > playerOneSumOfChars)
                    {
                        //PlayerTwo Wins takes all 4 cards from player one
                        foreach (var card in PlayerOneFullCards)
                            PlayerTwoFullCards.Add(card);


                        //Sega trqbva da gi sortirame i da gi slojim v opashkata

                        var sortedFullCardsP2 = new List<string>();
                        sortedFullCardsP2 = PlayerTwoFullCards
                            .OrderByDescending(c => int.Parse(c.Remove(c.Length - 1)))
                            .ThenByDescending(e => e.Last()).ToList();

                        foreach (var card in sortedFullCardsP2)
                            PlayerTwoDeck.Enqueue(card);


                    }
                    else
                    {
                        //They Are Equal its a Draw

                    }


                }
                else if (cardNumberPlayerOne > cardNumberPlayerTwo)
                {
                    //PlayerOne Wins He takes the card of PlayerTwo
                    //slagame vuv testeto na purviq igrach kartata na vtoriq igrach
                    PlayerOneDeck.Enqueue(PlayerTwoDeck.Dequeue());
                    PlayerOneDeck.Enqueue(playerOneCurrentCard);

                    //mahame kartata na purviq igrach
                    try
                    {
                        PlayerTwoDeck.Dequeue();
                    }
                    catch
                    {
                        turns++;
                    }


                }
                else if (cardNumberPlayerOne < cardNumberPlayerTwo)
                {
                    //PlayerTwo Wins He takes the card of PlayerOne

                    //slagame vuv testeto na vtoriq igrach kartata na purviq igrach
                    PlayerTwoDeck.Enqueue(PlayerTwoDeck.Dequeue());
                    PlayerTwoDeck.Enqueue(playerOneCurrentCard);

                    //mahame kartata na purviq igrach
                    
                    try
                    {
                        PlayerOneDeck.Dequeue();
                    }
                    catch
                    {
                        turns++;
                     }

                }

                //zapazvame si promenite v spisucite zashtoto shte ni trqbvat pri voina

                input = PlayerOneDeck.ToList();

                input2 = PlayerTwoDeck.ToList();

                turns++;
            }

            PrintResult(PlayerOneDeck, PlayerTwoDeck, turns);

        }

        private static void PrintResult(Queue<string> PlayerOneDeck, Queue<string> PlayerTwoDeck, int turns)
        {
            if (PlayerOneDeck.Count == 0)
                Console.WriteLine("Second player wins after " + turns + " turns");
            else if (PlayerTwoDeck.Count == 0)
                Console.WriteLine("First player wins after " + turns + " turns");
            else
                Console.WriteLine("Draw after " + turns + "turns");
        }
    }
}



/*
 
     
1f 2f 3f 4g 5f
1m 10m 4m 7m 98b

 */

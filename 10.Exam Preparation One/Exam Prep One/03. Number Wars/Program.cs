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

            while (PlayerOneDeck.Count > 0 && PlayerTwoDeck.Count > 0)
            {
                string playerOneCurrentCard = PlayerOneDeck.Peek();
                string playerTwoCurrentCard = PlayerTwoDeck.Peek();

                int cardNumberPlayerOne = int.Parse(playerOneCurrentCard.Remove(playerOneCurrentCard.Length - 1));
                int cardNumberPlayerTwo = int.Parse(playerTwoCurrentCard.Remove(playerTwoCurrentCard.Length - 1));

                if (cardNumberPlayerOne == cardNumberPlayerTwo)
                {

                    var PlayerOneFullCards = new List<string>();
                    var PlayerTwoFullCards = new List<string>();

                    var listOfCharsForPlayerOne = new List<char>();
                    var listOfCharsForPlayerTwo = new List<char>();

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
                        foreach (var card in PlayerTwoFullCards)
                            PlayerOneFullCards.Add(card);

                        var sortedFullCardsP1 = new List<string>();
                        sortedFullCardsP1 = PlayerOneFullCards
                            .OrderByDescending(c => int.Parse(c.Remove(c.Length - 1)))
                            .ThenByDescending(e => e.Last()).ToList();

                        foreach (var card in sortedFullCardsP1)
                            PlayerOneDeck.Enqueue(card);

                    }
                    else if (playerTwoSumOfChars > playerOneSumOfChars)
                    {
                        foreach (var card in PlayerOneFullCards)
                            PlayerTwoFullCards.Add(card);

                        var sortedFullCardsP2 = new List<string>();
                        sortedFullCardsP2 = PlayerTwoFullCards
                            .OrderByDescending(c => int.Parse(c.Remove(c.Length - 1)))
                            .ThenByDescending(e => e.Last()).ToList();

                        foreach (var card in sortedFullCardsP2)
                            PlayerTwoDeck.Enqueue(card);
                    }
                    else
                    {}

                }
                else if (cardNumberPlayerOne > cardNumberPlayerTwo)
                {
                    PlayerOneDeck.Enqueue(PlayerTwoDeck.Dequeue());
                    PlayerOneDeck.Enqueue(playerOneCurrentCard);

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
                    PlayerTwoDeck.Enqueue(PlayerTwoDeck.Dequeue());
                    PlayerTwoDeck.Enqueue(playerOneCurrentCard);

                    try
                    {
                        PlayerOneDeck.Dequeue();
                    }
                    catch
                    {
                        turns++;
                    }
                }

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
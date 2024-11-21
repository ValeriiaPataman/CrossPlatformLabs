using System;
using System.IO;
using System.Linq;

namespace Library
{
    public static class IOHandler
    {
        private const string InputFileName = "INPUT.TXT";
        private const string OutputFileName = "OUTPUT.TXT";

        public static (int N, int M, char trumpSuit, string[] playerCards, string[] attackCards) ReadGameInput(string inputFilePath)
        {
            if (!File.Exists(inputFilePath))
            {
                throw new Exception($"File {inputFilePath} was not found.");
            }

            var lines = File.ReadAllLines(inputFilePath)
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToArray();

            if (lines.Length != 3)
            {
                throw new Exception("Wrong number of lines in file.");
            }

            var firstLineParts = lines[0].Split(' ');
            int N = int.Parse(firstLineParts[0]);
            int M = int.Parse(firstLineParts[1]);
            char trumpSuit = firstLineParts[2][0];

            var playerCards = lines[1].Split(' ');
            var attackCards = lines[2].Split(' ');

            return (N, M, trumpSuit, playerCards, attackCards);
        }

        public static void WriteGameResult(string result, string outputFilePath)
        {
            if (Directory.Exists(outputFilePath))
            {
                outputFilePath = Path.Combine(outputFilePath, "OUTPUT.TXT");
            }
            File.WriteAllText(outputFilePath, result);
        }
    }

    public class Card
    {
        public char Rank { get; }
        public char Suit { get; }

        public Card(string card)
        {
            Rank = card[0];
            Suit = card[1];
        }

        public bool IsTrump(char trumpSuit)
        {
            return Suit == trumpSuit;
        }

        public bool Beats(Card other, char trumpSuit)
        {
            string ranks = "6789TJQKA";
            if (Suit == other.Suit)
            {
                return ranks.IndexOf(Rank) > ranks.IndexOf(other.Rank);
            }
            return IsTrump(trumpSuit);
        }
    }

    public class Game
    {
        private readonly Card[] playerCards;
        private readonly Card[] attackCards;
        private readonly char trumpSuit;

        public Game(string[] playerCardStrings, string[] attackCardStrings, char trumpSuit)
        {
            playerCards = playerCardStrings.Select(card => new Card(card)).ToArray();
            attackCards = attackCardStrings.Select(card => new Card(card)).ToArray();
            this.trumpSuit = trumpSuit;
        }

        public bool CanDefend()
        {
            var availableCards = playerCards.ToList();
            foreach (var attackCard in attackCards)
            {
                var coverCard = availableCards.FirstOrDefault(card => card.Beats(attackCard, trumpSuit));
                if (coverCard == null)
                {
                    return false;
                }
                availableCards.Remove(coverCard);
            }
            return true;
        }
    }

    public static class Lab1
    {
        public static void Run(string inputFilePath, string outputFilePath)
        {
            Console.WriteLine($"Input File Path: {inputFilePath}");
            Console.WriteLine($"Output File Path: {outputFilePath}");
            try
            {
                var (N, M, trumpSuit, playerCards, attackCards) = IOHandler.ReadGameInput(inputFilePath);
                var game = new Game(playerCards, attackCards, trumpSuit);

                string result = game.CanDefend() ? "YES" : "NO";
                IOHandler.WriteGameResult(result, outputFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}

using System;
using System.IO;

namespace Library
{
    public static class IOHandler2
    {
        private const string InputFileName = "INPUT.TXT";
        private const string OutputFileName = "OUTPUT.TXT";

        public static (int[] Coins, int K) ReadDataFromFile(string inputFilePath)
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

            int N = int.Parse(lines[0]);
            int[] coins = lines[1].Split(' ').Select(int.Parse).ToArray();
            int K = int.Parse(lines[2]);

            if (coins.Length != N)
            {
                throw new Exception("The number of coin denominations doesn't match the value of N.");
            }

            return (coins, K);
        }

        public static void WriteResultToFile(int result, string outputFilePath)
        {
            if (Directory.Exists(outputFilePath))
            {
                outputFilePath = Path.Combine(outputFilePath, "OUTPUT.TXT");
            }
            File.WriteAllText(outputFilePath, result.ToString());
        }
    }

    public static class CoinChangeService
    {
        public static int GetMinCoins(int[] coins, int K)
        {
            Array.Sort(coins, (a, b) => b.CompareTo(a));
            int count = 0;

            foreach (var coin in coins)
            {
                if (K == 0) break;
                count += K / coin;
                K %= coin;
            }

            return K == 0 ? count : -1;
        }
    }

    public static class Lab2
    {
        public static void Run(string inputFilePath, string outputFilePath)
        {
            Console.WriteLine($"Input File Path: {inputFilePath}");
            Console.WriteLine($"Output File Path: {outputFilePath}");
            try
            {
                var (coins, K) = IOHandler2.ReadDataFromFile(inputFilePath);
                int result = CoinChangeService.GetMinCoins(coins, K);
                IOHandler2.WriteResultToFile(result, outputFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}


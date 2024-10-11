using System;
using System.IO;
using System.Linq;
namespace App;

public static class IOHandler
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static (int[] Coins, int K) ReadDataFromFile()
    {
        if (!File.Exists(InputFileName))
        {
            throw new Exception($"Файл {InputFileName} не було знайдено.");
        }

        var lines = File.ReadAllLines(InputFileName)
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        if (lines.Length != 3)
        {
            throw new Exception("Неправильна кількість рядків у файлі.");
        }

        int N = int.Parse(lines[0]);
        int[] coins = lines[1].Split(' ').Select(int.Parse).ToArray();
        int K = int.Parse(lines[2]);

        if (coins.Length != N)
        {
            throw new Exception("Кількість номіналів не відповідає значенню N.");
        }

        return (coins, K);
    }

    public static void WriteResultToFile(int result)
    {
        File.WriteAllText(OutputFileName, result.ToString());
    }
}

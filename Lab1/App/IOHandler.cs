namespace App;
using System.IO;
using System.Linq;

public static class IOHandler
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static (int N, int M, char trumpSuit, string[] playerCards, string[] attackCards) ReadGameInput()
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

        var firstLineParts = lines[0].Split(' ');
        int N = int.Parse(firstLineParts[0]);
        int M = int.Parse(firstLineParts[1]);
        char trumpSuit = firstLineParts[2][0];

        var playerCards = lines[1].Split(' ');
        var attackCards = lines[2].Split(' ');

        return (N, M, trumpSuit, playerCards, attackCards);
    }

    public static void WriteGameResult(string result)
    {
        File.WriteAllText(OutputFileName, result);
    }
}

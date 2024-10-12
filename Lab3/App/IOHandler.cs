using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace App;

public static class IOHandler
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static (Graph graph, int citiesCount) ReadDataFromFile()
    {
        if (!File.Exists(InputFileName))
        {
            throw new Exception($"Файл {InputFileName} не було знайдено.");
        }

        var lines = File.ReadAllLines(InputFileName)
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        if (lines.Length < 3)
        {
            throw new Exception("Неправильна кількість рядків у файлі.");
        }

        var firstLine = lines[0].Split(' ');
        int n = int.Parse(firstLine[0]);
        int m = int.Parse(firstLine[1]);

        Graph graph = new Graph(n);

        for (int i = 1; i <= m; i++)
        {
            var parts = lines[i].Split(' ');
            int u = int.Parse(parts[0]);
            int v = int.Parse(parts[1]);
            int cost = int.Parse(parts[2]);
            graph.AddEdge(u, v, cost, i);
        }

        return (graph, n);
    }

    public static void WriteResultToFile(int cost, int[] channelIndices)
    {
        File.WriteAllText(OutputFileName, $"{cost} {channelIndices.Length}\n{string.Join(" ", channelIndices)}");
    }
}
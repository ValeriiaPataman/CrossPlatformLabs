using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace App;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;

        Graph graph;
        int citiesCount;

        try
        {
            (graph, citiesCount) = IOHandler.ReadDataFromFile();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Помилка під час зчитування файлу: {e.Message}");
            return;
        }

        PathFinder pathFinder = new PathFinder(graph);
        pathFinder.FindMinCostPath();

        var result = pathFinder.GetResult();
        try
        {
            IOHandler.WriteResultToFile(result.cost, result.channelIndices);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Помилка під час запису файлу: {e.Message}");
        }
    }
}

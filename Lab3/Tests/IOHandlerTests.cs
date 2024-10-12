using App;
using System;
using System.IO;
using Xunit;

public class IOHandlerTests
{
    [Fact]
    public void ValidInput_ReturnsGraphAndCitiesCount()
    {
        var input = "3 3\n1 2 5\n1 3 10\n3 2 1";
        File.WriteAllText("INPUT.TXT", input);

        var (graph, citiesCount) = IOHandler.ReadDataFromFile();

        Assert.Equal(3, citiesCount);
        Assert.Equal(2, graph.AdjacencyList[1].Count);
    }

    [Fact]
    public void FileNotFound_ThrowsException()
    {
        File.Delete("INPUT.TXT"); 

        var exception = Assert.Throws<Exception>(() => IOHandler.ReadDataFromFile());
        Assert.Equal("Файл INPUT.TXT не було знайдено.", exception.Message);
    }

    [Fact]
    public void WritesCorrectResultToOutputFile()
    {
        IOHandler.WriteResultToFile(6, new[] { 1, 2 });

        var output = File.ReadAllText("OUTPUT.TXT");
        Assert.Equal("6 2\n1 2", output.Trim());
    }
}
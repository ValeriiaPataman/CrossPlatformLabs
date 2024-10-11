using App;
using Xunit;
using System.IO;

namespace Tests;

public class IOHandlerTests
{
    [Fact]
    public void TestReadGameInput()
    {
        var inputContent = "6 2 C\nKD KC AD 7C AH 9C\n6D 6C";
        File.WriteAllText("INPUT.TXT", inputContent);

        var (N, M, trumpSuit, playerCards, attackCards) = IOHandler.ReadGameInput();

        Assert.Equal(6, N);
        Assert.Equal(2, M);
        Assert.Equal('C', trumpSuit);
        Assert.Equal(new[] { "KD", "KC", "AD", "7C", "AH", "9C" }, playerCards);
        Assert.Equal(new[] { "6D", "6C" }, attackCards);
    }

    [Fact]
    public void TestWriteGameResult()
    {
        IOHandler.WriteGameResult("YES");

        var outputContent = File.ReadAllText("OUTPUT.TXT");
        Assert.Equal("YES", outputContent);
    }
}

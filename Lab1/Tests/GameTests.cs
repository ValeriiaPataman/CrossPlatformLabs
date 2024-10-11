using App;
using Xunit;

namespace Tests;

public class GameTests
{
    [Fact]
    public void TestCanDefendSuccess()
    {
        var playerCards = new[] { "KD", "KC", "AD", "7C", "AH", "9C" };
        var attackCards = new[] { "6D", "6C" };
        var game = new Game(playerCards, attackCards, 'C');

        var result = game.CanDefend();

        Assert.True(result);
    }

    [Fact]
    public void TestCannotDefendFailure()
    {
        var playerCards = new[] { "9S", "KC", "AH", "7D" };
        var attackCards = new[] { "8D" };
        var game = new Game(playerCards, attackCards, 'D');

        var result = game.CanDefend();

        Assert.False(result);
    }

    [Fact]
    public void TestCanDefendAllTrumps()
    {
        var playerCards = new[] { "AS", "KS", "QS", "JS" };
        var attackCards = new[] { "6S", "7S", "8S", "9S" };
        var game = new Game(playerCards, attackCards, 'S');

        var result = game.CanDefend();

        Assert.True(result);
    }
}

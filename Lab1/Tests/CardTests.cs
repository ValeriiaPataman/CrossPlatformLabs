using App;
using Xunit;

namespace Tests;

public class CardTests
{
    [Fact]
    public void TestCardBeatsSameSuit()
    {
        var card1 = new Card("9C");
        var card2 = new Card("8C");

        var result = card1.Beats(card2, 'S');

        Assert.True(result);
    }
    [Fact]
    public void TestCardBeatsTrumpCard()
    {
        var card1 = new Card("6S");
        var card2 = new Card("9D");

        var result = card1.Beats(card2, 'S');

        Assert.True(result);
    }

    [Fact]
    public void TestCardCannotBeatTrumpCardWithLowerRank()
    {
        var card1 = new Card("7S");
        var card2 = new Card("KS");

        var result = card1.Beats(card2, 'S');

        Assert.False(result);
    }
}
namespace App;

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

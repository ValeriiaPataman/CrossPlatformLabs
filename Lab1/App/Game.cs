namespace App;
using System.Linq;

public class Game
{
    private readonly Card[] playerCards;
    private readonly Card[] attackCards;
    private readonly char trumpSuit;

    public Game(string[] playerCardStrings, string[] attackCardStrings, char trumpSuit)
    {
        playerCards = playerCardStrings.Select(card => new Card(card)).ToArray();
        attackCards = attackCardStrings.Select(card => new Card(card)).ToArray();
        this.trumpSuit = trumpSuit;
    }

    public bool CanDefend()
    {
        var availableCards = playerCards.ToList();
        foreach (var attackCard in attackCards)
        {
            var coverCard = availableCards.FirstOrDefault(card => card.Beats(attackCard, trumpSuit));
            if (coverCard == null)
            {
                return false;
            }
            availableCards.Remove(coverCard);
        }
        return true;
    }
}

namespace App;

public static class Program
{
    public static void Main()
    {
        try
        {
            var (N, M, trumpSuit, playerCards, attackCards) = IOHandler.ReadGameInput();
            var game = new Game(playerCards, attackCards, trumpSuit);

            string result = game.CanDefend() ? "YES" : "NO";
            IOHandler.WriteGameResult(result);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Виникла помилка: {e.Message}");
        }
    }
}

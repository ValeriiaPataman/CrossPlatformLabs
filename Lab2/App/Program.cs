using System;
using System.Text;

namespace App;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;

        int[] coins;
        int K;

        try
        {
            (coins, K) = IOHandler.ReadDataFromFile();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Помилка під час зчитування файлу: {e.Message}");
            return;
        }

        int result;
        try
        {
            result = CoinChangeService.GetMinCoins(coins, K);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Помилка під час знаходження розв'язку: {e.Message}");
            return;
        }

        try
        {
            IOHandler.WriteResultToFile(result);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Помилка під час запису файлу: {e.Message}");
        }
    }
}

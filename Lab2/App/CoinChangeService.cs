using System;

namespace App;

public static class CoinChangeService
{
    public static int GetMinCoins(int[] coins, int K)
    {
        Array.Sort(coins, (a, b) => b.CompareTo(a)); // Сортуємо в порядку спадання
        int count = 0;

        foreach (var coin in coins)
        {
            if (K == 0) break;
            count += K / coin;
            K %= coin;
        }

        return K == 0 ? count : -1;
    }
}

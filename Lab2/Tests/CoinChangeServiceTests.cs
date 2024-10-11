using App;
using System;
using Xunit;

namespace Tests
{
    public class CoinChangeServiceTests
    {
        [Fact]
        public void ValidInput_ReturnsCorrectCount()
        {
            var coins = new int[] { 1, 5, 7 };
            int K = 19;

            int result = App.CoinChangeService.GetMinCoins(coins, K);

            Assert.Equal(3, result);
        }

        [Fact]
        public void InsufficientCoins_ReturnsMinusOne()
        {
            var coins = new int[] { 5, 10 };
            int K = 7;

            int result = App.CoinChangeService.GetMinCoins(coins, K);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void ZeroK_ReturnsZeroCount()
        {
            var coins = new int[] { 1, 5, 7 };
            int K = 0;

            int result = App.CoinChangeService.GetMinCoins(coins, K);

            Assert.Equal(0, result);
        }

        [Fact]
        public void LargeK_ReturnsCorrectCount()
        {
            var coins = new int[] { 1, 2, 5 };
            int K = 11;

            int result = App.CoinChangeService.GetMinCoins(coins, K);

            Assert.Equal(3, result);
        }
    }
}

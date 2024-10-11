using App;
using System;
using System.IO;
using Xunit;

namespace Tests
{
    public class IOHandlerTests
    {

        [Fact]
        public void ValidInput_ReturnsCoinsAndK()
        {
            var input = "3\n1 5 7\n19";
            File.WriteAllText("INPUT.TXT", input);

            var (coins, K) = App.IOHandler.ReadDataFromFile();

            Assert.Equal(new int[] { 1, 5, 7 }, coins);
            Assert.Equal(19, K);
        }


        [Fact]
        public void InvalidLineCount_ThrowsException()
        {
            var input = "3\n1 5 7";
            File.WriteAllText("INPUT.TXT", input);

            var exception = Assert.Throws<Exception>(() => App.IOHandler.ReadDataFromFile());
            Assert.Equal("Неправильна кількість рядків у файлі.", exception.Message);
        }

        [Fact]
        public void InvalidNValue_ThrowsException()
        {
            var input = "3\n1 5\n19";
            File.WriteAllText("INPUT.TXT", input);

            var exception = Assert.Throws<Exception>(() => App.IOHandler.ReadDataFromFile());
            Assert.Equal("Кількість номіналів не відповідає значенню N.", exception.Message);
        }

        [Fact]
        public void WritesCorrectResult()
        {
            int result = 5;

            App.IOHandler.WriteResultToFile(result);
            var output = File.ReadAllText("OUTPUT.TXT");

            Assert.Equal("5", output.Trim());
        }
    }
}

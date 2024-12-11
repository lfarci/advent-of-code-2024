using AdventOfCode.Puzzles;

namespace AdventOfCode.Tests
{
    public class HistorianHysteriaTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1 ")]
        [InlineData("   1")]
        [InlineData("A 1")]
        [InlineData("1 A")]
        [InlineData("1A")]
        public void ParseLine_Invalid_ReturnsEmpty(string invalidInput)
        {
            Assert.Throws<ArgumentException>(() => HistorianHysteria.ParseLine(invalidInput));
        }

        [Theory]
        [InlineData("1 2", 1, 2)]
        [InlineData("3   4", 3, 4)]
        [InlineData("234231 23123423", 234231, 23123423)]
        public void ParseLine_Valid_ReturnsParsed(string input, long expectedLeft, long expectedRight)
        {
            var (left, right) = HistorianHysteria.ParseLine(input);
            Assert.Equal(expectedLeft, left);
            Assert.Equal(expectedRight, right);
        }

        [Fact]
        public void CalculateDistance_Example_ReturnsExpected()
        {
            var distance = HistorianHysteria.CalculateDistanceBetweenLists(new[]
            {
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3"
            });

            Assert.Equal(11, distance);
        }

        [Fact]
        public void CalculateSimilarityScore_Example_ReturnsExpected()
        {
            var distance = HistorianHysteria.CalculateSimilarityScore(new[]
            {
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3"
            });

            Assert.Equal(31, distance);
        }
    }
}

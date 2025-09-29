using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextDividerr;

namespace TextDivider.Tests
{
    public class SplitTextBySeperatorTests
    {
        [Theory]
        [InlineData("a--b--c", "--", new[] { "a", "b", "c" })]
        [InlineData("start|middle|end", "|", new[] { "start", "middle", "end" })]
        [InlineData("no-separator-here", "|", new[] { "no-separator-here" })]
        public void SplitTextBySeperator_VariousCases_ReturnsCorrectParts(string input, string separator, string[] expected)
        {
            // Act
            var result = DivderMethod.SplitTextBySeperator(input, separator);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, "valid")]
        [InlineData("valid", null)]
        [InlineData("", "valid")]
        [InlineData("valid", "")]
        public void SplitTextBySeperator_NullOrEmpty_ThrowsArgumentException(string input, string separator)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => DivderMethod.SplitTextBySeperator(input, separator));
        }

        [Fact]
        public void SplitTextBySeparator_SeparatorAtBoundaries_CorrectHandling()
        {
            // Arrange
            string input = "--a--b--c--";
            string separator = "--";

            // Act
            var result = DivderMethod.SplitTextBySeperator(input, separator);

            // Assert
            Assert.Equal(5, result.Count);     // было 6, станет 5
            Assert.Equal("", result[0]);
            Assert.Equal("a", result[1]);
            Assert.Equal("b", result[2]);
            Assert.Equal("c", result[3]);
            Assert.Equal("", result[4]);       // конечная пустая часть теперь есть
        }
    }
   
}






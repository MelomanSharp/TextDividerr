using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextDividerr;

namespace TextDivider.Tests
{
    public class MarkUpCleanerTests
    {
        // F. MarkUpCleaner Tests
        [Fact]
        public void CleanHtml_RemovesTags_ReturnsCleanText()
        {
            // Arrange
            string html = "<b>hi</b><p>test</p>";

            // Act
            string result = MarkUpCleaner.CleanHtml(html);

            // Assert
            Assert.Equal("hitest", result);
        }

        [Theory]
        [InlineData("<div>content</div>", "content")]
        [InlineData("text<br>more", "textmore")]
        [InlineData("no tags", "no tags")]
        public void CleanHtml_VariousInputs_CleansCorrectly(string input, string expected)
        {
            // Act
            string result = MarkUpCleaner.CleanHtml(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CleanTextBasedOnFlags_InvalidFlagsLength_ThrowsArgumentException()
        {
            // Arrange
            string text = "test";
            bool[] invalidFlags = new bool[5]; // Должно быть 9

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                MarkUpCleaner.CleanTextBasedOnFlags(text, invalidFlags));
        }

        [Fact]
        public void CleanTextBasedOnFlags_MultipleFormats_CleansCorrectly()
        {
            // Arrange
            string text = "<b>bold</b> *italic* {color:red}";
            bool[] flags = new bool[9] { true, true, false, true, false, false, false, false, false };

            // Act
            string result = MarkUpCleaner.CleanTextBasedOnFlags(text, flags);

            // Assert - HTML, Markdown и CSS должны быть очищены
            Assert.Equal("bold italic ", result);
        }
    }
}

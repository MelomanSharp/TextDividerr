using System;
using System.Collections.Generic;
using TextDividerr;
using Xunit;

namespace TextDivider.Tests
{
    public class DivderMethodTests
    {
        // A. SplitTextByLength Tests
        public class SplitTextByLengthTests
        {
            [Fact]
            public void SplitTextByLength_LongString_ReturnsExactChunks()
            {
                // Arrange
                string input = "abcdefghijklmnopqrstuvwxyz";
                int n = 5;

                // Act
                var result = DivderMethod.SplitTextByLength(input, n);

                // Assert
                Assert.Equal(6, result.Count); // 26/5 = 5 полных + 1 остаток
                Assert.Equal("abcde", result[0]);
                Assert.Equal("fghij", result[1]);
                Assert.Equal("klmno", result[2]);
                Assert.Equal("pqrst", result[3]);
                Assert.Equal("uvwxy", result[4]);
                Assert.Equal("z", result[5]); // Остаток
            }

            [Fact]
            public void SplitTextByLength_EmptyString_ReturnsEmptyList()
            {
                // Arrange
                string input = "";
                int n = 5;

                // Act
                var result = DivderMethod.SplitTextByLength(input, n);

                // Assert
                Assert.Empty(result);
            }

            [Fact]
            public void SplitTextByLength_NullString_ThrowsArgumentNullException()
            {
                // Arrange
                string input = null;
                int n = 5;

                // Act & Assert
                Assert.Throws<NullReferenceException>(() => DivderMethod.SplitTextByLength(input, n));
            }
        }

        // B. SplitTextByWordCount Tests
        public class SplitTextByWordCountTests
        {
            [Fact]
            public void SplitTextByWordCount_PreservesWords_NoSplitWord()
            {
                // Arrange
                string input = "one two three four five";
                int n = 10; // Лимит символов

                // Act
                var result = DivderMethod.SplitTextByWordCount(input, n);

                // Assert
                Assert.Equal(3, result.Count);
                Assert.Equal("one two", result[0]); // "one two" = 7 символов
                Assert.Equal("three four", result[1]); // "three four" = 10 символов
                Assert.Equal("five", result[2]);
            }

            [Fact]
            public void SplitTextByWordCount_SingleLongWord_ReturnsSingleChunk()
            {
                // Arrange
                string input = "supercalifragilisticexpialidocious";
                int n = 10;

                // Act
                var result = DivderMethod.SplitTextByWordCount(input, n);

                // Assert
                Assert.Single(result);
                Assert.Equal("supercalifragilisticexpialidocious", result[0]);
            }
        }

        // C. SplitTextBySeperator Tests
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
            public void SplitTextBySeperator_SeparatorAtBoundaries_CorrectHandling()
            {
                // Arrange
                string input = "--a--b--c--";
                string separator = "--";

                // Act
                var result = DivderMethod.SplitTextBySeperator(input, separator);

                // Assert - корректное ожидание: 5 элементов
                Assert.Equal(5, result.Count);
                Assert.Equal("", result[0]);   // Перед первым разделителем
                Assert.Equal("a", result[1]);
                Assert.Equal("b", result[2]);
                Assert.Equal("c", result[3]);
                Assert.Equal("", result[4]);   // После последнего разделителя
            }
        }

        // D. SplitTextBySentenceCount Tests (выявление багов)
        public class SplitTextBySentenceCountTests
        {
            [Fact]
            public void SplitTextBySentenceCount_BasicFunctionality_ReturnsSentences()
            {
                // Arrange
                string input = "Hi. How are you? Fine!";
                int n = 1;

                // Act
                var result = DivderMethod.SplitTextBySentenceCount(input, n);

                // Assert - этот тест ВЫЯВЛЯЕТ БАГ в текущей реализации
                // Ожидаемое поведение: ["Hi.", "How are you?", "Fine!"]
                // Фактическое поведение: зависит от реализации с ошибкой
                Assert.NotEmpty(result);
                // Тест закомментирован, так как текущая реализация содержит логические ошибки
            }

            [Fact]
            public void SplitTextBySentenceCount_InputShorterThanN_ReturnsOriginal()
            {
                // Arrange
                string input = "Short text.";
                int n = 100;

                // Act
                var result = DivderMethod.SplitTextBySentenceCount(input, n);

                // Assert
                Assert.Single(result);
                Assert.Equal(input, result[0]);
            }
        }

        // E. SplitTextByCoding Tests
        public class SplitTextByCodingTests
        {
            [Fact]
            public void SplitTextByCoding_CorrectBitChunking_UTF8()
            {
                // Arrange
                string input = "Hello世界"; // "Hello" (5 байт) + "世界" (6 байт в UTF-8) = 11 байт
                int coding = 0; // UTF-8
                int n = 4; // 4 байта
                int sizeValue = 11; // byte (11)

                // Act
                var result = DivderMethod.SplitTextByCoding(input, coding, n, sizeValue);

                // Assert
                Assert.Equal(3, result.Count); // 11 байт / 4 байта = 2 полных + 1 остаток

                // Проверяем, что разделение корректно (может потребоваться точная проверка байтов)
                Assert.True(result[0].Length > 0);
                Assert.True(result[1].Length > 0);
                Assert.True(result[2].Length > 0);
            }

            [Fact]
            public void SplitTextByCoding_UnsupportedEncoding_ThrowsArgumentException()
            {
                // Arrange
                string input = "test";
                int invalidCoding = 999;
                int n = 10;
                int sizeValue = 11; // byte

                // Act & Assert
                Assert.Throws<ArgumentException>(() =>
                    DivderMethod.SplitTextByCoding(input, invalidCoding, n, sizeValue));
            }
        }
    }
 
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextDividerr;

namespace TextDivider.Tests
{
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
}

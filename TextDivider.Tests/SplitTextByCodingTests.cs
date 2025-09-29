using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextDividerr;

namespace TextDivider.Tests
{
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

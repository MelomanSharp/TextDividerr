using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextDividerr
{
    static public class DivderMethod
    {
        public static List<string> SplitTextByLength(string input, int n)
        {
            return Enumerable.Range(0, input.Length / n)
                .Select(i => input.Substring(i * n, n))
                .ToList();
        }

        public static List<string> SplitTextByLastWord(string input, int n)
        {
            var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<string>();

            int currentIndex = 0;

            while (currentIndex < words.Length)
            {
                int chunkSize = Math.Min(n, words.Length - currentIndex);
                var chunk = string.Join(' ', words.Skip(currentIndex).Take(chunkSize));
                result.Add(chunk);
                currentIndex += chunkSize;
            }

            return result;
        }

        public static List<string> SplitTextByLastSentence(string input, int n)
        {
            var sentences = input.Split(new[] { ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<string>();
            int currentIndex = 0;

            while (currentIndex < sentences.Length)
            {
                int chunkSize = Math.Min(n, sentences.Length - currentIndex);
                var chunk = string.Join(' ', sentences.Skip(currentIndex).Take(chunkSize));
                result.Add(chunk);
                currentIndex += chunkSize;
            }

            return result;
        }

        public static List<string> SplitTextByLastParagraph(string input, int n)
        {
            var paragraphs = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<string>();
            int currentIndex = 0;

            while (currentIndex < paragraphs.Length)
            {
                int chunkSize = Math.Min(n, paragraphs.Length - currentIndex);
                var chunk = string.Join(Environment.NewLine, paragraphs.Skip(currentIndex).Take(chunkSize));
                result.Add(chunk);
                currentIndex += chunkSize;
            }

            return result;
        }

        public static List<string> SplitTextByWordCount(string input, int n)
        {

            var words = input.Split(' ');
            var result = new List<string>();
            var currentChunk = new StringBuilder();

            foreach (var word in words)
            {
                if (currentChunk.Length + word.Length + 1 <= n) // +1 for space between words
                {
                    currentChunk.Append(word);
                    currentChunk.Append(' ');
                }
                else
                {
                    result.Add(currentChunk.ToString().Trim());
                    currentChunk.Clear();
                    currentChunk.Append(word);
                    currentChunk.Append(' ');
                }
            }

            if (currentChunk.Length > 0)
            {
                result.Add(currentChunk.ToString().Trim());
            }

            return result;
        }


        public static List<string> SplitTextBySentenceCount(string input, int n)
        {
            List<string> result = new List<string>();

                int current;
                while (input.Length > n)
                {
                    if ((input[n] != '!') || (input[n] != '.') || (input[n] != '?'))
                    {
                        current = n;
                        for (int i = n; ((input[i] != '!') && (input[i] != '.') && (input[i] != '?')); --i)
                        {
                            --current;
                        }
                        result.Add(input.Substring(0, Math.Min(current+1, input.Length)));
                        input = input.Remove(0, current+1);
                    }
                current = 0;
            }
            result.Add(input);
            return result;
        }



        public static List<string> SplitTextByParagraphCount(string input, int n)
        {
            var paragraphs = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var sentences = input.Split(new[] { ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<string>();
            int currentIndex = 0;

            while (currentIndex < sentences.Length)
            {
                int paragraphStartIndex = currentIndex;
                int sentenceCount = 0;

                while (sentenceCount < n && currentIndex < sentences.Length)
                {
                    sentenceCount += sentences[currentIndex].Count(c => ".!?".Contains(c));
                    currentIndex++;
                }

                if (sentenceCount >= n)
                {
                    var paragraphIndices = paragraphs.Select((p, index) => index)
                                                     .Skip(paragraphStartIndex)
                                                     .TakeWhile(index => index < paragraphs.Length)
                                                     .ToArray();

                    var chunk = string.Join(Environment.NewLine, paragraphIndices.Select(index => paragraphs[index]));
                    result.Add(chunk);
                }
                else
                {
                    // Handle the case where it's not possible to split by paragraphs
                    string problematicParagraph = paragraphs.Skip(paragraphStartIndex).FirstOrDefault();
                    string errorMessage = $"Unable to split text by paragraph count. Paragraph with insufficient sentences: {problematicParagraph}";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return result; // or handle the error in another way
                }
            }

            return result;
        }

        public static List<string> SplitTextByCoding(string input, int coding, int n, int sizeValue)
        {
            Encoding encoding = GetEncodingByCode(coding);
            int bitsPerCharacter = GetBitsPerCharacter(encoding);
            int totalBits = input.Length * bitsPerCharacter;

            // Преобразуем размер части в биты
            int partSizeInBits = GetPartSizeInBits(n, sizeValue);

            List<string> result = new List<string>();
            int startIndex = 0;

            while (startIndex < totalBits)
            {
                int endIndex = startIndex + partSizeInBits;

                if (endIndex > totalBits)
                {
                    endIndex = totalBits;
                }

                // Выделяем часть текста в битах
                string part = input.Substring(startIndex / bitsPerCharacter, (endIndex - startIndex) / bitsPerCharacter);

                result.Add(part);
                startIndex = endIndex;
            }

            return result;
        }

        private static Encoding GetEncodingByCode(int coding)
        {
            switch (coding)
            {
                case 0: return Encoding.UTF8;
                case 1: return Encoding.Unicode; // UTF-16
                case 2: return Encoding.GetEncoding("ISO-8859-1");
                case 3: return Encoding.GetEncoding("Windows-1252");
                case 4: return Encoding.ASCII;
                case 5: return Encoding.UTF32;
                case 6: return Encoding.GetEncoding("ISO-8859-15");
                case 7: return Encoding.GetEncoding("KOI8-R");
                case 8: return Encoding.GetEncoding("Shift-JIS");
                case 9: return Encoding.GetEncoding("EUC-JP");
                default: throw new ArgumentException("Unsupported encoding code");
            }
        }

        private static int GetBitsPerCharacter(Encoding encoding)
        {
            return encoding.GetBytes("A").Length * 8;
        }

        private static int GetPartSizeInBits(int n, int sizeValue)
        {
            int bits = 0;

            switch (sizeValue)
            {
                case 10: bits = n; break; // bit
                case 11: bits = n * 8; break; // byte
                case 12: bits = n * 8 * 1024; break; // KB
                case 13: bits = n * 8 * 1024 * 1024; break; // MB
                default: throw new ArgumentException("Unsupported size value code");
            }

            return bits;
        }
        public static List<string> SplitTextByCodingWord(string input, int coding, int n, int sizeValue)
        {
            List<string> words = input.Split(' ').ToList();
            return SplitTextByCodingInternal(words, coding, n, sizeValue);
        }

        public static List<string> SplitTextByCodingSentence(string input, int coding, int n, int sizeValue)
        {
            List<string> sentences = input.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return SplitTextByCodingInternal(sentences, coding, n, sizeValue);
        }

        public static List<string> SplitTextByCodingParagraph(string input, int coding, int n, int sizeValue)
        {
            List<string> paragraphs = input.Split(new[] { Environment.NewLine, "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return SplitTextByCodingInternal(paragraphs, coding, n, sizeValue);
        }

        private static List<string> SplitTextByCodingInternal(List<string> segments, int coding, int n, int sizeValue)
        {
            Encoding encoding = GetEncodingByCode(coding);
            int bitsPerCharacter = GetBitsPerCharacter(encoding);

            // Преобразуем размер части в биты
            int partSizeInBits = GetPartSizeInBits(n, sizeValue);

            List<string> result = new List<string>();
            int startIndex = 0;

            while (startIndex < segments.Count)
            {
                int endIndex = startIndex;

                int accumulatedBits = 0;

                while (endIndex < segments.Count && accumulatedBits <= partSizeInBits)
                {
                    // Вычисляем размер текущего сегмента в битах
                    int segmentBits = segments[endIndex].Length * bitsPerCharacter;

                    // Проверяем, не превышает ли добавление текущего сегмента максимальный размер части
                    if (accumulatedBits + segmentBits <= partSizeInBits)
                    {
                        accumulatedBits += segmentBits;
                        endIndex++;
                    }
                    else
                    {
                        break;
                    }
                }

                // Объединяем выбранные сегменты в одну часть
                string part = string.Join(" ", segments.GetRange(startIndex, endIndex - startIndex));

                result.Add(part);
                startIndex = endIndex;
            }

            return result;
        }

        public static List<string> SplitTextBySeperator(string input, string separator)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(separator))
            {
                // Handle null or empty strings gracefully, my dear.
                throw new ArgumentException("Input and separator cannot be null or empty.");
            }

            List<string> parts = new List<string>();
            int startIndex = 0;

            while (startIndex < input.Length)
            {
                int separatorIndex = input.IndexOf(separator, startIndex, StringComparison.Ordinal);

                if (separatorIndex == -1)
                {
                    // If no more separators are found, add the remaining part and break.
                    parts.Add(input.Substring(startIndex));
                    break;
                }

                // Add the part before the separator to the list.
                parts.Add(input.Substring(startIndex, separatorIndex - startIndex));

                // Move the start index to the character after the separator.
                startIndex = separatorIndex + separator.Length;
            }

            return parts;
        }
    }
}

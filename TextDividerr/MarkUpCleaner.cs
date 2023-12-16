using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;



namespace TextDividerr
{
    public class MarkUpCleaner
    {

        public static string CleanTextBasedOnFlags(string text, bool[] formatFlags)
        {
            // Проверяем длину массива
            if (formatFlags.Length != 9)
            {
                throw new ArgumentException("Invalid number of elements in the formatFlags array.");
            }

            // Создаем пустую строку для результата
            string cleanedText = text;

            // Проверяем каждый флаг и применяем соответствующую функцию очистки
            if (formatFlags[0])
            {
                cleanedText = CleanHtml(cleanedText);
            }

            if (formatFlags[1])
            {
                cleanedText = CleanMarkdown(cleanedText);
            }

            if (formatFlags[2])
            {
                cleanedText = CleanRtf(cleanedText);
            }

            if (formatFlags[3])
            {
                cleanedText = CleanCss(cleanedText);
            }

            if (formatFlags[4])
            {
                cleanedText = CleanLatex(cleanedText);
            }

            if (formatFlags[5])
            {
                cleanedText = CleanBbCode(cleanedText);
            }

            if (formatFlags[6])
            {
                cleanedText = CleanPlainText(cleanedText);
            }

            if (formatFlags[7])
            {
                cleanedText = CleanJson(cleanedText);
            }

            if (formatFlags[8])
            {
                cleanedText = CleanXml(cleanedText);
            }

            return cleanedText;
        }


        static public string CleanHtml(string html)
        {
            // Очищаем HTML-теги с использованием регулярных выражений
            string pattern = "<.*?>";
            string clean = Regex.Replace(html, pattern, String.Empty);

            return clean;
        }

        static string CleanMarkdown(string markdown)
        {
            // Очищаем Markdown-элементы с использованием регулярных выражений
            string pattern = @"([*_]{1,3})";
            string clean = Regex.Replace(markdown, pattern, String.Empty);

            return clean;
        }

        static string CleanRtf(string rtf)
        {
            // Очищаем RTF-элементы с использованием регулярных выражений
            string pattern = @"\\[a-z]+\b";
            string clean = Regex.Replace(rtf, pattern, String.Empty);

            return clean;
        }

        static string CleanLatex(string latex)
        {
            // Очищаем LaTeX-элементы с использованием регулярных выражений
            string pattern = @"\\[a-zA-Z]+\{[^}]*\}";
            string clean = Regex.Replace(latex, pattern, String.Empty);

            return clean;
        }

        static string CleanCss(string css)
        {
            // Очищаем CSS-стили с использованием регулярных выражений
            string pattern = @"{[^}]*}";
            string clean = Regex.Replace(css, pattern, String.Empty);

            return clean;
        }

        static string CleanBbCode(string bbCode)
        {
            // Очищаем BBCode-элементы с использованием регулярных выражений
            string pattern = @"\[\/?[a-zA-Z]+\]";
            string clean = Regex.Replace(bbCode, pattern, String.Empty);

            return clean;
        }

        static string CleanPlainText(string text)
        {
            // Очищаем PlainText от ненужных символов с использованием регулярных выражений
            string pattern = @"[^a-zA-Z0-9\s]";
            string clean = Regex.Replace(text, pattern, String.Empty);

            return clean;
        }

        static string CleanJson(string json)
        {
            // Очищаем JSON с использованием библиотеки Newtonsoft.Json
            JToken token = JToken.Parse(json);
            string clean = token.ToString();

            return clean;
        }

        static string CleanXml(string xml)
        {
            // Очищаем XML с использованием классов System.Xml
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string clean = doc.InnerXml;

            return clean;
        }

      
    }
}

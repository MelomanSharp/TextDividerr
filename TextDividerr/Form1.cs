using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace TextDividerr
{
    public partial class Form1 : Form
    {
        optionsForm options_Form = new optionsForm();

        private SettingsSet settings;

        int currentpart;

        static string ConvertToRoman(int number)
        {
            int[] arabicValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romanNumerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            string romanNumber = "";

            for (int i = 0; i < arabicValues.Length; i++)
            {
                while (number >= arabicValues[i])
                {
                    romanNumber += romanNumerals[i];
                    number -= arabicValues[i];
                }
            }

            return romanNumber;
        }


        void buffer_activation()
        {

        }


        List<string> DividedText = new List<string>();

        static List<string> insertionBetween(string insertion_text, int initial, bool rome, List<string> DividedText)
        {
            int numerator = initial;

            foreach (var item in DividedText)
            {
                string formattedText = insertion_text.Replace("{numerator}", rome ? ConvertToRoman(numerator) : numerator.ToString());
                DividedText[DividedText.IndexOf(item)] = formattedText + item;
                numerator++;
            }

            return DividedText;
        }

        void Divide()
        {
            richTextBox1.Text = MarkUpCleaner.CleanTextBasedOnFlags(richTextBox1.Text, this.settings.GetMarkup());
            if (this.settings.getppaternd())
            {
                switch (this.settings.GetSeparationMethod(4))
                {
                    case 14:
                        switch (this.settings.GetSeparationMethod(0))
                        {
                            case 0:
                                DividedText = DivderMethod.SplitTextByLength(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works
                                break;
                            case 1:
                                DividedText = DivderMethod.SplitTextByLastWord(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works
                                break;
                            case 2:
                                DividedText = DivderMethod.SplitTextByLastSentence(richTextBox1.Text, this.settings.GetSeparationMethod(1)); // works
                                break;
                            case 3:
                                DividedText = DivderMethod.SplitTextByLastParagraph(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works
                                break;
                            case 4:
                                DividedText = DivderMethod.SplitTextByCoding(richTextBox1.Text, this.settings.GetSeparationMethod(2), this.settings.GetSeparationMethod(1), this.settings.GetSeparationMethod(3)); //works
                                break;
                        }
                        break;
                    case 15:
                        switch (this.settings.GetSeparationMethod(0))
                        {
                            case 0:
                                DividedText = DivderMethod.SplitTextByWordCount(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works
                                break;
                            case 1:
                                DividedText = DivderMethod.SplitTextByLastWord(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works
                                break;
                            case 2:
                                DividedText = DivderMethod.SplitTextByLastSentence(richTextBox1.Text, this.settings.GetSeparationMethod(1)); // works
                                break;
                            case 3:
                                DividedText = DivderMethod.SplitTextByLastParagraph(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works
                                break;
                            case 4:
                                DividedText = DivderMethod.SplitTextByCodingWord(richTextBox1.Text, this.settings.GetSeparationMethod(2), this.settings.GetSeparationMethod(1), this.settings.GetSeparationMethod(3)); //works
                                break;
                        }
                        break;
                    case 16:
                        switch (this.settings.GetSeparationMethod(0))
                        {
                            case 0:
                                DividedText = DivderMethod.SplitTextBySentenceCount(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works
                                break;
                            case 1:
                                DividedText = DivderMethod.SplitTextBySentenceCount(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works but need exceptions
                                break;
                            case 2:
                                DividedText = DivderMethod.SplitTextByLastSentence(richTextBox1.Text, this.settings.GetSeparationMethod(1)); // works
                                break;
                            case 3:
                                DividedText = DivderMethod.SplitTextByLastParagraph(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works
                                break;
                            case 4:
                                DividedText = DivderMethod.SplitTextByCodingSentence(richTextBox1.Text, this.settings.GetSeparationMethod(2), this.settings.GetSeparationMethod(1), this.settings.GetSeparationMethod(3)); //works
                                break;

                        }
                        break;
                    case 17:
                        switch (this.settings.GetSeparationMethod(0))
                        {
                            case 0:
                                DividedText = DivderMethod.SplitTextByParagraphCount(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works
                                break;
                            case 1:
                                DividedText = DivderMethod.SplitTextByParagraphCount(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works but need exceptions
                                break;
                            case 2:
                                DividedText = DivderMethod.SplitTextByParagraphCount(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works
                                break;
                            case 3:
                                DividedText = DivderMethod.SplitTextByLastParagraph(richTextBox1.Text, this.settings.GetSeparationMethod(1)); //works
                                break;
                            case 4:
                                DividedText = DivderMethod.SplitTextByCodingParagraph(richTextBox1.Text, this.settings.GetSeparationMethod(2), this.settings.GetSeparationMethod(1), this.settings.GetSeparationMethod(3)); //works
                                break;
                        }
                        break;
                }
            }
            else
            {
                DividedText = DivderMethod.SplitTextBySeperator(richTextBox1.Text, this.settings.GetSeperator());
            }

            if (DividedText.Count > 0)
            {
                if (this.settings.getpartheader())
                {
                    DividedText = insertionBetween(this.settings.GetPartheadertex(), this.settings.GetIniral(), this.settings.GetRome(), DividedText);
                }

                richTextBox2.Text = DividedText[0];
                Next.Visible = true;
                label1.Visible = true;
                label1.Text = "0/" + Convert.ToString(DividedText.Count - 1);

                if (settings.clibboardstatus())
                {
                    int cliboartcurrentpart = 0;
                    Clipboard.SetText(DividedText[cliboartcurrentpart]);
                    Task.Run(() =>
                    {
                        while (cliboartcurrentpart < DividedText.Count)
                        {
                            if (checkinsert())
                            {
                                cliboartcurrentpart++;
                                SetClipboardText(DividedText[cliboartcurrentpart]);
                            }
                            Thread.Sleep(1);
                        }
                    });
                }
            }

        }

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private void SetClipboardText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetClipboardText), text);
                return;
            }

            Clipboard.SetText(text);
        }

        private bool checkinsert()
        {
            // Проверяем, была ли нажата комбинация Ctrl+V
            return (GetAsyncKeyState(Keys.ControlKey) & 0x8000) != 0 &&
                   (GetAsyncKeyState(Keys.V) & 0x8000) != 0;
        }
        public Form1()
        {
            settings = new SettingsSet();

            InitializeComponent();
        }

        // Метод для установки настроек из OptionsForm
        public void SetSettings(SettingsSet newSettings)
        {
            settings = newSettings;
            // Обновить интерфейс с учетом новых настроек
        }

        // Метод для получения текущих настроек
        public SettingsSet GetSettings()
        {
            return settings;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentpart == 1)
            {
                Previous.Visible = false;

            }
            if (currentpart == (DividedText.Count - 1))
            {
                Next.Visible = true;

            }
            --currentpart;
            richTextBox2.Text = DividedText[currentpart];
            label1.Text = Convert.ToString(currentpart) + "/" + Convert.ToString(DividedText.Count - 1);

        }

        public static void KeyPressHandler(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control && e.KeyChar == (char)22)
            {
                Console.WriteLine("Пользователь сделал вставку (Ctrl+V)!");
                // Твой код для обработки вставки здесь
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //settings.setdefaultsettins();
            settings = options_Form.getnewSettings();
            this.Divide();
            SaveOnDrive(this.settings.activating());
        }

        private void SaveOnDrive(bool activated)
        {
            if (activated)
            {
                // Проверим, чтобы у нас были тексты для сохранения
                if (DividedText != null && DividedText.Count > 0)
                {
                    // Убедимся, что у нас есть путь для сохранения
                    if (!string.IsNullOrEmpty(settings.getpath()))
                    {
                        try
                        {
                            // Создаем директорию, если её нет
                            if (!Directory.Exists(settings.getpath()))
                            {
                                Directory.CreateDirectory(settings.getpath());
                            }

                            // Сохраняем каждый элемент в отдельный файл
                            for (int i = 0; i < DividedText.Count; i++)
                            {
                                string filePath = Path.Combine(settings.getpath(), $"Text_{i + 1}.txt");
                                File.WriteAllText(filePath, DividedText[i]);
                            }

                            MessageBox.Show("Texts have been successfully saved, my dear. Path to the files: " + settings.getpath(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while saving texts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("My dear, you forgot to specify the path for saving texts. Please, clarify it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("There is nothing to save, my dear. Texts are absent.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Nrcy_Click(object sender, EventArgs e)
        {
            if (currentpart == 0)
            {
                Previous.Visible = true;

            }
            if (currentpart == (DividedText.Count - 2))
            {
                Next.Visible = false;

            }
            if (currentpart == 1)
            {
                Next.Visible = true;

            }
            currentpart++;
            richTextBox2.Text = DividedText[currentpart];
            label1.Text = Convert.ToString(currentpart) + "/" + Convert.ToString(DividedText.Count - 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (options_Form.IsDisposed || options_Form.Disposing)
            {

            }
            else
            {
                options_Form.Show();
                options_Form.LoadSettingsFromFolder();
            }
            var translationThread = new Thread(() =>
            {
                while (true) // Adjust the condition as needed
                {
                    TranslateThis(options_Form.getcurrlang()); // Replace with your desired language code

                    // Adjust the interval between translations
                    //Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            });

            // Start the translation thread
            translationThread.Start();

        }

        private void Clipboard_Click(object sender, EventArgs e)
        {

        }
        public void TranslateThis(string language)
        {
            Action updateUI = () =>
            {
                switch (language)
                {
                    case "English":
                        button1.Text = "Divide";
                        Previous.Text = "Prvious";
                        Next.Text = "Next";
                        button3.Text = "Options";
                        break;
                    case "(Français) - French":
                        button1.Text = "Diviser";
                        Previous.Text = "Précédent";
                        Next.Text = "Suivant";
                        button3.Text = "Options";
                        break;
                    case "(Deutsch) - German":
                        button1.Text = "Teilen";
                        Previous.Text = "Vorherige";
                        Next.Text = "Nächste";
                        button3.Text = "Optionen";
                        break;
                    case "(Español) - Spanish":
                        button1.Text = "Dividir";
                        Previous.Text = "Anterior";
                        Next.Text = "Siguiente";
                        button3.Text = "Opciones";
                        break;
                    case "(Italiano) - Italian":
                        button1.Text = "Dividi";
                        Previous.Text = "Precedente";
                        Next.Text = "Successivo";
                        button3.Text = "Opzioni";
                        break;
                    case "(Русский) - Russian":
                        button1.Text = "Разделить";
                        Previous.Text = "Предыдущий";
                        Next.Text = "Следующий";
                        button3.Text = "Настройки";
                        break;
                    case "(中文) - Mandarin Chinese":
                        button1.Text = "分";
                        Previous.Text = "上一个";
                        Next.Text = "下一个";
                        button3.Text = "选项";
                        break;
                    case "(日本語) - Japanese":
                        button1.Text = "分割";
                        Previous.Text = "前へ";
                        Next.Text = "次へ";
                        button3.Text = "オプション";
                        break;
                    case "(العربية )- Arabic":
                        button1.Text = "قسم";
                        Previous.Text = "السابق";
                        Next.Text = "التالي";
                        button3.Text = "خيارات";
                        break;
                    case "(हिन्दी) - Hindi":
                        button1.Text = "विभाजित करें";
                        Previous.Text = "पिछला";
                        Next.Text = "अगला";
                        button3.Text = "विकल्प";
                        break;
                    default:
                        break;
                }
            };

            // Check if Invoke is required
            if (InvokeRequired)
            {
                // Invoke the updateUI action on the main thread
                Invoke(updateUI);
            }
            else
            {
                // Execute the action directly if on the main thread
                updateUI();
            }
        }
    }
}
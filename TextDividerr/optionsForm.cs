using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDividerr
{
    public partial class optionsForm : Form
    {
        private Form1 mainForm;

        private string GetProjectFolderPath()
        {
            // Получаем путь к папке с исполняемым файлом (где лежит exe)
            string executableFolderPath = Path.GetDirectoryName(Application.ExecutablePath);

            // Переходим в родительскую папку (дважды, так как хотим оказаться в папке проекта)
            string projectFolderPath = Path.Combine(executableFolderPath, "..", "..");

            // Приводим к полному пути
            projectFolderPath = Path.GetFullPath(projectFolderPath);

            return projectFolderPath;
        }

        public void LoadSettingsFromFolder()
        {
            // Определяем путь к папке с проектом
            string projectFolderPath = GetProjectFolderPath();

            // Получаем все файлы JSON в папке проекта
            string[] jsonFiles = Directory.GetFiles(projectFolderPath, "*.json");

            // Преобразуем полные пути в имена файлов без расширения с использованием LINQ
            string[] fileNames = jsonFiles.Select(Path.GetFileNameWithoutExtension).ToArray();

            // Добавляем их в listBox2
            listBox2.Items.AddRange(fileNames);
        }

        SettingsSet newSettings = new SettingsSet();

        public SettingsSet getnewSettings()
        {
            return newSettings;
        }

        static int GetSeparationBySizeInfoIndex(string option)
        {
            Dictionary<string, int> optionToIndex = new Dictionary<string, int>
    {
        { "UTF-8", 0 },
        { "UTF-16", 1 },
        { "ISO-8859-1", 2 },
        { "Windows-1252", 3 },
        { "ASCII", 4 },
        { "UTF-32", 5 },
        { "ISO-8859-15", 6 },
        { "KOI8-R", 7 },
        { "Shift-JIS", 8 },
        { "EUC-JP", 9 },
        { "bit", 10 },
        { "byte", 11 },
        { "KB", 12 },
        { "MB", 13 },
        { "Symbol", 14 },
        { "Word", 15 },
        { "Sentence", 16 },
        { "Paragraph", 17 }
    };

            if (optionToIndex.ContainsKey(option))
            {
                return optionToIndex[option];
            }

            // Если входной вариант не найден в словаре, можно вернуть, например, -1
            return -1;
        }

        public optionsForm(Form1 form)
        {
            mainForm = form;
        }

        private void SaveSettings()
        {
            mainForm.SetSettings(newSettings);
        }
        public optionsForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newSettings.SetSeparationMethod(0, 0);
            newSettings.SetSeparationMethod(1, Convert.ToInt32(textBox1.Text));
            newSettings.SetSeparationMethod(2, 0);
            newSettings.SetSeparationMethod(3, 0);
            newSettings.SetSeparationMethod(4, GetSeparationBySizeInfoIndex((string)comboBox3.SelectedItem));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newSettings.SetSeparationMethod(0, 1);
            newSettings.SetSeparationMethod(1, Convert.ToInt32(textBox2.Text));
            newSettings.SetSeparationMethod(2, 18);
            newSettings.SetSeparationMethod(3, 18);
            newSettings.SetSeparationMethod(4, GetSeparationBySizeInfoIndex((string)comboBox3.SelectedItem));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            newSettings.SetSeparationMethod(0, 2);
            newSettings.SetSeparationMethod(1, Convert.ToInt32(textBox3.Text));
            newSettings.SetSeparationMethod(2, 18);
            newSettings.SetSeparationMethod(3, 18);
            newSettings.SetSeparationMethod(4, GetSeparationBySizeInfoIndex((string)comboBox3.SelectedItem));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            newSettings.SetSeparationMethod(0, 3);
            newSettings.SetSeparationMethod(1, Convert.ToInt32(textBox4.Text));
            newSettings.SetSeparationMethod(2, 18);
            newSettings.SetSeparationMethod(3, 18);
            newSettings.SetSeparationMethod(4, GetSeparationBySizeInfoIndex((string)comboBox3.SelectedItem));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            newSettings.SetSeparationMethod(0, 4);
            newSettings.SetSeparationMethod(1, Convert.ToInt32(textBox5.Text));
            newSettings.SetSeparationMethod(2, GetSeparationBySizeInfoIndex((string)comboBox1.SelectedItem));
            newSettings.SetSeparationMethod(3, GetSeparationBySizeInfoIndex((string)comboBox2.SelectedItem));
            newSettings.SetSeparationMethod(4, GetSeparationBySizeInfoIndex((string)comboBox3.SelectedItem));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            newSettings.SetSeperator(richTextBox2.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Enable")
            {
                newSettings.SetClipboard(true);
                button6.Text = "Disable";
            }
            else
            {
                newSettings.SetClipboard(false);
                button6.Text = "Enable";
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Enable")
            {
                newSettings.SetPartHeader(false);
                button7.Text = "Disable";
                label6.Visible = true;
                richTextBox1.Visible = true;
                label1.Visible = true;
                textBox6.Visible = true;
                checkBox2.Visible = true;
                button8.Visible = true;
            }
            else
            {
                newSettings.SetPartHeader(true);
                button7.Text = "Enable";
                label6.Visible = false;
                richTextBox1.Visible = false;
                label1.Visible = false;
                textBox6.Visible = false;
                checkBox2.Visible = false;
                button8.Visible = false;
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            newSettings.SetStopwords(richTextBox3.Text);

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                newSettings.SetMarkup(i, checkedListBox1.GetItemChecked(i));
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Получаем выбранный язык из langbox1
            string selectedLanguage = listBox1.SelectedItem.ToString();
            TranslateInter(selectedLanguage);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    // Путь сохранения сохраняется в переменную textsaveparth объекта newSettings
                    newSettings.SetTextSavePath(folderDialog.SelectedPath);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Сериализация в JSON
            string jsonSettings = newSettings.ToJson();

            // Определяем путь к папке с проектом
            string projectFolderPath = GetProjectFolderPath();

            // Сохранение JSON в файл в папке проекта
            string fileName = textBox7.Text + ".json";
            string filePath = Path.Combine(projectFolderPath, fileName);
            File.WriteAllText(filePath, jsonSettings);

            // Добавление относительного пути в listBox2
            listBox2.Items.Add(textBox7.Text);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                newSettings.SetRome(true);
            else
                newSettings.SetRome(false);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sizeorseparator();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sizeorseparator();
        }

        private void sizeorseparator()
        {
            if (radioButton1.Checked) newSettings.setsepearationpattern(true); else newSettings.setsepearationpattern(false);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли какой-то элемент в listBox2
            if (listBox2.SelectedItem != null)
            {// Получаем имя файла без расширения из listBox2
                string selectedFileName = listBox2.SelectedItem.ToString();

                // Определяем полный путь к выбранному файлу
                string selectedFilePath = Path.Combine(GetProjectFolderPath(), selectedFileName + ".json");

                // Чтение JSON из файла
                string jsonFromFile = File.ReadAllText(selectedFilePath);


                // Десериализация в объект SettingsSet
                newSettings = SettingsSet.FromJson(jsonFromFile);

                // Теперь можешь использовать loadedSettings, как тебе угодно
            }
            else
            {
                // Если ничего не выбрано, можешь предпринять соответствующие действия
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Отменить закрытие формы
            this.WindowState = FormWindowState.Minimized; // Свернуть форму
                                                          // Добавьте здесь свой код обработки закрытия формы, если нужно
        }

        private void optionsForm_Load(object sender, EventArgs e)
        {

        }

        public void TranslateInter(string current_language)
        {
            switch (current_language)
            {
                case "English":
                    radioButton1.Text = "By size";
                    radioButton2.Text = "By separator";
                    label14.Text = "A minimal syntactic unit:";
                    button4.Text = "Set";
                    button3.Text = "Set";
                    button2.Text = "Set";
                    button1.Text = "Set";
                    label7.Text = "Units of Measurement:";
                    label6.Text = "Coding:";
                    label5.Text = "Number of words:";
                    label4.Text = "Occupancy size:";
                    label3.Text = "Number of paragraphs:";
                    label2.Text = "Number of sentences:";
                    label1.Text = "Number of characters:";
                    button9.Text = "Set";
                    Clipboard.Text = "Clipboard";
                    button6.Text = "Enable";
                    label8.Text = "Enable auto-copying of parts of text to the clipboard?";
                    PartNames.Text = "Name of parts";
                    checkBox2.Text = "Convert to Roman numerals";
                    button8.Text = "Set";
                    label10.Text = "Text to be inserted:";
                    label9.Text = "Enable the option to add text (headings/numbers) between parts of text)?";
                    Formatting.Text = "Formatting";
                    button11.Text = "Set";
                    label13.Text = "Clears text from specified phrase characters:";
                    Preservation.Text = "Saving";
                    button14.Text = "Choose";
                    label15.Text = "Settings sets:";
                    button13.Text = "Save options set";
                    checkBox1.Text = "Automatically save text to separate files";
                    button12.Text = "Select a save folder";
                    button10.Text = "Set";
                    Separation.Text = "Separation";
                    button5.Text = "Set";
                    label9.Text = "Enable the option to add text (headings/numbers) between parts of text)?";
                    label11.Text = "Initial value of the numerator (optional):";
                    label12.Text = "Clear text formatting (select if you want to apply)";
                    break;
                case "(Français) - French":
                    radioButton1.Text = "Par taille";
                    radioButton2.Text = "Par séparateur";
                    label14.Text = "Une unité syntaxique minimale :";
                    button4.Text = "Fixer";
                    button3.Text = "Fixer";
                    button2.Text = "Fixer";
                    button1.Text = "Fixer";
                    label7.Text = "Unités de mesure:";
                    label6.Text = "Codage :";
                    label5.Text = "Nombre de mots :";
                    label4.Text = "Taille d'occupation :";
                    label3.Text = "Nombre de paragraphes :";
                    label2.Text = "Nombre de phrases :";
                    label1.Text = "Nombre de caractères :";
                    button9.Text = "Fixer";
                    Clipboard.Text = "Presse-papiers";
                    button6.Text = "Activer";
                    label8.Text = "Activer la copie automatique des parties de texte dans le presse-papiers ?";
                    PartNames.Text = "Nom des parties";
                    checkBox2.Text = "Convertir en chiffres romains";
                    button8.Text = "Fixer";
                    label10.Text = "Texte à insérer :";
                    label9.Text = "Activer l'option d'ajout de texte (titres/chiffres) entre les parties du texte ?";
                    Formatting.Text = "Mise en forme";
                    button11.Text = "Fixer";
                    label13.Text = "Efface le texte des caractères de la phrase spécifiée :";
                    Preservation.Text = "Sauvegarde";
                    button14.Text = "Choisir";
                    label15.Text = "Ensembles de paramètres :";
                    button13.Text = "Enregistrer l'ensemble d'options";
                    checkBox1.Text = "Enregistrer automatiquement le texte dans des fichiers séparés";
                    button12.Text = "Sélectionner un dossier de sauvegarde";
                    button10.Text = "Fixer";
                    Separation.Text = "Séparation";
                    button5.Text = "Fixer";
                    label11.Text = "Valeur initiale du numérateur (facultatif):";
                    label12.Text = "Formatage du texte en clair (sélectionnez si vous souhaitez l'appliquer)";
                    break;
                case "(Deutsch) - German":
                    radioButton1.Text = "Nach Größe";
                    radioButton2.Text = "Nach Trennzeichen";
                    label14.Text = "Minimale syntaktische Einheit:";
                    button4.Text = "Festlegen";
                    button3.Text = "Festlegen";
                    button2.Text = "Festlegen";
                    button1.Text = "Festlegen";
                    label7.Text = "Maßeinheiten:";
                    label6.Text = "Codierung:";
                    label5.Text = "Anzahl der Wörter:";
                    label4.Text = "Besetzungsgröße:";
                    label3.Text = "Anzahl der Absätze:";
                    label2.Text = "Anzahl der Sätze:";
                    label1.Text = "Anzahl der Zeichen:";
                    button9.Text = "Festlegen";
                    Clipboard.Text = "Zwischenablage";
                    button6.Text = "Aktivieren";
                    label8.Text = "Automatisches Kopieren von Textteilen in die Zwischenablage aktivieren?";
                    PartNames.Text = "Name der Teile";
                    checkBox2.Text = "In römische Zahlen umwandeln";
                    button8.Text = "Festlegen";
                    label10.Text = "Einzufügender Text:";
                    label9.Text = "Option zum Hinzufügen von Text (Überschriften/Nummern) zwischen Textteilen aktivieren?";
                    Formatting.Text = "Formatierung";
                    button11.Text = "Festlegen";
                    label13.Text = "Löscht Text aus bestimmten Satzzeichen:";
                    Preservation.Text = "Speicherung";
                    button14.Text = "Auswählen";
                    label15.Text = "Einstellungssätze:";
                    button13.Text = "Optionensatz speichern";
                    checkBox1.Text = "Text automatisch in separate Dateien speichern";
                    button12.Text = "Speicherordner auswählen";
                    button10.Text = "Festlegen";
                    Separation.Text = "Trennung";
                    button5.Text = "Festlegen";
                    label9.Text = "Aktivieren Sie die Option zum Hinzufügen von Text (Überschriften/Zahlen) zwischen Textteilen)?";
                    label11.Text = "Anfangswert des Zählers (fakultativ):";
                    label12.Text = "Textformatierung löschen (wählen Sie aus, ob Sie sie anwenden möchten)";
                    break;
                case "(Español) - Spanish":
                    radioButton1.Text = "Por tamaño";
                    radioButton2.Text = "Por separador";
                    label14.Text = "La unidad sintáctica mínima:";
                    button4.Text = "Establecer";
                    button3.Text = "Establecer";
                    button2.Text = "Establecer";
                    button1.Text = "Establecer";
                    label7.Text = "Unidades de medida:";
                    label6.Text = "Codificación:";
                    label5.Text = "Número de palabras:";
                    label4.Text = "Tamaño de ocupación:";
                    label3.Text = "Número de párrafos:";
                    label2.Text = "Número de frases:";
                    label1.Text = "Número de caracteres:";
                    button9.Text = "Establecer";
                    Clipboard.Text = "Portapapeles";
                    button6.Text = "Habilitar";
                    label8.Text = "¿Activar la copia automática de partes de texto en el portapapeles?";
                    PartNames.Text = "Nombre de las partes";
                    checkBox2.Text = "Convertir a números romanos";
                    button8.Text = "Establecer";
                    label10.Text = "Texto a insertar:";
                    label9.Text = "¿Habilitar la opción de agregar texto (encabezados/números) entre partes del texto?";
                    Formatting.Text = "Formato";
                    button11.Text = "Establecer";
                    label13.Text = "Borra el texto de los caracteres de la frase especificada:";
                    Preservation.Text = "Guardado";
                    button14.Text = "Elegir";
                    label15.Text = "Configuración de conjuntos:";
                    button13.Text = "Guardar configuración de opciones";
                    checkBox1.Text = "Guardar automáticamente el texto en archivos separados";
                    button12.Text = "Seleccionar carpeta de guardado";
                    button10.Text = "Establecer";
                    Separation.Text = "Separación";
                    button5.Text = "Establecer";
                    label9.Text = "¿Activar la opción de añadir texto (títulos/números) entre partes de texto)?";
                    label11.Text = "Valor inicial del numerador (opcional):";
                    label12.Text = "Borrar formato de texto (seleccione si desea aplicarlo)";
                    break;
                case "(Italiano) - Italian":
                    radioButton1.Text = "Per dimensione";
                    radioButton2.Text = "Per separatore";
                    label14.Text = "Un'unità sintattica minima:";
                    button4.Text = "Imposta";
                    button3.Text = "Imposta";
                    button2.Text = "Imposta";
                    button1.Text = "Imposta";
                    label7.Text = "Unità di misura:";
                    label6.Text = "Codifica:";
                    label5.Text = "Numero di parole:";
                    label4.Text = "Dimensione occupata:";
                    label3.Text = "Numero di paragrafi:";
                    label2.Text = "Numero di frasi:";
                    label1.Text = "Numero di caratteri:";
                    button9.Text = "Imposta";
                    Clipboard.Text = "Appunti";
                    button6.Text = "Abilita";
                    label8.Text = "Abilitare la copia automatica di parti di testo negli appunti?";
                    PartNames.Text = "Nome delle parti";
                    checkBox2.Text = "Converti in numeri romani";
                    button8.Text = "Imposta";
                    label10.Text = "Testo da inserire:";
                    label9.Text = "Abilitare l'opzione per aggiungere testo (titoli/numeri) tra le parti del testo?";
                    Formatting.Text = "Formattazione";
                    button11.Text = "Imposta";
                    label13.Text = "Cancella il testo dai caratteri di frase specificati:";
                    Preservation.Text = "Salvataggio";
                    button14.Text = "Scegli";
                    label15.Text = "Insiemi di impostazioni:";
                    button13.Text = "Salva l'insieme di opzioni";
                    checkBox1.Text = "Salva automaticamente il testo in file separati";
                    button12.Text = "Seleziona una cartella di salvataggio";
                    button10.Text = "Imposta";
                    Separation.Text = "Separazione";
                    button5.Text = "Imposta";
                    label9.Text = "Abilita l'opzione per aggiungere testo (intestazioni/numeri) tra le parti del testo?";
                    label11.Text = "Valore iniziale del numeratore (opzionale):";
                    label12.Text = "Cancella la formattazione del testo (seleziona se vuoi applicarla)";
                    break;
                case "(Русский) - Russian":
                    radioButton1.Text = "По размеру";
                    radioButton2.Text = "По разделителю";
                    label14.Text = "Минимальная синтаксическая единица:";
                    button4.Text = "Установить";
                    button3.Text = "Установить";
                    button2.Text = "Установить";
                    button1.Text = "Установить";
                    label7.Text = "Единицы измерения:";
                    label6.Text = "Кодировка:";
                    label5.Text = "Количество слов:";
                    label4.Text = "Размер занимаемого места:";
                    label3.Text = "Количество абзацев:";
                    label2.Text = "Количество предложений:";
                    label1.Text = "Количество символов:";
                    button9.Text = "Установить";
                    Clipboard.Text = "Буфер обмена";
                    button6.Text = "Включить";
                    label8.Text = "Включить автоматическое копирование частей текста в буфер обмена?";
                    PartNames.Text = "Имя частей";
                    checkBox2.Text = "Преобразовать в римские цифры";
                    button8.Text = "Установить";
                    label10.Text = "Вставляемый текст:";
                    label9.Text = "Включить опцию добавления текста (заголовков/номеров) между частями текста?";
                    Formatting.Text = "Форматирование";
                    button11.Text = "Установить";
                    label13.Text = "Очищает текст от указанных символов фразы:";
                    Preservation.Text = "Сохранение";
                    button14.Text = "Выбрать";
                    label15.Text = "Настройки наборов:";
                    button13.Text = "Сохранить набор опций";
                    checkBox1.Text = "Автоматически сохранять текст в отдельные файлы";
                    button12.Text = "Выбрать папку для сохранения";
                    button10.Text = "Установить";
                    Separation.Text = "Разделение";
                    button5.Text = "Установить";
                    label9.Text = "Включить опцию добавления текста (заголовков/номеров) между частями текста?";
                    label11.Text = "Начальное значение числителя (по желанию):";
                    label12.Text = "Очистить форматирование текста (выберите, если хотите применить)";

                    break;
                case "(中文) - Mandarin Chinese":
                    radioButton1.Text = "按大小";
                    radioButton2.Text = "按分隔符";
                    label14.Text = "最小句法单位：";
                    button4.Text = "设置";
                    button3.Text = "设置";
                    button2.Text = "设置";
                    button1.Text = "设置";
                    label7.Text = "计量单位:";
                    label6.Text = "编码:";
                    label5.Text = "字数:";
                    label4.Text = "占用面积:";
                    label3.Text = "段落数:";
                    label2.Text = "句子数:";
                    label1.Text = "字符数：";
                    button9.Text = "设置";
                    Clipboard.Text = "剪贴板";
                    button6.Text = "启用";
                    label8.Text = "启用自动复制文本部分到剪贴板？";
                    PartNames.Text = "部件名称";
                    checkBox2.Text = "转换为罗马数字";
                    button8.Text = "设置";
                    label10.Text = "要插入的文本：";
                    label9.Text = "启用在文本各部分之间添加文本（标题/数字）的选项？";
                    Formatting.Text = "格式";
                    button11.Text = "设置";
                    label13.Text = "清除文本中的指定短语字符：";
                    Preservation.Text = "保存";
                    button14.Text = "选择";
                    label15.Text = "设置集：";
                    button13.Text = "保存选项集";
                    checkBox1.Text = "自动将文本保存到单独文件";
                    button12.Text = "选择保存文件夹";
                    button10.Text = "设置";
                    Separation.Text = "分隔";
                    button5.Text = "设置";
                    label9.Text = "启用在文本部分之间添加文本（标题/数字）的选项？";
                    label11.Text = "分子的初始值（可选）：";
                    label12.Text = "清除文本格式（选择是否要应用）";
                    break;
                case "(日本語) - Japanese":
                    radioButton1.Text = "サイズ別";
                    radioButton2.Text = "セパレーター別";
                    label14.Text = "最小の構文単位:";
                    button4.Text = "セット";
                    button3.Text = "セット";
                    button2.Text = "セット";
                    button1.Text = "セット";
                    label7.Text = "測定単位:";
                    label6.Text = "コーディング:";
                    label5.Text = "単語数:";
                    label4.Text = "占有サイズ:";
                    label3.Text = "段落数:";
                    label2.Text = "文の数:";
                    label1.Text = "文字数:";
                    button9.Text = "設定";
                    Clipboard.Text = "クリップボード";
                    button6.Text = "有効にする";
                    label8.Text = "テキストの一部をクリップボードに自動コピーしますか？";
                    PartNames.Text = "パーツの名前";
                    checkBox2.Text = "ローマ数字に変換";
                    button8.Text = "設定";
                    label10.Text = "挿入するテキスト:";
                    label9.Text = "テキストの部分の間にテキスト（見出し/数字）を追加するオプションを有効にしますか？";
                    Formatting.Text = "書式設定";
                    button11.Text = "設定";
                    label13.Text = "指定したフレーズ文字からテキストを消去します:";
                    Preservation.Text = "保存";
                    button14.Text = "選択";
                    label15.Text = "設定セット:";
                    button13.Text = "オプションセットを保存";
                    checkBox1.Text = "テキストを自動的に別々のファイルに保存する";
                    button12.Text = "保存フォルダを選択";
                    button10.Text = "設定";
                    Separation.Text = "分離";
                    button5.Text = "セット";
                    label9.Text = "テキストの部分の間にテキスト（見出し/数字）を追加するオプションを有効にしますか？";
                    label11.Text = "分子の初期値（オプション）：";
                    label12.Text = "テキストの書式をクリアする（適用する場合は選択）";
                    break;
                case "(العربية )- Arabic":
                    radioButton1.Text = "حسب الحجم";
                    radioButton2.Text = "حسب الفاصل";
                    label14.Text = "وحدة صرفية صغيرة:";
                    button4.Text = "تعيين";
                    button3.Text = "تعيين";
                    button2.Text = "تعيين";
                    button1.Text = "تعيين";
                    label7.Text = "وحدات القياس:";
                    label6.Text = "الترميز:";
                    label5.Text = "عدد الكلمات:";
                    label4.Text = "حجم الاحتلال:";
                    label3.Text = "عدد الفقرات:";
                    label2.Text = "عدد الجمل:";
                    label1.Text = "عدد الأحرف:";
                    button9.Text = "تعيين";
                    Clipboard.Text = "الحافظة";
                    button6.Text = "تمكين";
                    label8.Text = "تمكين النسخ التلقائي لأجزاء النص إلى الحافظة؟";
                    PartNames.Text = "اسم الأجزاء";
                    checkBox2.Text = "تحويل إلى الأرقام الرومانية";
                    button8.Text = "تعيين";
                    label10.Text = "النص الذي سيتم إدراجه:";
                    label9.Text = "تمكين خيار إضافة نص (عناوين/أرقام) بين أجزاء النص؟";
                    Formatting.Text = "التنسيق";
                    button11.Text = "تعيين";
                    label13.Text = "يمحو النص من الأحرف المحددة في العبارة:";
                    Preservation.Text = "الحفظ";
                    button14.Text = "اختيار";
                    label15.Text = "مجموعات الإعدادات:";
                    button13.Text = "حفظ مجموعة الخيارات";
                    checkBox1.Text = "حفظ النص تلقائيًا في ملفات منفصلة";
                    button12.Text = "تحديد مجلد الحفظ";
                    button10.Text = "تعيين";
                    Separation.Text = "الفصل";
                    button5.Text = "تعيين";
                    label9.Text = "تمكين الخيار لإضافة نص (عناوين/أرقام) بين أجزاء النص؟";
                    label11.Text = "القيمة الابتدائية للبسط (اختياري):";
                    label12.Text = "مسح تنسيق النص (حدد إذا كنت ترغب في تطبيقه)";
                    break;
                case "(हिन्दी) - Hindi":
                    radioButton1.Text = "आकार के अनुसार";
                    radioButton2.Text = "विभाजक के अनुसार";
                    label14.Text = "एक न्यूनतम वाक्यात्मक इकाई:";
                    button4.Text = "सेट करें";
                    button3.Text = "सेट करें";
                    button2.Text = "सेट करें";
                    button1.Text = "सेट करें";
                    label7.Text = "मापन इकाइयाँ:";
                    label6.Text = "कोडिंग:";
                    label5.Text = "शब्दों की संख्या:";
                    label4.Text = "कब्जा का आकार:";
                    label3.Text = "पैराग्राफ की संख्या:";
                    label2.Text = "वाक्यों की संख्या:";
                    label1.Text = "अक्षरों की संख्या:";
                    button9.Text = "सेट करें";
                    Clipboard.Text = "क्लिपबोर्ड";
                    button6.Text = "सक्षम करें";
                    label8.Text = "टेक्स्ट के भागों को स्वचालित रूप से क्लिपबोर्ड पर कॉपी करने को सक्षम करें?";
                    PartNames.Text = "भाग का नाम";
                    checkBox2.Text = "रोमन संख्या में बदलें";
                    button8.Text = "सेट करें";
                    label10.Text = "डालने वाला टेक्स्ट:";
                    label9.Text = "टेक्स्ट के भागों के बीच टेक्स्ट (शीर्षक / संख्या) जोड़ने के विकल्प को सक्षम करें?";
                    Formatting.Text = "स्वरूपण";
                    button11.Text = "सेट करें";
                    label13.Text = "निर्दिष्ट वाक्य अक्षरों से पाठ को साफ़ करता है:";
                    Preservation.Text = "सुरक्षण";
                    button14.Text = "चयन करें";
                    label15.Text = "सेटिंग सेट:";
                    button13.Text = "विकल्प सेट सहेजें";
                    checkBox1.Text = "टेक्स्ट को स्वतंत्र फ़ाइलों में स्वचालित रूप से सहेजें";
                    button12.Text = "एक सहेजें फ़ोल्डर का चयन करें";
                    button10.Text = "सेट करें";
                    Separation.Text = "विभाजन";
                    button5.Text = "تعيين";
                    label9.Text = "تمكين الخيار لإضافة نص (عناوين/أرقام) بين أجزاء النص؟";
                    label11.Text = "القيمة الابتدائية للبسط (اختياري):";
                    label12.Text = "مسح تنسيق النص (حدد إذا كنت ترغب في تطبيقه)";
                    break;
                default:
                    break;
            }
            curr_lang = current_language;
        }

        string curr_lang;

        public string getcurrlang()
        {
            return curr_lang;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                newSettings.SetSettingAutoSave(true);
            }
            else
            {
                newSettings.SetSettingAutoSave(false);
            }
            
        }
    }
}

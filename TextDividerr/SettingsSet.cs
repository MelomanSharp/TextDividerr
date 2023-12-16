using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TextDividerr
{
    public class SettingsSet
    {

        int[] separationmethod = new int[5]; //the first bit encodes the method number, the second bit encodes the value in the textbox, the remaining bits encode the options of the last method (if selected).

        string seperator
        {
            get;
            set;
        }

        bool separationpattern
        {
            get;
            set;
        }

        bool clipboard
        {
            get;
            set;
        }

        bool partheader
        {
            get;
            set;
        }
        string partheadertext
        {
            get;
            set;
        }
        int initalvalue
        {
            get;
            set;
        }
        bool rome
        {
            get;
            set;
        }

        bool[] markup = new bool[9];

        string stopwords
        {
            get;
            set;
        }

        bool textautosave
        {
            get;
            set;
        }
        bool settingautosave
        {
            get;
            set;
        }
        string textsaveparth
        {
            get;
            set;
        }

        public string getpath()
        { return textsaveparth; }


        public void SetSeperator(string value)
        {
            seperator = value;
        }

        public string GetSeperator()
        {
            return seperator;
        }
        public void SetClipboard(bool value)
        {
            clipboard = value;
        }

        public void SetPartHeader(bool value)
        {
            partheader = value;
        }

        public void SetPartHeaderText(string value)
        {
            partheadertext = value;
        }

        public void SetInitialValue(int value)
        {
            initalvalue = value;
        }

        public void SetRome(bool value)
        {
            rome = value;
        }

        public int GetSeparationMethod(int index)
        {
            return separationmethod[index];
        }

        public void SetSeparationMethod(int index, int value)
        {
            separationmethod[index] = value;
        }

        public bool GetMarkup(int index)
        {
            return markup[index];
        }

        public void SetMarkup(int index, bool value)
        {
            markup[index] = value;
        }

        public void SetStopwords(string value)
        {
            stopwords = value;
        }

        public void SetTextAutoSave(bool value)
        {
            textautosave = value;
        }

        public void SetSettingAutoSave(bool value)
        {
            settingautosave = value;
        }

        public void SetTextSavePath(string value)
        {
            textsaveparth = value;
        }

        public void setsepearationpattern(bool input)
            {
            this.separationpattern = input;
            }
        public bool getppaternd()
        {
            return separationpattern;
        }

        public bool clibboardstatus()
        {
            return clipboard;
        }
        
        public bool getpartheader()
        {
            return partheader;
        }
        public string GetPartheadertex()
        {
            return partheadertext;
        }

        public int GetIniral()
        { return initalvalue; }

        public bool GetRome()
        {
            return rome;
        }

        public bool[] GetMarkup()
        {
            return markup;
        }

        public bool activating()
        {
            return textautosave;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public static SettingsSet FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SettingsSet>(json);
        }
    }
}
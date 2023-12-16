using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDividerr
{
    public class MessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            const int WM_KEYDOWN = 0x0100;
            if (m.Msg == WM_KEYDOWN)
            {
                KeyPressEventArgs e = new KeyPressEventArgs((char)m.WParam);
                Form1.KeyPressHandler(this, e);
            }
            return false;
        }
    }
}

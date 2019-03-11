using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboarder
{
    /*
     * 
     * Contains Console functions
     * 
     */
    public partial class MainGUI
    {
        public void ConsoleWriteLine(string text)
        {
            c_Console.Text += text + "\n";
        }

        public void ClearConsole()
        {
            c_Console.Clear();
        }
    }
}

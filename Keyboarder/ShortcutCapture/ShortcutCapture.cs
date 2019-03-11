using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboarder
{
    partial class ShortcutCapture
    {
        public static void testfunc(object args)
        {
            CallbackParameter Argument = (CallbackParameter)args;
            MainGUI f = (MainGUI)Argument.args[0];

            try
            {
                var d = "Console write text";
                f.Invoke(f.Con_Write, d);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }
        }

        public static void test2func(object args)
        {
            CallbackParameter Argument = (CallbackParameter)args;
            MainGUI f = (MainGUI)Argument.args[0];

        }
    }
}

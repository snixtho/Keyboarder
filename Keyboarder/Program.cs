using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace Keyboarder
{
    static class Program
    {
        static ShortcutCapture ShortCuts(Form f)
        {
            /************************/
            MainGUI form = (MainGUI)f; // Replace "MainGUI" with the name of your startup form
            /************************/
            
            ShortcutCapture SC = new ShortcutCapture();
            SC.AddShortCut(new Keys[] { Keys.LControlKey, Keys.F10 }, ShortcutCapture.testfunc, new object[] { form });
            SC.AddShortCut(new Keys[] { Keys.LControlKey, Keys.F11 }, ShortcutCapture.test2func, new object[] { form });
            SC.Capture();

            return SC;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainGUI f = new MainGUI();

            // Initialize Global Shortcut Hooks
            //ShortcutCapture SC = ShortCuts(f);

            Application.Run();
            //SC.StopCapturing();
        }
    }
}

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
     * Contains Invoke() functions 
     * 
     */
    public partial class MainGUI
    {
        public InvokeParamsDel Con_Write;
        public object _Con_Write(params object[] Params)
        {
            ConsoleWriteLine((string)Params[0]);
            return null;
        }

        public InvokeDel Con_Clear;
        public object _Con_Clear()
        {
            ClearConsole();
            return null;
        }

        /**********************/

        public void SetInvokes()
        {
            Con_Write = _Con_Write;
            Con_Clear = _Con_Clear;
        }
    }
}

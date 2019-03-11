using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyboarder
{
    public delegate object InvokeParamsDel(params object[] Params);  // For functions with parameters
    public delegate object InvokeDel();                     // For functions without any parameters
    
    class Helper
    {
        public static object[] Params(params object[] args)
        {
            return args;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Keyboarder
{
    public delegate void FuncDel(object args);

    struct ShortcutInfo
    {
        public Keys[] Shortcut;
        public FuncDel Callback;
        public object[] Arguments;
    }

    struct CallbackParameter
    {
        public object[] args;
    }

    struct AsyncCaptureInfo
    {
        public delegate void CapturingFunc(bool capturing);
        public CapturingFunc SetCapturing;

        public delegate bool GetCapturingFunc();
        public GetCapturingFunc GetCapturing;

        public List<ShortcutInfo> Shortcuts;
    }

    partial class ShortcutCapture
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        private List<ShortcutInfo> shortcuts;
        bool IsCapturing;

        private void SetCapturing(bool capturing)
        {
            IsCapturing = capturing;
        }


        private bool GetCapturing()
        {
            return IsCapturing;
        }

        private void AsyncCapture(object input)
        {
            AsyncCaptureInfo info = (AsyncCaptureInfo)input;
            /**********************************************/

            List<Keys> pKeys = new List<Keys>(); // Latest Shortcut Combination
            List<Keys> values = Enum.GetValues(typeof(Keys)).OfType<Keys>().ToList(); // Detectable keys

            Keys[] lastCombDetected = null;

            // prepare keys array
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] == Keys.ControlKey)
                {
                    values.RemoveAt(i);
                }
                if (values[i] == Keys.Menu)
                {
                    values.RemoveAt(i);
                }
            }

            // check for shortcuts
            while (info.GetCapturing())
            {
                foreach (Keys key in values)
                {
                    unchecked
                    {
                        // Get status of key
                        bool kStatus = GetAsyncKeyState((int)key) == (short)0x8000;

                        if (pKeys.Count > 0)
                        {
                            int keyPos = -1;
                            for (int i = 0; i < pKeys.Count; i++) // find pos of current key
                            {
                                if (key == pKeys[i])
                                {
                                    keyPos = i;
                                    break;
                                }
                            }

                            if (keyPos == -1 && kStatus)
                            {// Key is now up, add it
                                pKeys.Add(key);
                            }
                            else if (keyPos != -1 && !kStatus)
                            {// Key is now down, remove it
                                lastCombDetected = null;
                                pKeys.RemoveAt(keyPos);
                            }
                        }
                        else
                        {
                            if (kStatus)
                                pKeys.Add(key);
                        }
                    }
                }

                //Debug.WriteLine("Comb: " + String.Join("+", pKeys));

                // check if combination matches any added shortcuts
                string lastComb = String.Join(".", pKeys);
                if (lastCombDetected == null || String.Join(".", lastCombDetected.ToList()) != lastComb)
                {
                    foreach (ShortcutInfo shortcut in info.Shortcuts)
                    {
                        string comb = String.Join(".", shortcut.Shortcut);
                        if (comb == lastComb)
                        {
                            lastCombDetected = shortcut.Shortcut;
                            Thread t = new Thread(new ParameterizedThreadStart(shortcut.Callback));

                            CallbackParameter cp = new CallbackParameter();
                            cp.args = shortcut.Arguments;

                            t.Start(cp);

                            break;
                        }
                    }
                }

                //Debug.WriteLine("0x" + GetAsyncKeyState((int)Keys.F10).ToString("X"));
            }

            /***********************/
            //info.SetCapturing(false);
        }

        public ShortcutCapture()
        {
            shortcuts = new List<ShortcutInfo>();
            IsCapturing = false;
        }

        public void AddShortCut(Keys[] keys, FuncDel func, object[] args)
        {
            if (IsCapturing)
            {
                MessageBox.Show("You cannot add another shortcut while the script is capturing shortcuts!");
            }
            else
            {
                if (keys.Length > 0)
                {
                    bool nFound = false;

                    if (shortcuts.Count > 0)
                    {
                        foreach (ShortcutInfo shortcut in shortcuts)
                        {
                            if (shortcut.Shortcut.Length == keys.Length)
                            {
                                for (int i = 0; i < shortcut.Shortcut.Length; i++)
                                {
                                    if (shortcut.Shortcut[i] != keys[i])
                                    {
                                        nFound = true;
                                        break;
                                    }
                                }

                                if (!nFound) break;
                            }
                        }
                    }
                    else
                    {
                        nFound = true;
                    }

                    if (nFound)
                    {
                        ShortcutInfo si = new ShortcutInfo();
                        si.Callback = func;
                        si.Shortcut = keys;
                        si.Arguments = args;
                        shortcuts.Add(si);
                    }
                    else
                    {
                        MessageBox.Show("The shortcut \"" + String.Join("+", keys) + "\" already exists.");
                    }
                }
            }
        }

        public void Capture()
        {
            if (shortcuts.Count > 0)
            {
                Thread t = new Thread(new ParameterizedThreadStart(AsyncCapture));

                AsyncCaptureInfo aci = new AsyncCaptureInfo();
                aci.SetCapturing = SetCapturing;
                aci.Shortcuts = shortcuts;
                aci.GetCapturing = GetCapturing;

                SetCapturing(true);
                t.Start(aci);
            }
        }

        public void StopCapturing()
        {
            SetCapturing(false);
        }
    }
}

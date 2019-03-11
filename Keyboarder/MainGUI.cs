using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Keyboarder
{
    public delegate bool GetMenuCheckedDel(ToolStripMenuItem item);
    public delegate void VoidNoParamsDel();
    public delegate void VoidParamsDel(object[] args);

    public struct KeyboardModsInfo
    {
        public GetMenuCheckedDel GetMenuChecked;
    }

    public struct KeyStatus
    {
        public Keys Key;
        public bool Activated;
        public bool Checked;
    }

    public struct CharDictionary
    {
        public Keys Key;
        public string Char;

        public CharDictionary(Keys nkey, string nchar) { Key = nkey; Char = nchar; }
    }

    namespace KeyboardEvent
    {
        public enum EventKeys
        {
            VK_BACK = 0x08,
            VK_TAB = 0x09,
            VK_CLEAR = 0x0C,
            VK_RETURN = 0x0D,
            VK_SHIFT = 0x10,
            VK_CONTROL = 0x11,
            VK_MENU = 0x12,
            VK_PAUSE = 0x13,
            VK_CAPITAL = 0x14,
            VK_KANA = 0x15,
            VK_HANGEUL = 0x15,
            VK_HANGUL = 0x15,
            VK_JUNJA = 0x17,
            VK_FINAL = 0x18,
            VK_HANJA = 0x19,
            VK_KANJI = 0x19,
            VK_ESCAPE = 0x1B,
            VK_CONVERT = 0x1C,
            VK_NONCONVERT = 0x1D,
            VK_ACCEPT = 0x1E,
            VK_MODECHANGE = 0x1F,
            VK_SPACE = 0x20,
            VK_PRIOR = 0x21,
            VK_NEXT = 0x22,
            VK_END = 0x23,
            VK_HOME = 0x24,
            VK_LEFT = 0x25,
            VK_UP = 0x26,
            VK_RIGHT = 0x27,
            VK_DOWN = 0x28,
            VK_SELECT = 0x29,
            VK_PRINT = 0x2A,
            VK_EXECUTE = 0x2B,
            VK_SNAPSHOT = 0x2C,
            VK_INSERT = 0x2D,
            VK_DELETE = 0x2E,
            VK_HELP = 0x2F,
            VK_LWIN = 0x5B,
            VK_RWIN = 0x5C,
            VK_APPS = 0x5D,
            VK_SLEEP = 0x5F,
            VK_NUMPAD0 = 0x60,
            VK_NUMPAD1 = 0x61,
            VK_NUMPAD2 = 0x62,
            VK_NUMPAD3 = 0x63,
            VK_NUMPAD4 = 0x64,
            VK_NUMPAD5 = 0x65,
            VK_NUMPAD6 = 0x66,
            VK_NUMPAD7 = 0x67,
            VK_NUMPAD8 = 0x68,
            VK_NUMPAD9 = 0x69,
            VK_MULTIPLY = 0x6A,
            VK_ADD = 0x6B,
            VK_SEPARATOR = 0x6C,
            VK_SUBTRACT = 0x6D,
            VK_DECIMAL = 0x6E,
            VK_DIVIDE = 0x6F,
            VK_F1 = 0x70,
            VK_F2 = 0x71,
            VK_F3 = 0x72,
            VK_F4 = 0x73,
            VK_F5 = 0x74,
            VK_F6 = 0x75,
            VK_F7 = 0x76,
            VK_F8 = 0x77,
            VK_F9 = 0x78,
            VK_F10 = 0x79,
            VK_F11 = 0x7A,
            VK_F12 = 0x7B,
            VK_F13 = 0x7C,
            VK_F14 = 0x7D,
            VK_F15 = 0x7E,
            VK_F16 = 0x7F,
            VK_F17 = 0x80,
            VK_F18 = 0x81,
            VK_F19 = 0x82,
            VK_F20 = 0x83,
            VK_F21 = 0x84,
            VK_F22 = 0x85,
            VK_F23 = 0x86,
            VK_F24 = 0x87,
            VK_NUMLOCK = 0x90,
            VK_SCROLL = 0x91,
            VK_OEM_NEC_EQUAL = 0x92,
            VK_OEM_FJ_JISHO = 0x92,
            VK_OEM_FJ_MASSHOU = 0x93,
            VK_OEM_FJ_TOUROKU = 0x94,
            VK_OEM_FJ_LOYA = 0x95,
            VK_OEM_FJ_ROYA = 0x96,
            VK_LSHIFT = 0xA0,
            VK_RSHIFT = 0xA1,
            VK_LCONTROL = 0xA2,
            VK_RCONTROL = 0xA3,
            VK_LMENU = 0xA4,
            VK_RMENU = 0xA5,
            VK_BROWSER_BACK = 0xA6,
            VK_BROWSER_FORWARD = 0xA7,
            VK_BROWSER_REFRESH = 0xA8,
            VK_BROWSER_STOP = 0xA9,
            VK_BROWSER_SEARCH = 0xAA,
            VK_BROWSER_FAVORITES = 0xAB,
            VK_BROWSER_HOME = 0xAC,
            VK_VOLUME_MUTE = 0xAD,
            VK_VOLUME_DOWN = 0xAE,
            VK_VOLUME_UP = 0xAF,
            VK_MEDIA_NEXT_TRACK = 0xB0,
            VK_MEDIA_PREV_TRACK = 0xB1,
            VK_MEDIA_STOP = 0xB2,
            VK_MEDIA_PLAY_PAUSE = 0xB3,
            VK_LAUNCH_MAIL = 0xB4,
            VK_LAUNCH_MEDIA_SELECT = 0xB5,
            VK_LAUNCH_APP1 = 0xB6,
            VK_LAUNCH_APP2 = 0xB7,
            VK_OEM_1 = 0xBA,
            VK_OEM_PLUS = 0xBB,
            VK_OEM_COMMA = 0xBC,
            VK_OEM_MINUS = 0xBD,
            VK_OEM_PERIOD = 0xBE,
            VK_OEM_2 = 0xBF,
            VK_OEM_3 = 0xC0,
            VK_OEM_4 = 0xDB,
            VK_OEM_5 = 0xDC,
            VK_OEM_6 = 0xDD,
            VK_OEM_7 = 0xDE,
            VK_OEM_8 = 0xDF,
            VK_OEM_AX = 0xE1,
            VK_OEM_102 = 0xE2,
            VK_ICO_HELP = 0xE3,
            VK_ICO_00 = 0xE4,
            VK_PROCESSKEY = 0xE5,
            VK_ICO_CLEAR = 0xE6,
            VK_OEM_RESET = 0xE9,
            VK_OEM_JUMP = 0xEA,
            VK_OEM_PA1 = 0xEB,
            VK_OEM_PA2 = 0xEC,
            VK_OEM_PA3 = 0xED,
            VK_OEM_WSCTRL = 0xEE,
            VK_OEM_CUSEL = 0xEF,
            VK_OEM_ATTN = 0xF0,
            VK_OEM_FINISH = 0xF1,
            VK_OEM_COPY = 0xF2,
            VK_OEM_AUTO = 0xF3,
            VK_OEM_ENLW = 0xF4,
            VK_OEM_BACKTAB = 0xF5,
            VK_ATTN = 0xF6,
            VK_CRSEL = 0xF7,
            VK_EXSEL = 0xF8,
            VK_EREOF = 0xF9,
            VK_PLAY = 0xFA,
            VK_ZOOM = 0xFB,
            VK_NONAME = 0xFC,
            VK_PA1 = 0xFD,
            VK_OEM_CLEAR = 0xFE
        }

        public enum KeyEventFlags
        {
            KEYEVENTF_EXTENDEDKEY = 0x0001,
            KEYEVENTF_KEYUP = 0x0002
        }

        public enum ScanOptions
        {
            MAPVK_VK_TO_CHAR = 2,
            MAPVK_VK_TO_VSC = 0,
            MAPVK_VSC_TO_VK = 1,
            MAPVK_VSC_TO_VK_EX = 3
        }
    }

    public partial class MainGUI : Form
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, UInt32 wdFlags, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern UInt32 MapVirtualKey(UInt32 uCode, UInt32 uMapType);

        /**************************/

        private bool DoExit = false;
        List<ToolStripMenuItem> RadioMenu = new List<ToolStripMenuItem>();
        private bool StartVisible = false;

        /**************************/

        public ToolStripMenuItem KBMods_BackwardsTyping
        {
            get { return c_KBM_BackwardsTyping; }
        }

        /**********************/

        public VoidNoParamsDel Showform;
        private void _ShowForm()
        {
            this.Show();
        }

        public VoidNoParamsDel HideForm;
        private void _HideForm()
        {
            this.Hide();
        }

        /***************************/

        public bool GetMenuChecked(ToolStripMenuItem item)
        {
            return item.Checked;
        }

        /***************************/

        void SetChecked(ToolStripMenuItem sender)
        {
            bool chState = sender.Checked;
            for (int i = 0; i < RadioMenu.Count; i++)
            {
                RadioMenu[i].Checked = false;
            }

            sender.Checked = chState;
        }

        /***************************/

        public List<Keys> MakeKeyList(Keys from, Keys to)
        {
            List<Keys> list = new List<Keys>();

            for (int i = (int)from; i <= (int)to; i++)
            {
                list.Add((Keys)i);
            }

            return list;
        }

        public List<KeyStatus> DetectKeys(List<KeyStatus> currentKeys, List<Keys> detectionList)
        {
            //check whether key is up again
            if (currentKeys.Count > 0)
            {
                for (int i = 0; i < currentKeys.Count; i++)
                {
                    if (currentKeys[i].Activated)
                    {
                        unchecked
                        {
                            if (GetAsyncKeyState((int)currentKeys[i].Key) == (short)0x0)
                            {
                                KeyStatus ks = currentKeys[i];
                                ks.Activated = false;
                                currentKeys[i] = ks;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < detectionList.Count; i++)
            {
                bool keyActivated = false;
                if (currentKeys.Count > 0)
                {
                    for (int j = currentKeys.Count - 1; j >= 0; j--)
                    {
                        if (currentKeys[j].Key == detectionList[i] && currentKeys[j].Activated)
                        {
                            keyActivated = true;
                            break;
                        }
                    }
                }

                if (!keyActivated)
                {
                    //System.Diagnostics.Debug.WriteLine("---------");
                    unchecked
                    {
                        if (GetAsyncKeyState((int)detectionList[i]) == (short)0x8000)
                        {
                            //System.Diagnostics.Debug.WriteLine(((Keys)i).ToString() + " activated.");
                            KeyStatus ks = new KeyStatus();

                            ks.Key = detectionList[i];
                            ks.Activated = true;
                            ks.Checked = false;

                            currentKeys.Add(ks);
                        }
                    }
                }
            }

            return currentKeys;
        }

        public void SetCaps(bool state)
        {
            UInt32 scan = MapVirtualKey((int)KeyboardEvent.EventKeys.VK_CAPITAL, (int)KeyboardEvent.ScanOptions.MAPVK_VK_TO_VSC);

            if (state)
            {
                keybd_event((byte)KeyboardEvent.EventKeys.VK_CAPITAL, 
                            (byte)scan, 
                            0, 
                            (UIntPtr)null);
            }
            else
            {
                keybd_event((byte)KeyboardEvent.EventKeys.VK_CAPITAL, 
                            (byte)scan, 
                            (int)KeyboardEvent.KeyEventFlags.KEYEVENTF_KEYUP, 
                            (UIntPtr)null);
            }
        }

        public string FixSpecialChars(string str)
        {
            char[] specials = new char[] { '(', ')', '{', '}', '+', '^', '~', '%'};
            string fixedStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                bool specialFound = false;
                foreach (char special in specials)
                {
                    System.Diagnostics.Debug.WriteLine(special);
                    if (str[i] == special)
                    {
                        fixedStr += "{" + str[i] + "}";
                        specialFound = true;
                        break;
                    }
                }

                if (!specialFound) fixedStr += str[i];
            }

            return fixedStr;
        }

        public void PressButton(KeyboardEvent.EventKeys Key, bool release=false)
        {
            UInt32 keyScan = MapVirtualKey((UInt32)Key, (UInt32)KeyboardEvent.ScanOptions.MAPVK_VK_TO_VSC);

            if (release)
            {
                keybd_event((byte)Key,
                            (byte)keyScan,
                            (UInt32)KeyboardEvent.KeyEventFlags.KEYEVENTF_KEYUP,
                            (UIntPtr)null);
            }
            else
            {
                keybd_event((byte)Key,
                            (byte)keyScan,
                            0,
                            (UIntPtr)null);
            }
        }

        /***************************/

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(StartVisible ? value : StartVisible);
        }

        public MainGUI()
        {
            InitializeComponent();

            Showform = _ShowForm;
            HideForm = _HideForm;

            RadioMenu.Add(c_KBM_BackwardsTyping);
            RadioMenu.Add(c_KBM_LeetSpeak);
            RadioMenu.Add(c_KBM_RandomCaps);
            RadioMenu.Add(c_KBM_MorseCode);

            SetInvokes();

            KeyboardModsInfo kmi = new KeyboardModsInfo();
            kmi.GetMenuChecked = GetMenuChecked;

            w_KeyboardMods.RunWorkerAsync(kmi);
        }

        private void c_MM_ShowConsole_Click(object sender, EventArgs e)
        {
            if (c_MM_ShowConsole.Checked)
                this.Show();
            else
                this.Hide();
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {
            
        }

        private void c_MM_Exit_Click(object sender, EventArgs e)
        {
            this.DoExit = true;
            Close();
            Application.Exit();
        }

        private void MainGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.DoExit)
            {
                e.Cancel = true;
                this.Hide();

                if (!this.Visible)
                    c_MM_ShowConsole.Checked = false;
            }
        }

        private void w_KeyboardMods_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                KeyboardModsInfo info = (KeyboardModsInfo)e.Argument;

                //////////////
                // Backwards Writing Keyboard MOD Vars
                bool backwardWriting = false;
                List<KeyStatus> bkWritingKeys = new List<KeyStatus>();
                List<Keys> BKWDetectionList = new List<Keys>();

                BKWDetectionList.AddRange(MakeKeyList(Keys.A, Keys.Z));
                BKWDetectionList.AddRange(MakeKeyList(Keys.D0, Keys.D9));

                BKWDetectionList.AddRange(MakeKeyList(Keys.Space, Keys.Space));
                BKWDetectionList.AddRange(MakeKeyList(Keys.OemMinus, Keys.OemMinus));
                BKWDetectionList.AddRange(MakeKeyList(Keys.Oemcomma, Keys.Oemcomma));
                BKWDetectionList.AddRange(MakeKeyList(Keys.OemPeriod, Keys.OemPeriod));
                BKWDetectionList.AddRange(MakeKeyList(Keys.Oemplus, Keys.Oemplus));
                BKWDetectionList.AddRange(MakeKeyList((Keys)0xDC, (Keys)0xDC));
                BKWDetectionList.AddRange(MakeKeyList((Keys)0xDB, (Keys)0xDB));
                BKWDetectionList.AddRange(MakeKeyList((Keys)0xE2, (Keys)0xE2));
                BKWDetectionList.AddRange(MakeKeyList((Keys)0xBA, (Keys)0xBA));
                BKWDetectionList.AddRange(MakeKeyList((Keys)0xDD, (Keys)0xDD));
                BKWDetectionList.AddRange(MakeKeyList((Keys)0xC0, (Keys)0xC0));
                BKWDetectionList.AddRange(MakeKeyList((Keys)0xDE, (Keys)0xDE));
                BKWDetectionList.AddRange(MakeKeyList((Keys)0xBF, (Keys)0xBF));

                //////////////
                // Leet Speak Keyboard MOD Vars
                bool leetSpeak = false;
                List<KeyStatus> lsWritingKeys = new List<KeyStatus>();
                List<Keys> LSDetectionList = new List<Keys>();

                LSDetectionList.AddRange(MakeKeyList(Keys.A, Keys.Z));

                CharDictionary[] LeetSpeakDic = new CharDictionary[]
                {
                    new CharDictionary(Keys.A, "4"),
                    new CharDictionary(Keys.B, "8"),
                    new CharDictionary(Keys.C, "("),
                    new CharDictionary(Keys.D, "|)"),
                    new CharDictionary(Keys.E, "3"),
                    new CharDictionary(Keys.F, "|="),
                    new CharDictionary(Keys.G, "6"),
                    new CharDictionary(Keys.H, "|-|"),
                    new CharDictionary(Keys.I, "1"),
                    new CharDictionary(Keys.J, ".|"),
                    new CharDictionary(Keys.K, "|<"),
                    new CharDictionary(Keys.L, "|_"),
                    new CharDictionary(Keys.M, "/\\/\\"),
                    new CharDictionary(Keys.N, "|\\|"),
                    new CharDictionary(Keys.O, "0"),
                    new CharDictionary(Keys.P, "P"),
                    new CharDictionary(Keys.Q, "9"),
                    new CharDictionary(Keys.R, "2"),
                    new CharDictionary(Keys.S, "5"),
                    new CharDictionary(Keys.T, "7"),
                    new CharDictionary(Keys.U, "|_|"),
                    new CharDictionary(Keys.V, "\\/"),
                    new CharDictionary(Keys.W, "\\/\\/"),
                    new CharDictionary(Keys.X, "X"),
                    new CharDictionary(Keys.Y, "Y"),
                    new CharDictionary(Keys.Z, "Z"),
                    new CharDictionary((Keys)0xDD, "Å"),
                    new CharDictionary((Keys)0xC0, "Ø"),
                    new CharDictionary((Keys)0xDE, "Æ")
                };

                CharDictionary[] LeetSpeakDicEasy = new CharDictionary[]
                {
                    new CharDictionary(Keys.A, "4"),
                    new CharDictionary(Keys.B, "8"),
                    new CharDictionary(Keys.C, "c"),
                    new CharDictionary(Keys.D, "d"),
                    new CharDictionary(Keys.E, "3"),
                    new CharDictionary(Keys.F, "f"),
                    new CharDictionary(Keys.G, "6"),
                    new CharDictionary(Keys.H, "h"),
                    new CharDictionary(Keys.I, "1"),
                    new CharDictionary(Keys.J, "j"),
                    new CharDictionary(Keys.K, "k"),
                    new CharDictionary(Keys.L, "l"),
                    new CharDictionary(Keys.M, "m"),
                    new CharDictionary(Keys.N, "n"),
                    new CharDictionary(Keys.O, "0"),
                    new CharDictionary(Keys.P, "p"),
                    new CharDictionary(Keys.Q, "9"),
                    new CharDictionary(Keys.R, "2"),
                    new CharDictionary(Keys.S, "5"),
                    new CharDictionary(Keys.T, "7"),
                    new CharDictionary(Keys.U, "u"),
                    new CharDictionary(Keys.V, "v"),
                    new CharDictionary(Keys.W, "w"),
                    new CharDictionary(Keys.X, "x"),
                    new CharDictionary(Keys.Y, "y"),
                    new CharDictionary(Keys.Z, "z"),
                    new CharDictionary((Keys)0xDD, "å"),    // Å
                    new CharDictionary((Keys)0xC0, "ø"),    // Ø
                    new CharDictionary((Keys)0xDE, "æ")     // Æ
                };

                //////////////
                // Random Capital Letters Keyboard MOD Vars
                bool randomCaps = false;

                //////////////
                // Morse Code Keyboard MOD vars
                bool morseCode = false;
                List<KeyStatus> mcWritingKeys = new List<KeyStatus>();
                List<Keys> MCDetectionList = new List<Keys>();

                MCDetectionList.AddRange(MakeKeyList(Keys.A, Keys.Z));
                MCDetectionList.AddRange(MakeKeyList(Keys.D0, Keys.D9));
                MCDetectionList.AddRange(MakeKeyList(Keys.Space, Keys.Space));

                CharDictionary[] MorseCodeDict = new CharDictionary[]
                {
                    new CharDictionary(Keys.A, ".-"),
                    new CharDictionary(Keys.B, "-..."),
                    new CharDictionary(Keys.C, "-.-."),
                    new CharDictionary(Keys.D, "-.."),
                    new CharDictionary(Keys.E, "."),
                    new CharDictionary(Keys.F, "..-."),
                    new CharDictionary(Keys.G, "--."),
                    new CharDictionary(Keys.H, "...."),
                    new CharDictionary(Keys.I, ".."),
                    new CharDictionary(Keys.J, ".---"),
                    new CharDictionary(Keys.K, "-.-"),
                    new CharDictionary(Keys.L, ".-.."),
                    new CharDictionary(Keys.M, "--"),
                    new CharDictionary(Keys.N, "-."),
                    new CharDictionary(Keys.O, "---"),
                    new CharDictionary(Keys.P, ".--."),
                    new CharDictionary(Keys.Q, "--.-"),
                    new CharDictionary(Keys.R, ".-."),
                    new CharDictionary(Keys.S, "..."),
                    new CharDictionary(Keys.T, "-"),
                    new CharDictionary(Keys.U, "..-"),
                    new CharDictionary(Keys.V, "...-"),
                    new CharDictionary(Keys.W, ".--"),
                    new CharDictionary(Keys.X, "-..-"),
                    new CharDictionary(Keys.Y, "-.--"),
                    new CharDictionary(Keys.Z, "--.."),

                    new CharDictionary(Keys.D0, ".----"),
                    new CharDictionary(Keys.D1, "..---"),
                    new CharDictionary(Keys.D2, "...--"),
                    new CharDictionary(Keys.D3, "....-"),
                    new CharDictionary(Keys.D4, "....."),
                    new CharDictionary(Keys.D5, "-...."),
                    new CharDictionary(Keys.D6, "--..."),
                    new CharDictionary(Keys.D7, "---.."),
                    new CharDictionary(Keys.D8, "---.."),
                    new CharDictionary(Keys.D9, "-----"),

                    new CharDictionary(Keys.Space, "   ")

                };

                //////////////

                while (true)
                {
                    /***********************************/
                    // Backwards Writing Keyboard MOD
                    //
                    // these states run 1 time per state change
                    if (!backwardWriting && info.GetMenuChecked(c_KBM_BackwardsTyping))
                    {
                        backwardWriting = true;
                    }
                    else if (backwardWriting && !info.GetMenuChecked(c_KBM_BackwardsTyping))
                    {
                        backwardWriting = false;
                    }

                    if (backwardWriting)
                    {// always runs if activated, main mod code
                        System.Diagnostics.Debug.WriteLine("BackwardsWriting Activated.");

                        // get pressed keys
                        bkWritingKeys = DetectKeys(bkWritingKeys, BKWDetectionList);

                        if (bkWritingKeys.Count > 0)
                        {
                            for (int i = 0; i < bkWritingKeys.Count; i++)
                            {
                                if (!bkWritingKeys[i].Checked)
                                {
                                    SendKeys.SendWait("{LEFT}");

                                    KeyStatus ks = bkWritingKeys[i];
                                    ks.Checked = true;

                                    bkWritingKeys[i] = ks;
                                }
                            }
                        }

                    }
                    else
                    {// always runs if deactivated

                    }

                    /***********************************/
                    // Leet Speak Keyboard MOD
                    //
                    // these states run 1 time per state change
                    if (!leetSpeak && info.GetMenuChecked(c_KBM_LeetSpeak))
                    {
                        leetSpeak = true;
                    }
                    else if (leetSpeak && !info.GetMenuChecked(c_KBM_LeetSpeak))
                    {
                        leetSpeak = false;
                    }

                    if (leetSpeak)
                    {// always runs if activated, main mod code
                        //System.Diagnostics.Debug.WriteLine("LeetSpeak Activated.");

                        lsWritingKeys = DetectKeys(lsWritingKeys, LSDetectionList);

                        if (lsWritingKeys.Count > 0)
                        {
                            for (int i = 0; i < lsWritingKeys.Count; i++)
                            {
                                if (!lsWritingKeys[i].Checked)
                                {
                                    KeyStatus ks = lsWritingKeys[i];
                                    ks.Checked = true;

                                    lsWritingKeys[i] = ks;

                                    SendKeys.SendWait("{BS}");

                                    // get char from dict
                                    for (int j = 0; j < LeetSpeakDicEasy.Length; j++)
                                    {
                                        if (LeetSpeakDicEasy[j].Key == lsWritingKeys[i].Key)
                                        {
                                            SendKeys.SendWait(FixSpecialChars(LeetSpeakDicEasy[j].Char));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {// always runs if deactivated

                    }

                    /***********************************/
                    // Random Capital Letters Keyboard MOD
                    //
                    // these states run 1 time per state change
                    if (!randomCaps && info.GetMenuChecked(c_KBM_RandomCaps))
                    {
                        randomCaps = true;
                    }
                    else if (randomCaps && !info.GetMenuChecked(c_KBM_RandomCaps))
                    {
                        if (GetKeyState((int)KeyboardEvent.EventKeys.VK_CAPITAL) == (short)0x1)
                        {
                            SetCaps(true);
                            SetCaps(false);
                        }

                        randomCaps = false;
                    }

                    if (randomCaps)
                    {// always runs if activated, main mod code
                        System.Diagnostics.Debug.WriteLine("RandomCaps Activated.");
                        
                        SetCaps(true);
                        SetCaps(false);

                        Thread.Sleep(100);

                    }
                    else
                    {// always runs if deactivated
                            
                    }

                    /***********************************/
                    // Morse Code Keyboard MOD
                    //
                    // these states run 1 time per state change
                    if (!morseCode && info.GetMenuChecked(c_KBM_MorseCode))
                    {
                        morseCode = true;
                    }
                    else if (morseCode && !info.GetMenuChecked(c_KBM_MorseCode))
                    {
                        morseCode = false;
                    }

                    if (morseCode)
                    {// always runs if activated, main mod code
                        //System.Diagnostics.Debug.WriteLine("MorseCode Activated.");

                        mcWritingKeys = DetectKeys(mcWritingKeys, MCDetectionList);
                        
                        if (mcWritingKeys.Count > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("yes");
                            for (int i = 0; i < mcWritingKeys.Count; i++)
                            {
                                if (!mcWritingKeys[i].Checked)
                                {
                                    KeyStatus ks = mcWritingKeys[i];
                                    ks.Checked = true;

                                    mcWritingKeys[i] = ks;

                                    SendKeys.SendWait("{BS}");

                                    // get char from dict
                                    for (int j = 0; j < MorseCodeDict.Length; j++)
                                    {
                                        if (MorseCodeDict[j].Key == mcWritingKeys[i].Key)
                                        {
                                            SendKeys.SendWait(FixSpecialChars(MorseCodeDict[j].Char) + " ");
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {// always runs if deactivated

                    }
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n############ STACKTRACE:\n" + ex.StackTrace + "\n####################\n IF YOU SEE THIS MESSAGE, PRESS CTRL+C WHILE HAVING THIS MESSAGE ACTIVE AND SEND TO DEVELOPER (SNIXTHO).");
            }
        }

        private void c_KBM_BackwardsTyping_Click(object sender, EventArgs e)
        {
            SetChecked((ToolStripMenuItem)sender);
        }

        private void c_KBM_LeetSpeak_Click(object sender, EventArgs e)
        {
            SetChecked((ToolStripMenuItem)sender);
        }

        private void c_KBM_RandomCaps_Click(object sender, EventArgs e)
        {
            SetChecked((ToolStripMenuItem)sender);
        }

        private void c_KBM_MorseCode_Click(object sender, EventArgs e)
        {
            SetChecked((ToolStripMenuItem)sender);
        }
    }
}

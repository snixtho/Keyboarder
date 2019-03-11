namespace Keyboarder
{
    partial class MainGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.c_MainNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.c_MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.c_MM_ShowConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.keyboardModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_KBM_BackwardsTyping = new System.Windows.Forms.ToolStripMenuItem();
            this.c_KBM_LeetSpeak = new System.Windows.Forms.ToolStripMenuItem();
            this.c_KBM_RandomCaps = new System.Windows.Forms.ToolStripMenuItem();
            this.c_KBM_MorseCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.c_MM_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.c_Console = new System.Windows.Forms.RichTextBox();
            this.w_KeyboardMods = new System.ComponentModel.BackgroundWorker();
            this.c_MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_MainNotify
            // 
            this.c_MainNotify.ContextMenuStrip = this.c_MainMenu;
            this.c_MainNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("c_MainNotify.Icon")));
            this.c_MainNotify.Text = "Keyboarder - By snixtho (http:://snixtho.zurvan-labs.net)";
            this.c_MainNotify.Visible = true;
            // 
            // c_MainMenu
            // 
            this.c_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_MM_ShowConsole,
            this.toolStripSeparator1,
            this.keyboardModsToolStripMenuItem,
            this.toolStripSeparator2,
            this.c_MM_Exit});
            this.c_MainMenu.Name = "c_MainMenu";
            this.c_MainMenu.Size = new System.Drawing.Size(158, 82);
            // 
            // c_MM_ShowConsole
            // 
            this.c_MM_ShowConsole.CheckOnClick = true;
            this.c_MM_ShowConsole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_MM_ShowConsole.Name = "c_MM_ShowConsole";
            this.c_MM_ShowConsole.Size = new System.Drawing.Size(157, 22);
            this.c_MM_ShowConsole.Text = "Show Console";
            this.c_MM_ShowConsole.Visible = false;
            this.c_MM_ShowConsole.Click += new System.EventHandler(this.c_MM_ShowConsole_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // keyboardModsToolStripMenuItem
            // 
            this.keyboardModsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_KBM_BackwardsTyping,
            this.c_KBM_LeetSpeak,
            this.c_KBM_RandomCaps,
            this.c_KBM_MorseCode});
            this.keyboardModsToolStripMenuItem.Name = "keyboardModsToolStripMenuItem";
            this.keyboardModsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.keyboardModsToolStripMenuItem.Text = "Keyboard Mods";
            // 
            // c_KBM_BackwardsTyping
            // 
            this.c_KBM_BackwardsTyping.CheckOnClick = true;
            this.c_KBM_BackwardsTyping.Name = "c_KBM_BackwardsTyping";
            this.c_KBM_BackwardsTyping.Size = new System.Drawing.Size(169, 22);
            this.c_KBM_BackwardsTyping.Text = "Backwards Typing";
            this.c_KBM_BackwardsTyping.ToolTipText = "Everything you type will be written in a reverse way.";
            this.c_KBM_BackwardsTyping.Click += new System.EventHandler(this.c_KBM_BackwardsTyping_Click);
            // 
            // c_KBM_LeetSpeak
            // 
            this.c_KBM_LeetSpeak.CheckOnClick = true;
            this.c_KBM_LeetSpeak.Name = "c_KBM_LeetSpeak";
            this.c_KBM_LeetSpeak.Size = new System.Drawing.Size(169, 22);
            this.c_KBM_LeetSpeak.Text = "1337 Speak";
            this.c_KBM_LeetSpeak.ToolTipText = "Replace characters you type with 1337 speak characters.";
            this.c_KBM_LeetSpeak.Click += new System.EventHandler(this.c_KBM_LeetSpeak_Click);
            // 
            // c_KBM_RandomCaps
            // 
            this.c_KBM_RandomCaps.CheckOnClick = true;
            this.c_KBM_RandomCaps.Name = "c_KBM_RandomCaps";
            this.c_KBM_RandomCaps.Size = new System.Drawing.Size(169, 22);
            this.c_KBM_RandomCaps.Text = "Random Caps";
            this.c_KBM_RandomCaps.ToolTipText = "Randomly enable capital letters while you type.";
            this.c_KBM_RandomCaps.Click += new System.EventHandler(this.c_KBM_RandomCaps_Click);
            // 
            // c_KBM_MorseCode
            // 
            this.c_KBM_MorseCode.CheckOnClick = true;
            this.c_KBM_MorseCode.Name = "c_KBM_MorseCode";
            this.c_KBM_MorseCode.Size = new System.Drawing.Size(169, 22);
            this.c_KBM_MorseCode.Text = "Morse Code";
            this.c_KBM_MorseCode.Click += new System.EventHandler(this.c_KBM_MorseCode_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // c_MM_Exit
            // 
            this.c_MM_Exit.Name = "c_MM_Exit";
            this.c_MM_Exit.Size = new System.Drawing.Size(157, 22);
            this.c_MM_Exit.Text = "Exit";
            this.c_MM_Exit.Click += new System.EventHandler(this.c_MM_Exit_Click);
            // 
            // c_Console
            // 
            this.c_Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_Console.Location = new System.Drawing.Point(0, 0);
            this.c_Console.Name = "c_Console";
            this.c_Console.ReadOnly = true;
            this.c_Console.Size = new System.Drawing.Size(355, 179);
            this.c_Console.TabIndex = 1;
            this.c_Console.Text = "";
            // 
            // w_KeyboardMods
            // 
            this.w_KeyboardMods.WorkerReportsProgress = true;
            this.w_KeyboardMods.DoWork += new System.ComponentModel.DoWorkEventHandler(this.w_KeyboardMods_DoWork);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 179);
            this.Controls.Add(this.c_Console);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboarder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGUI_FormClosing);
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.c_MainMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon c_MainNotify;
        private System.Windows.Forms.ContextMenuStrip c_MainMenu;
        private System.Windows.Forms.ToolStripMenuItem c_MM_ShowConsole;
        private System.Windows.Forms.RichTextBox c_Console;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem keyboardModsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c_KBM_BackwardsTyping;
        private System.Windows.Forms.ToolStripMenuItem c_KBM_LeetSpeak;
        private System.Windows.Forms.ToolStripMenuItem c_KBM_RandomCaps;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem c_MM_Exit;
        private System.ComponentModel.BackgroundWorker w_KeyboardMods;
        private System.Windows.Forms.ToolStripMenuItem c_KBM_MorseCode;
    }
}


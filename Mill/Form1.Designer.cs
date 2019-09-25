

namespace Mill
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.humanVsHumanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.humanVsAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aIVsHumanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aIVsAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe Print", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameSettingsToolStripMenuItem
            // 
            this.gameSettingsToolStripMenuItem.BackColor = System.Drawing.Color.NavajoWhite;
            this.gameSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.humanVsHumanToolStripMenuItem,
            this.humanVsAIToolStripMenuItem,
            this.aIVsHumanToolStripMenuItem,
            this.aIVsAIToolStripMenuItem});
            this.gameSettingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gameSettingsToolStripMenuItem.Name = "gameSettingsToolStripMenuItem";
            this.gameSettingsToolStripMenuItem.Size = new System.Drawing.Size(133, 27);
            this.gameSettingsToolStripMenuItem.Text = "Game Settings";
            // 
            // humanVsHumanToolStripMenuItem
            // 
            this.humanVsHumanToolStripMenuItem.Name = "humanVsHumanToolStripMenuItem";
            this.humanVsHumanToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.humanVsHumanToolStripMenuItem.Text = "Human vs Human";
            this.humanVsHumanToolStripMenuItem.Click += HumanVsHumanClick;
            // 
            // humanVsAIToolStripMenuItem
            // 
            this.humanVsAIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem});
            this.humanVsAIToolStripMenuItem.Name = "humanVsAIToolStripMenuItem";
            this.humanVsAIToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.humanVsAIToolStripMenuItem.Text = "Human vs AI";
            // 
            // aIVsHumanToolStripMenuItem
            // 
            this.aIVsHumanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem1,
            this.mediumToolStripMenuItem1});
            this.aIVsHumanToolStripMenuItem.Name = "aIVsHumanToolStripMenuItem";
            this.aIVsHumanToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.aIVsHumanToolStripMenuItem.Text = "AI vs Human";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.easyToolStripMenuItem.Text = "Minimax";
            this.easyToolStripMenuItem.Click += HumanVsMinimaxClick;
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.mediumToolStripMenuItem.Text = "AlfaBeta";
            this.mediumToolStripMenuItem.Click += HumanVsAlfaBetaClick;
            // 
            // easyToolStripMenuItem1
            // 
            this.easyToolStripMenuItem1.Name = "easyToolStripMenuItem1";
            this.easyToolStripMenuItem1.Size = new System.Drawing.Size(216, 26);
            this.easyToolStripMenuItem1.Text = "Minimax";
            this.easyToolStripMenuItem1.Click += MinimaxVsHumanClick;
            // 
            // mediumToolStripMenuItem1
            // 
            this.mediumToolStripMenuItem1.Name = "mediumToolStripMenuItem1";
            this.mediumToolStripMenuItem1.Size = new System.Drawing.Size(216, 26);
            this.mediumToolStripMenuItem1.Text = "AlfaBeta";
            this.mediumToolStripMenuItem1.Click += AlfaBetaVsHumanClick;
            // 
            // aIVsAIToolStripMenuItem
            // 
            this.aIVsAIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem2,
            this.mediumToolStripMenuItem2, this.mediumToolStripMenuItem3});
            this.aIVsAIToolStripMenuItem.Name = "aIVsAIToolStripMenuItem";
            this.aIVsAIToolStripMenuItem.Size = new System.Drawing.Size(223, 28);
            this.aIVsAIToolStripMenuItem.Text = "AI vs AI";
            // 
            // easyToolStripMenuItem2
            // 
            this.easyToolStripMenuItem2.Name = "easyToolStripMenuItem2";
            this.easyToolStripMenuItem2.Size = new System.Drawing.Size(216, 26);
            this.easyToolStripMenuItem2.Text = "Minimax vs AlfaBeta";
            this.easyToolStripMenuItem2.Click += AIvsAiClick;
            // 
            // mediumToolStripMenuItem2
            // 
            this.mediumToolStripMenuItem2.Name = "mediumToolStripMenuItem2";
            this.mediumToolStripMenuItem2.Size = new System.Drawing.Size(216, 26);
            this.mediumToolStripMenuItem2.Text = "Minimax vs Minimax";
            this.mediumToolStripMenuItem2.Click += AIvsAi2Click;
            //
            // mediumToolStripMenuItem3
            // 
            this.mediumToolStripMenuItem3.Name = "mediumToolStripMenuItem3";
            this.mediumToolStripMenuItem3.Size = new System.Drawing.Size(216, 26);
            this.mediumToolStripMenuItem3.Text = "AlfaBeta vs AlfaBeta";
            this.mediumToolStripMenuItem3.Click += AIvsAI3Click;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(600, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Play Again";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += OnButtonClick;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(460, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 27);
            this.button2.TabIndex = 0;
            this.button2.Text = "Next Move";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += NextMoveClick;
            // 
            // textBox1
            // 
            textBox1.BackColor = System.Drawing.Color.Goldenrod;
            textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            textBox1.Enabled = false;
            textBox1.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox1.ForeColor = System.Drawing.Color.Black;
            textBox1.Location = new System.Drawing.Point(0, 705);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ShortcutsEnabled = false;
            textBox1.Size = new System.Drawing.Size(782, 48);
            textBox1.TabIndex = 0;
            textBox1.Text = "White Player Starts";
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            //labels
            //
            short[] coordinates1 = { 94, 367, 640 };
            short[] coordinates2 = { 185, 367, 548 };
            short[] coordinates3 = { 277, 369, 457 };
            short[] c;
            int j = 0;
            void CreateLabels(short k, short[] coordinates)
            {
                for (int i = 0; i < 3; i++)
                {
                    this.LB = new System.Windows.Forms.Label();
                    this.LB.Name = "label" + j.ToString();
                    this.LB.BackColor = System.Drawing.Color.Transparent;
                    this.LB.Location = new System.Drawing.Point(k, coordinates[i]);
                    this.LB.Size = new System.Drawing.Size(40, 40);
                    this.LB.Enabled = true;
                    this.LB.Click += OnLabelClick;
                    this.Controls.Add(LB);
                    j++;
                }
            }
            CreateLabels(101, coordinates1);
            CreateLabels(644, coordinates1);
            CreateLabels(191, coordinates2);
            CreateLabels(555, coordinates2);
            CreateLabels(282, coordinates3);
            CreateLabels(464, coordinates3);
            CreateLabels(374, c = new short[] { coordinates1[0], coordinates2[0], coordinates3[0] });
            CreateLabels(374, c = new short[] { coordinates3[2], coordinates2[2], coordinates1[2] });
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Mill.Properties.Resources.millBoardFinished;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.MaximizeBox = false;
            this.Controls.Add(textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mill";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LB;
        public static System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem humanVsHumanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem humanVsAIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aIVsHumanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aIVsAIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem3;
    }
}


namespace Nine_men_s_morris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.Board = new System.Windows.Forms.Label();
            this.place_a0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Board
            // 
            this.Board.BackColor = System.Drawing.Color.Transparent;
            this.Board.Image = ((System.Drawing.Image)(resources.GetObject("Board.Image")));
            this.Board.Location = new System.Drawing.Point(120, 50);
            this.Board.Margin = new System.Windows.Forms.Padding(0);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(326, 326);
            this.Board.TabIndex = 0;
            // 
            // place_a0
            // 
            this.place_a0.BackColor = System.Drawing.Color.White;
            this.place_a0.Location = new System.Drawing.Point(130, 330);
            this.place_a0.Margin = new System.Windows.Forms.Padding(0);
            this.place_a0.Name = "place_a0";
            this.place_a0.Size = new System.Drawing.Size(35, 35);
            this.place_a0.TabIndex = 1;
            this.place_a0.Click += new System.EventHandler(this.Place_a0_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(750, 460);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.place_a0);
            this.Controls.Add(this.Board);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nine men\'s morris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label Board;
        private System.Windows.Forms.Label place_a0;
        private System.Windows.Forms.Label label1;
    }
}


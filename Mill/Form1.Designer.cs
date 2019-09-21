

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
            textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            textBox1.Text = "White Player";
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            //labels
            //
            short[] coordinates1 = { 97, 370, 643 };
            short[] coordinates2 = { 188, 370, 551 };
            short[] coordinates3 = { 280, 372, 460 };
            short[] c;
            int j = 0;
            void CreateLabels(short k, short[] coordinates)
            {
                for (int i = 0; i < 3; i++)
                {
                    this.LB = new System.Windows.Forms.Label();
                    this.LB.Name = "label" + j.ToString();
                    this.LB.BackColor = System.Drawing.Color.Gray;
                    this.LB.Location = new System.Drawing.Point(k, coordinates[i]);
                    this.LB.Size = new System.Drawing.Size(40, 40);
                    this.LB.Enabled = true;
                    this.LB.Click += OnLabelClick;
                    Controls.Add(LB);
                    j++;
                }
            }
            CreateLabels(104, coordinates1);
            CreateLabels(650, coordinates1);
            CreateLabels(194, coordinates2);
            CreateLabels(558, coordinates2);
            CreateLabels(285, coordinates3);
            CreateLabels(467, coordinates3);
            CreateLabels(377, c = new short[] { coordinates1[0], coordinates2[0], coordinates3[0]});
            CreateLabels(377, c = new short[] { coordinates1[2], coordinates2[2], coordinates3[2] });
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Mill.Properties.Resources.millBoardFinished;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mill";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public static System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label LB;
    }
}


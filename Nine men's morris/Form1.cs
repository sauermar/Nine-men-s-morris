using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nine_men_s_morris
{
    public partial class Form1 : Form
    {
        public static bool LabelWasClicked = false;
        public static int PlaceOnBoard;
        public Form1()
        {
            InitializeComponent();
            //place_a0.parent = Board;
           // place_a0.Hide();
        }

        private void Place_a0_Click(object sender, EventArgs e)
        {
            //animation
            LabelWasClicked = true;
            label1.Text = "madafaka";
            PlaceOnBoard = 0;
            place_a0.Enabled = false;

        }
    }
}

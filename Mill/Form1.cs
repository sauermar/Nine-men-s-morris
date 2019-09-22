using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mill
{
    public partial class Form1 : Form
    {
        private enum GamePhase { opening, midPhase, finishing };
        private GamePhase gamePhase = GamePhase.opening;
        private Board board = new Board();
        private bool blackIsPlaying = false;
        public static short numberOfWhiteStones = 0;
        public static short numberOfBlackStones = 0;
        public Form1()
        {
            
            InitializeComponent();
            board.CreateBoard();
        }


        private void OnLabelClick (object sender, EventArgs e)
        {

            if ((gamePhase == GamePhase.opening) && (numberOfBlackStones < 9))
            {
                Label label = sender as Label;
                if (label != null)
                {
                    OpeningPhase(board, label);
                }
            }
            else if ((gamePhase == GamePhase.opening) && (numberOfBlackStones == 9))
            {
                gamePhase = GamePhase.midPhase;
            }
            else if (gamePhase == GamePhase.midPhase)
            {
                Label label = sender as Label;
                if (label != null)
                {

                }
            }

        }

        private void OpeningPhase(Board board, Label label)
        {

            label.Enabled = false;

            board.PutStoneOnBoard(blackIsPlaying, label);

            if (board.IsMill())
            {
                board.TakeStoneFromBoard(blackIsPlaying);
            }

            blackIsPlaying = !blackIsPlaying;

        }


    }
}

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
        private short openingCounter = 0; 
        private Board board = new Board();
        private bool blackIsPlaying = false;
        public Form1()
        {
            
            InitializeComponent();
            board.CreateBoard();
        }


        private void OnLabelClick (object sender, EventArgs e)
        {
            if ((gamePhase == GamePhase.opening) && (openingCounter < 18))
            {
                Label label = sender as Label;
                if (label != null)
                {
                    OpeningPhase(board, label);
                    openingCounter++;
                }
            }
            else if ((gamePhase == GamePhase.opening) && (openingCounter == 18))
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
            short numberOfWhiteStones = 0;
            short numberOfBlackStones = 0;

            label.Enabled = false;

            board.PutStoneOnBoard(blackIsPlaying, label);

            blackIsPlaying = !blackIsPlaying;

        }


    }
}

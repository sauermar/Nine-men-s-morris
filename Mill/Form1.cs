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
        private bool takeStone = false;
        public static bool slideStone = false;
        public static short numberOfWhiteStones = 0;
        public static short numberOfBlackStones = 0;
        public static short counter = 0;
        public Form1()
        {
            
            InitializeComponent();
            board.CreateBoard();
        }


        private void OnLabelClick (object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                if (!takeStone)
                {
                    if (gamePhase == GamePhase.opening)
                    {
                        OpeningPhase(label);
                        if (counter == 18)
                        {
                            label.Update();
                            gamePhase = GamePhase.midPhase;
                            textBox1.Text = "End of the opening phase";
                            textBox1.Update();
                            System.Threading.Thread.Sleep(3000);
                            textBox1.Text = "White Player Starts";
                        }
                    }
                    else if (gamePhase == GamePhase.midPhase)
                    {
                       if ((numberOfBlackStones == 3) || (numberOfWhiteStones == 3))
                        {
                            //FinishingPhase
                        }
                        else if (slideStone)
                        {
                            if (board.SlideStone(blackIsPlaying, label))
                            {
                                slideStone = false;

                                if (board.IsMill())
                                {
                                    textBox1.Text = "Mill, take opponent's stone";
                                    takeStone = true;
                                }
                                else
                                {
                                    blackIsPlaying = !blackIsPlaying;
                                    if (blackIsPlaying) { textBox1.Text = "Black Player"; }
                                    else { textBox1.Text = "White Player"; }
                                }
                            }
                        }
                       else
                        {
                            MidGamePhase(label);
                        }
                    }
                }
                else
                {
                    bool confirmation = board.TakeStoneFromBoard(blackIsPlaying, label);
                    if (confirmation)
                    {
                        takeStone = false;
                        blackIsPlaying = !blackIsPlaying;
                        if(blackIsPlaying)
                        {
                            textBox1.Text = "Black Player";
                        }
                        else
                        {
                            textBox1.Text = "White Player";
                        }
                    }
                }
            }

        }

        private void OpeningPhase(Label label)
        {

            if (board.PutStoneOnBoard(blackIsPlaying, label))
            {
                counter++;
                blackIsPlaying = !blackIsPlaying;
            }

            if (board.IsMill())
            {
                blackIsPlaying = !blackIsPlaying;
                textBox1.Text = "Mill, take opponent's stone";
                takeStone = true;
            }
        }

        private void MidGamePhase(Label label)
        {
            if (board.CanStoneBeSlided(blackIsPlaying, label))
            {
                slideStone = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Mill.BoardEvaluation;
using Mill.AI;

namespace Mill
{
    public partial class Form1 : Form
    {
        public enum GamePhase { opening, midPhase, finishing };
        public static GamePhase gamePhase = GamePhase.opening;
        private Board board = new Board();
        private bool blackIsPlaying = false;
        private bool takeStone, lastThreeBlack, lastThreeWhite = false;
        public static bool slideStone, gameWon = false;
        public static short numberOfWhiteStones = 9;
        public static short numberOfBlackStones = 9;
        public static short counter, playedMoves1, playedMoves2 = 0;
        private bool humanVshuman = true;
        private bool MinimaxVshuman, AlfaBetaVShuman, AIvsAI, different, AB, AIRandomMove1, AIRandomMove2 = false;
        public static bool AIturn = false;
        private TakeStoneHeuristic takeStoneHeuristic = new TakeStoneHeuristic();
        private Move[] firstpreviousMoveResults = new Move[6];
        private Move[] secondpreviousMoveResults = new Move[6];


        public Form1()
        {

            InitializeComponent();
            board.CreateBoard();
        }

        private void OnLabelClick(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                board.NewLabel = label;
                Tuple<int, int> tupleOfIndexes = board.GetTupleOfIndexes(label);
                if (humanVshuman)
                {
                    if (!AIturn)
                    {
                        HumanVsHuman(tupleOfIndexes);

                    }
                    else
                    {
                        textBox1.Text = "Press 'Next Move' button";
                    }
                }
            }
        }

        private void Decider()
        {
            if ((gamePhase == GamePhase.midPhase) && ((lastThreeBlack == true) || (lastThreeWhite == true)))
            {
                gamePhase = GamePhase.finishing;
            }
            else if ((gamePhase == GamePhase.finishing) && ((lastThreeBlack == false) || (lastThreeWhite == false)))
            {
                gamePhase = GamePhase.midPhase;
            }
        }

        private void OpeningPhase(Tuple<int, int> tupleOfIndexes)
        {

            if (board.PutStoneOnBoard(blackIsPlaying, tupleOfIndexes))
            {
                counter++;
                blackIsPlaying = !blackIsPlaying;
            }

            if (board.IsMill(board.board, board.whiteMills, board.blackMills))
            {
                blackIsPlaying = !blackIsPlaying;
                textBox1.Text = "Mill, take opponent's stone";
                textBox1.Update();
                takeStone = true;
            }
        }

        private void MidGamePhase(Tuple<int, int> tupleOfIndexes)
        {
            if (board.CanStoneBeSlided(blackIsPlaying, tupleOfIndexes))
            {
                slideStone = true;
            }
        }

        private void GameWon(bool blackIsPlaying)
        {
            if (blackIsPlaying)
            {
                textBox1.Text = "Black Player won the game!";
            }
            else
            {
                textBox1.Text = "White Player won the game!";
            }

            for(int i = 0; i < 24; i++)
            {
                string labelName = "label" + i;
                Label label = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                label.Enabled = false;
            }

        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Process CurrentProcess = Process.GetCurrentProcess();
            Process.Start("Mill.exe");
            CurrentProcess.CloseMainWindow();
        }

        private void NextMoveClick(object sender, EventArgs e)
        {
            if (AIvsAI)
            {
                while (gameWon == false)
                {
                    if (different)
                    {
                        AIplay(true);
                    }
                    else
                    {
                        AIplay(false);
                    }
                    if (gamePhase != GamePhase.opening) { System.Threading.Thread.Sleep(50); }
                }
            }
            else
            {
                if (AIturn)
                {
                    if (MinimaxVshuman)
                    {
                        AIplay(true);
                    }
                    else if (AlfaBetaVShuman)
                    {
                        AIplay(false);
                    }
                }
            }
            
        }

        private void HumanVsHumanClick(object sender, EventArgs e)
        {
            humanVshuman = true;
        }

        private void MinimaxVsHumanClick(object sender, EventArgs e)
        {
            MinimaxVshuman = true;
            AIturn = true;
            textBox1.Text = "Ai starts, to proceed press the 'Next Move' button";
        }
        private void AlfaBetaVsHumanClick(object sender, EventArgs e)
        {
            AlfaBetaVShuman = true;
            AIturn = true;
            textBox1.Text = "Ai starts, to proceed press the 'Next Move' button";
        }
        private void HumanVsAlfaBetaClick(object sender, EventArgs e)
        {
            AlfaBetaVShuman = true;
        }

        private void HumanVsMinimaxClick(object sender, EventArgs e)
        {
            MinimaxVshuman = true;
        }
 
        private void AIvsAiClick (object sender, EventArgs e)
        {
            AIvsAI = true;
            humanVshuman = false;
            different = true;
            textBox1.Text = "Press 'Next Move' button for starting the game";
        }
        private void AIvsAi2Click(object sender, EventArgs e)
        {
            AIvsAI = true;
            humanVshuman = false;
            textBox1.Text = "Press 'Next Move' button for starting the game";
        }

        private void AIvsAI3Click(object sender, EventArgs e)
        {
            AIvsAI = true;
            humanVshuman = false;
            AB = true;
            textBox1.Text = "Press 'Next Move' button for starting the game";
        }

        private void HumanVsHuman(Tuple<int, int> tupleOfIndexes)
        {
            if (!gameWon)
            {
                if (!takeStone)
                {
                    if (gamePhase == GamePhase.opening)
                    {
                        OpeningPhase(tupleOfIndexes);
                        if (counter == 18)
                        {
                            board.NewLabel.Update();
                            gamePhase = GamePhase.midPhase;
                            textBox1.Text = "End of the opening phase";
                            textBox1.Update();
                            System.Threading.Thread.Sleep(3000);
                            textBox1.Text = "White Player Starts";
                        }

                        if (!takeStone)
                        {
                            if ((MinimaxVshuman) || (AlfaBetaVShuman))
                            {
                                AIturn = true;
                            }
                        }
                    }
                    else if ((gamePhase == GamePhase.midPhase) || (gamePhase == GamePhase.finishing))
                    {
                        if ((numberOfBlackStones == 3) && (lastThreeBlack == false) && blackIsPlaying)
                        {
                            textBox1.Text = "Now, black can move on any vacant place";
                            lastThreeBlack = true;
                            gamePhase = GamePhase.finishing;
                            MidGamePhase(tupleOfIndexes);
                        }
                        else if ((numberOfWhiteStones == 3) && (lastThreeWhite == false) && !blackIsPlaying)
                        {
                            textBox1.Text = "Now, white can move on any vacant place";
                            lastThreeWhite = true;
                            gamePhase = GamePhase.finishing;
                            MidGamePhase(tupleOfIndexes);

                        }
                        else if (slideStone)
                        {
                            if (board.SlideStone(blackIsPlaying, tupleOfIndexes))
                            {
                                slideStone = false;

                                if (board.IsMill(board.board, board.whiteMills, board.blackMills))
                                {
                                    textBox1.Text = "Mill, take opponent's stone";
                                    takeStone = true;
                                    Decider();
                                }
                                else
                                {
                                    if ((MinimaxVshuman) || (AlfaBetaVShuman))
                                    {
                                        AIturn = true;
                                    }
                                    Decider();
                                    blackIsPlaying = !blackIsPlaying;
                                    if (blackIsPlaying) { textBox1.Text = "Black Player"; }
                                    else { textBox1.Text = "White Player"; }
                                }

                            }
                        }
                        else
                        {
                            MidGamePhase(tupleOfIndexes);
                        }
                    }
                }
                else
                {
                    if (board.TakeStoneFromBoard(blackIsPlaying, tupleOfIndexes))
                    {
                        if (!gameWon)
                        {
                            takeStone = false;
                            blackIsPlaying = !blackIsPlaying;

                            if ((MinimaxVshuman) || (AlfaBetaVShuman))
                            {
                                AIturn = true;
                            }

                            if (blackIsPlaying)
                            {
                                textBox1.Text = "Black Player";
                            }
                            else
                            {
                                textBox1.Text = "White Player";
                            }
                        }
                        else
                        {
                            GameWon(blackIsPlaying);
                        }
                    }
                }

            }
        }

        private void AIplay(bool miniMax)
        {
            if (!gameWon)
            {
                if (AIvsAI)
                {
                    if(miniMax)
                    {
                        if(playedMoves1 == 6)
                        {
                            playedMoves1 = 0;
                            if(Repeating(firstpreviousMoveResults))
                            {
                                AIRandomMove1 = true; 
                            }
                        }
                        else if(playedMoves2 == 6)
                        {
                            playedMoves2 = 0;
                            if (Repeating(secondpreviousMoveResults))
                            {
                                AIRandomMove2 = true; ;
                            }
                        }
                        if (blackIsPlaying)
                        {
                            MinimaxAI minimax = new MinimaxAI(new PiecesCountGameEvaluation());
                            if (AIRandomMove1)
                            {
                                Move moveResult = minimax.AIRandomMove(board, blackIsPlaying);
                                AIturnToPlay(moveResult);
                                AIRandomMove1 = false;
                            }
                            else
                            {
                                Move moveResult = minimax.AIMinimaxMove(board, blackIsPlaying);
                                firstpreviousMoveResults[playedMoves1] = moveResult;
                                AIturnToPlay(moveResult);
                                playedMoves1++;
                            }
                        }
                        else
                        {
                            AlfaBetaAI alfaBeta = new AlfaBetaAI(new PiecesCountGameEvaluation());
                            if (AIRandomMove2)
                            {
                                Move moveResult = alfaBeta.AIRandomMove(board, blackIsPlaying);
                                AIturnToPlay(moveResult);
                                AIRandomMove2 = false;
                            }
                            else
                            {
                                Move moveResult = alfaBeta.AIAlfaBetaMove(board, blackIsPlaying);
                                secondpreviousMoveResults[playedMoves2] = moveResult;
                                AIturnToPlay(moveResult);
                                playedMoves2++;
                            }
                        }
                    }
                    else
                    {
                        if (AB)
                        {
                            AlfaBetaAI alfaBeta = new AlfaBetaAI(new PiecesCountGameEvaluation());
                            Move moveResult = alfaBeta.AIAlfaBetaMove(board, blackIsPlaying);
                            AIturnToPlay(moveResult);
                        }
                        else
                        {
                            MinimaxAI minimax = new MinimaxAI(new PiecesCountGameEvaluation());
                            Move moveResult = minimax.AIMinimaxMove(board, blackIsPlaying);
                            AIturnToPlay(moveResult);
                        }
                    }
                }
                else
                {
                    if (miniMax)
                    {
                        MinimaxAI minimax = new MinimaxAI(new PiecesCountGameEvaluation());
                        Move moveResult = minimax.AIMinimaxMove(board, blackIsPlaying);
                        AIturnToPlay(moveResult);
                    }
                    else if (miniMax == false)
                    {
                        AlfaBetaAI alfaBeta = new AlfaBetaAI(new PiecesCountGameEvaluation());
                        Move moveResult = alfaBeta.AIAlfaBetaMove(board, blackIsPlaying);
                        AIturnToPlay(moveResult);
                    }
                }
            }
            else
            {
                GameWon(blackIsPlaying);
            }
        }

        private void AIturnToPlay(Move moveResult)
        {
            if (gamePhase == GamePhase.opening)
            {
                string labelName = Linking.GetLabelName(moveResult.To);
                Label label = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                board.NewLabel = label;

                OpeningPhase(moveResult.To);
                label.Update();

                if (counter == 18)
                {
                    board.NewLabel.Update();
                    gamePhase = GamePhase.midPhase;
                    textBox1.Text = "End of the opening phase";
                    textBox1.Update();
                    System.Threading.Thread.Sleep(3000);
                    textBox1.Text = "White Player Starts";
                }

                if (takeStone == false)
                {
                    if ((MinimaxVshuman) || (AlfaBetaVShuman))
                    {
                        AIturn = false;
                    }
                }
                else
                {
                    AITakeStone();
                    AIturn = false;
                }
            }
            else if ((gamePhase == GamePhase.midPhase) || (gamePhase == GamePhase.finishing))
            {
                string labelName = Linking.GetLabelName(moveResult.From);
                Label label = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                board.NewLabel = label;

                if ((numberOfBlackStones == 3) && (lastThreeBlack == false) && blackIsPlaying)
                {
                    lastThreeBlack = true;
                    gamePhase = GamePhase.finishing;
                    MidGamePhase(moveResult.From);
                }
                else if ((numberOfWhiteStones == 3) && (lastThreeWhite == false) && !blackIsPlaying)
                {
                    lastThreeWhite = true;
                    gamePhase = GamePhase.finishing;
                    MidGamePhase(moveResult.From);
                }
                else
                {
                    MidGamePhase(moveResult.From);
                }

                if (slideStone)
                {
                    labelName = Linking.GetLabelName(moveResult.To);
                    label = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                    board.NewLabel = label;
                    slideStone = false;
                    board.SlideStone(blackIsPlaying, moveResult.To);
                }

                if (board.IsMill(board.board, board.whiteMills, board.blackMills))
                {
                    textBox1.Text = "Mill, take opponent's stone";
                    AITakeStone();
                    Decider();
                    AIturn = false;
                }
                else
                {
                    Decider();
                    AIturn = false;
                    blackIsPlaying = !blackIsPlaying;
                    if (blackIsPlaying) { textBox1.Text = "Black Player"; }
                    else { textBox1.Text = "White Player"; }
                }
            }
        }

        private bool Repeating(Move[] previousMoves)
        {
            short counterOfSameMoves = 0;
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i != j)
                    {
                        if(((previousMoves[j].From.Item1 == previousMoves[i].From.Item1) && (previousMoves[j].To.Item1 == previousMoves[i].To.Item1) && 
                            (previousMoves[j].From.Item2 == previousMoves[i].From.Item2) && (previousMoves[j].To.Item2 == previousMoves[i].To.Item2))
                          || ((previousMoves[j].From.Item1 == previousMoves[i].To.Item1) && (previousMoves[j].To.Item1 == previousMoves[i].From.Item1) && 
                          (previousMoves[j].From.Item2 == previousMoves[i].To.Item2) && (previousMoves[j].To.Item2 == previousMoves[i].From.Item2)))
                        {
                            counterOfSameMoves++;
                        }
                    }
                }
            }
            if (counterOfSameMoves >= 2)
            {
                return true;
            }

            return false;
        }
        private void AITakeStone()
            {
                Tuple<int, int> indexes = takeStoneHeuristic.ChooseWhichStone(blackIsPlaying, board.board);
                string labelName = Linking.GetLabelName(indexes);
                Label label = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                board.NewLabel = label;
                board.TakeStoneFromBoard(blackIsPlaying, indexes);
                if (!gameWon)
                {
                    takeStone = false;
                    blackIsPlaying = !blackIsPlaying;

                    if (blackIsPlaying)
                    {
                        textBox1.Text = "Black Player";
                    }
                    else
                    {
                        textBox1.Text = "White Player";
                    }
                }
                else
                {
                    GameWon(blackIsPlaying);
                }

            }
        
    }
}

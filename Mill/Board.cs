using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Mill
{
    class Board
    {
        public enum PlaceOnBoardIs { free, whiteOccupied, blackOccupied, blackMill, whiteMill, movable, notMovable }
        private PlaceOnBoardIs[,] board = new PlaceOnBoardIs[7, 7];
        public void CreateBoard()
        { 
            for (int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    if (i == j) 
                    {
                        board[i, j] = PlaceOnBoardIs.free;
                    }
                    else
                    {
                        board[i, j] = PlaceOnBoardIs.movable;
                    }
                }
            }

            for(int i = 0; i < 7; i++)
            {
                board[i, 3] = PlaceOnBoardIs.free;
                board[3, i] = PlaceOnBoardIs.free;
            }

            board[3, 3] = PlaceOnBoardIs.notMovable;
        }

        private bool ReportMill(int j, int a, int b, int c)
        {
            if ((board[a, j] == PlaceOnBoardIs.whiteOccupied) && (board[b, j] == PlaceOnBoardIs.whiteOccupied)
                            && (board[c, j] == PlaceOnBoardIs.whiteOccupied))
            {
                board[a, j] = PlaceOnBoardIs.whiteMill;
                board[b, j] = PlaceOnBoardIs.whiteMill;
                board[c, j] = PlaceOnBoardIs.whiteMill;
                return true;
            }
            else if ((board[a, j] == PlaceOnBoardIs.blackOccupied) && (board[b, j] == PlaceOnBoardIs.blackOccupied)
                && (board[c, j] == PlaceOnBoardIs.blackOccupied))
            {
                board[a, j] = PlaceOnBoardIs.blackMill;
                board[b, j] = PlaceOnBoardIs.blackMill;
                board[c, j] = PlaceOnBoardIs.blackMill;
                return true;
            }

            if ((board[j, a] == PlaceOnBoardIs.whiteOccupied) && (board[j, b] == PlaceOnBoardIs.whiteOccupied)
               && (board[j, c] == PlaceOnBoardIs.whiteOccupied))
            {
                board[j, a] = PlaceOnBoardIs.whiteMill;
                board[j, b] = PlaceOnBoardIs.whiteMill;
                board[j, c] = PlaceOnBoardIs.whiteMill;
                return true;
            }
            else if ((board[j, a] == PlaceOnBoardIs.blackOccupied) && (board[j, b] == PlaceOnBoardIs.blackOccupied)
               && (board[j, c] == PlaceOnBoardIs.blackOccupied))
            {
                board[j, a] = PlaceOnBoardIs.blackMill;
                board[j, b] = PlaceOnBoardIs.blackMill;
                board[j, c] = PlaceOnBoardIs.blackMill;
                return true;
            }

            return false;
        }

        public bool IsMill()
        {
           for (int j = 0; j < 7; j++ )
           {
                switch(j)
                {
                    case 0:
                    case 6:
                        if (ReportMill(j, 0, 3, 6))
                        {
                            return true;
                        }
                        break;

                    case 1:
                    case 5:
                        if (ReportMill(j, 1, 3, 5))
                        {
                            return true;
                        }
                        break;
                    case 2:
                    case 4:
                        if (ReportMill(j, 2, 3, 4))
                        {
                            return true;
                        }
                        break;
                    case 3:
                        if (ReportMill (j, 0, 1, 2))
                        {
                            return true;
                        }
                        else if (ReportMill(j, 4, 5, 6))
                        {
                            return true;
                        }
                        break;
                }
           }
            return false;
        }

        public void PutStoneOnBoard(bool blackIsPlaying, Label label)
        {

            if (blackIsPlaying == true)
            {

                label.Image = global::Mill.Properties.Resources.black;
                Form1.textBox1.Text = "White Player";
                
            }
            else
            {
                label.Image = global::Mill.Properties.Resources.white;
                Form1.textBox1.Text = "Black Player";
              
            }



            string labelName = label.Name;

        }

  
    }
}

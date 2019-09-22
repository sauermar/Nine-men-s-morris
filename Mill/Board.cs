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
        public enum PlaceOnBoardIs { free, whiteOccupied, blackOccupied, movable, notMovable }
        private PlaceOnBoardIs[,] board = new PlaceOnBoardIs[7, 7];
        private Mill[] whiteMills = new Mill[4];
        private Mill[] blackMills = new Mill[4];
        public void CreateBoard()
        { 
            for (int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    if ((i == j) || (i + j == 6))
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

            //for security inicializing arrays of Mill type to null
            for(int i = 0; i < 4; i++)
            {
                whiteMills[i] = null;
                blackMills[i] = null;
            }
        }

        private bool ReportMill(int j, int a, int b, int c)
        {

            if ((board[a, j] == PlaceOnBoardIs.whiteOccupied) && (board[b, j] == PlaceOnBoardIs.whiteOccupied)
                            && (board[c, j] == PlaceOnBoardIs.whiteOccupied))
            {
                //creates the mill always
                Mill mill = new Mill(a, j, b, j, c, j, false);
                if (MillLogic(whiteMills, mill))
                {
                    return true;
                }
                
            }
            else if ((board[a, j] == PlaceOnBoardIs.blackOccupied) && (board[b, j] == PlaceOnBoardIs.blackOccupied)
                && (board[c, j] == PlaceOnBoardIs.blackOccupied))
                 {
                    Mill mill = new Mill(a, j, b, j, c, j, true);
                    if (MillLogic(blackMills, mill))
                    {
                        return true;
                    }
                 }

            if ((board[j, a] == PlaceOnBoardIs.whiteOccupied) && (board[j, b] == PlaceOnBoardIs.whiteOccupied)
               && (board[j, c] == PlaceOnBoardIs.whiteOccupied))
            {
                Mill mill = new Mill(j, a, j, b, j, c, false);
                if (MillLogic(whiteMills, mill))
                {
                    return true;
                }
            }
            else if ((board[j, a] == PlaceOnBoardIs.blackOccupied) && (board[j, b] == PlaceOnBoardIs.blackOccupied)
               && (board[j, c] == PlaceOnBoardIs.blackOccupied))
                 {
                    Mill mill = new Mill(j, a, j, b, j, c, true);
                    if (MillLogic(blackMills, mill))
                    {
                        return true;
                    }
                 }
            return false;
        }

        //method avoids repeating code in ReportMill method
        private bool MillLogic(Mill[] mills, Mill mill)
        {
            bool millAlreadyExist = false;

            //controles if the mill already exists
            for (int i = 0; i < 4; i++)
            {
                if (mills[i] != null)
                {
                    if (Mill.Equal(mills[i], mill))
                    {
                        millAlreadyExist = true;
                        break;
                    }
                }
            }
            //if not adds him to the array of mills and returns true for detecting a mill 
            if (!millAlreadyExist)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (mills[k] == null)
                    {
                        mills[k] = mill;
                        break;
                    }
                }
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

        public bool PutStoneOnBoard(bool blackIsPlaying, Label label) 
        {
            string labelName = label.Name;
            short index = GetIndexOfStone(labelName);
            Tuple<int, int> tupleOfIndexes = Linking.GetIndexesOnBoard(index);

            if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == PlaceOnBoardIs.free)
            {

                if (blackIsPlaying == true)
                {

                    label.Image = global::Mill.Properties.Resources.black;
                    Form1.numberOfBlackStones++;
                    board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] = PlaceOnBoardIs.blackOccupied;
                    if (Form1.counter < 17)
                    {
                        Form1.textBox1.Text = "White Player";
                    }

                }
                else
                {
                    label.Image = global::Mill.Properties.Resources.white;
                    Form1.numberOfWhiteStones++;
                    board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] = PlaceOnBoardIs.whiteOccupied;
                    Form1.textBox1.Text = "Black Player";

                }
                return true;
            }
            return false;
        }
        private short GetIndexOfStone(string name)
        {
            string number = new String(name.Where(Char.IsDigit).ToArray());
            short num = short.Parse(number);
            return num;
        }

        public bool TakeStoneFromBoard(bool blackIsPlaying, Label label)
        {
            string labelName = label.Name;
            short index = GetIndexOfStone(labelName);
            Tuple<int, int> tupleOfIndexes = Linking.GetIndexesOnBoard(index);

            if (blackIsPlaying)
            {
                if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == PlaceOnBoardIs.whiteOccupied)
                {
                    label.Image = null;
                    Form1.numberOfWhiteStones--;
                    // delete all existing mills with the chosen stone
                    for(int i = 0; i < 4; i++)
                    {
                        if (whiteMills[i] != null)
                        {
                            if (((tupleOfIndexes.Item1 == whiteMills[i].Stone1.Item1) && (tupleOfIndexes.Item2 == whiteMills[i].Stone1.Item2)) ||
                              ((tupleOfIndexes.Item1 == whiteMills[i].Stone2.Item1) && (tupleOfIndexes.Item2 == whiteMills[i].Stone2.Item2)) ||
                              ((tupleOfIndexes.Item1 == whiteMills[i].Stone3.Item1) && (tupleOfIndexes.Item2 == whiteMills[i].Stone3.Item2)))
                            {
                                whiteMills[i] = null;
                            }
                        }
                    }
                    //set the place of the stone on free
                    board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] = PlaceOnBoardIs.free;
                    //confirm
                    return true;
                }
            }
            else
            {
                if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == PlaceOnBoardIs.blackOccupied)
                {
                    label.Image = null;
                    Form1.numberOfBlackStones--;
                    // delete all existing mills with the chosen stone
                    for (int i = 0; i < 4; i++)
                    {
                        if (blackMills[i] != null)
                        {
                            if (((tupleOfIndexes.Item1 == blackMills[i].Stone1.Item1) && (tupleOfIndexes.Item2 == blackMills[i].Stone1.Item2)) ||
                              ((tupleOfIndexes.Item1 == blackMills[i].Stone2.Item1) && (tupleOfIndexes.Item2 == blackMills[i].Stone2.Item2)) ||
                              ((tupleOfIndexes.Item1 == blackMills[i].Stone3.Item1) && (tupleOfIndexes.Item2 == blackMills[i].Stone3.Item2)))
                            {
                                blackMills[i] = null;
                            }
                        }
                    }
                    //free the chosen place
                    board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] = PlaceOnBoardIs.free;
                    //confirm
                    return true;
                }
            }
            //if the place clicked is free
            return false;
        }

    }
}

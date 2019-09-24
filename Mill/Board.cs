using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Mill
{
    public class Board
    {
        public enum PlaceOnBoardIs { free, whiteOccupied, blackOccupied, movable, notMovable }
        public PlaceOnBoardIs[,] board = new PlaceOnBoardIs[7, 7];
        public Mill[] whiteMills = new Mill[4];
        public Mill[] blackMills = new Mill[4];
        public Label OldLabel;
        public Label NewLabel;
        private Tuple<int, int>[] vacances = new Tuple<int, int>[4];
        public void CreateBoard()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
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

            for (int i = 0; i < 7; i++)
            {
                board[i, 3] = PlaceOnBoardIs.free;
                board[3, i] = PlaceOnBoardIs.free;
            }

            board[3, 3] = PlaceOnBoardIs.notMovable;

            //for security inicializing arrays of Mill type to null
            for (int i = 0; i < 4; i++)
            {
                whiteMills[i] = null;
                blackMills[i] = null;
            }
        }

        private bool ReportMill(int j, int a, int b, int c, PlaceOnBoardIs[,] board, Mill[] whiteMills, Mill[] blackMills)
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

        public bool IsMill(PlaceOnBoardIs[,] board, Mill[] whiteMills, Mill[] blackMills)
        {
            for (int j = 0; j < 7; j++)
            {
                switch (j)
                {
                    case 0:
                    case 6:
                        if (ReportMill(j, 0, 3, 6, board, whiteMills, blackMills))
                        {
                            return true;
                        }
                        break;

                    case 1:
                    case 5:
                        if (ReportMill(j, 1, 3, 5, board, whiteMills, blackMills))
                        {
                            return true;
                        }
                        break;
                    case 2:
                    case 4:
                        if (ReportMill(j, 2, 3, 4, board, whiteMills, blackMills))
                        {
                            return true;
                        }
                        break;
                    case 3: 
                        if (ReportMill(j, 0, 1, 2, board, whiteMills, blackMills))
                        {
                            return true;
                        }
                        else if (ReportMill(j, 4, 5, 6, board, whiteMills, blackMills))
                        {
                            return true;
                        }
                        break;
                }
            }
            return false;
        }

        public bool PutStoneOnBoard(bool blackIsPlaying, Tuple<int,int> tupleOfIndexes)
        {
            if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == PlaceOnBoardIs.free)
            {

                if (blackIsPlaying == true)
                {

                    NewLabel.Image = global::Mill.Properties.Resources.black;
                    board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] = PlaceOnBoardIs.blackOccupied;
                    if (Form1.counter < 17)
                    {
                        Form1.textBox1.Text = "White Player";
                    }

                }
                else
                {
                    NewLabel.Image = global::Mill.Properties.Resources.white;
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

        public bool TakeStoneFromBoard(bool blackIsPlaying, Tuple<int,int> tupleOfIndexes)
        {
            if (blackIsPlaying)
            {
                if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == PlaceOnBoardIs.whiteOccupied)
                {
                    NewLabel.Image = null;
                    Form1.numberOfWhiteStones--;
                    DeleteAllMillsWithStone(tupleOfIndexes.Item1, tupleOfIndexes.Item2, whiteMills);
                    //set the place of the stone on free
                    board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] = PlaceOnBoardIs.free;
                    if (Form1.numberOfWhiteStones < 3)
                    {
                        Form1.gameWon = true;
                    }
                    //confirm
                    return true;
                }
            }
            else
            {
                if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == PlaceOnBoardIs.blackOccupied)
                {
                    NewLabel.Image = null;
                    Form1.numberOfBlackStones--;
                    DeleteAllMillsWithStone(tupleOfIndexes.Item1, tupleOfIndexes.Item2, blackMills);
                    //free the chosen place
                    board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] = PlaceOnBoardIs.free;
                    if (Form1.numberOfBlackStones < 3)
                    {
                        Form1.gameWon = true;
                    }
                    //confirm
                    return true;
                }
            }
            //if the place clicked is free
            return false;
        }

        private void DeleteAllMillsWithStone(int x, int y, Mill[] mills)
        {
            for (int i = 0; i < 4; i++)
            {
                if (mills[i] != null)
                {
                    if (((x == mills[i].Stone1.Item1) && (y == mills[i].Stone1.Item2)) ||
                      ((x == mills[i].Stone2.Item1) && (y == mills[i].Stone2.Item2)) ||
                      ((x == mills[i].Stone3.Item1) && (y == mills[i].Stone3.Item2)))
                    {
                        mills[i] = null;
                    }
                }
            }
        }

        public bool CanStoneBeSlided(bool blackIsPlaying, Tuple<int, int> tupleOfIndexes)
        {
            OldLabel = NewLabel;

            if (blackIsPlaying)
            {
                if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == PlaceOnBoardIs.blackOccupied)
                {
                    vacances = GetAdjacentVacantPositions(tupleOfIndexes.Item1, tupleOfIndexes.Item2, this.board);

                    if ((Form1.gamePhase == Form1.GamePhase.finishing) || IsAnyPositionVacante(vacances))
                    {
                        NewLabel.Image = global::Mill.Properties.Resources.blackchosen;
                        NewLabel.Update();
                        DeleteAllMillsWithStone(tupleOfIndexes.Item1, tupleOfIndexes.Item2, blackMills);
                        board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] = PlaceOnBoardIs.free;
                        return true;
                    }
                    else
                    {
                        Form1.textBox1.Text = "Invalid Option";
                        Form1.textBox1.Update();
                        System.Threading.Thread.Sleep(1500);
                        Form1.textBox1.Text = "Black Player";
                        return false;
                    }

                }
            }
            else
            {
                if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == PlaceOnBoardIs.whiteOccupied)
                {
                    vacances = GetAdjacentVacantPositions(tupleOfIndexes.Item1, tupleOfIndexes.Item2, this.board);

                    if ((Form1.gamePhase == Form1.GamePhase.finishing) || IsAnyPositionVacante(vacances))
                    {
                        NewLabel.Image = Properties.Resources.whitechosen;
                        NewLabel.Update();
                        DeleteAllMillsWithStone(tupleOfIndexes.Item1, tupleOfIndexes.Item2, whiteMills);
                        board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] = PlaceOnBoardIs.free;
                        return true;
                    }
                    else
                    {
                        Form1.textBox1.Text = "Invalid Option";
                        Form1.textBox1.Update();
                        System.Threading.Thread.Sleep(1500);
                        Form1.textBox1.Text = "White Player";
                        return false;
                    }
                }
            }
            return false;
        }

        private Tuple<int, int>[] GetAdjacentVacantPositions(int x, int y, PlaceOnBoardIs[,] board)
        {
            //vacantPositions[0] = left neighbour if any
            //vacantPositions[1] = right neighbour if any
            //vacantPositions[2] = upper neighbour if any
            //vacantPositions[3] = downer neighbour if any
            Tuple<int, int>[] vacantPositions = { new Tuple<int,int>(-1, -1), new Tuple<int, int>(-1, -1),
                                                  new Tuple<int, int>(-1, -1), new Tuple<int, int>(-1, -1) };
            int a;
            //go to left
            if (x > 0)
            {
                a = x - 1;
                do
                {
                    if (board[a, y] == PlaceOnBoardIs.free)
                    {
                        vacantPositions[0] = new Tuple<int, int>(a, y);
                        break;
                    }
                    else if (board[a, y] == PlaceOnBoardIs.movable)
                    {
                        --a;
                    }
                    else
                    {
                        break;
                    }
                } while (a != -1);
            }
            //go to right
            if (x < 6)
            {
                a = x + 1;
                do
                {
                    if (board[a, y] == PlaceOnBoardIs.free)
                    {
                        vacantPositions[1] = new Tuple<int, int>(a, y);
                        break;
                    }
                    else if (board[a, y] == PlaceOnBoardIs.movable)
                    {
                        ++a;
                    }
                    else
                    {
                        break;
                    }
                } while (a != 7);
            }
            //go up
            if (y > 0)
            {
                a = y - 1;
                do
                {
                    if (board[x, a] == PlaceOnBoardIs.free)
                    {
                        vacantPositions[2] = new Tuple<int, int>(x, a);
                        break;
                    }
                    else if (board[x, a] == PlaceOnBoardIs.movable)
                    {
                        --a;
                    }
                    else
                    {
                        break;
                    }
                } while (a != -1);
            }
            //go down
            if (y < 6)
            {
                a = y + 1;
                do
                {
                    if (board[x, a] == PlaceOnBoardIs.free)
                    {
                        vacantPositions[3] = new Tuple<int, int>(x, a);
                        break;
                    }
                    else if (board[x, a] == PlaceOnBoardIs.movable)
                    {
                        ++a;
                    }
                    else
                    {
                        break;
                    }
                } while (a != 7);
            }

            return vacantPositions;
        }

        private bool IsAnyPositionVacante(Tuple<int, int>[] vacantPositions)
        {
            for (int i = 0; i < 4; i++)
            {
                if (vacantPositions[i].Item1 != -1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool SlideStone(bool blackIsPlaying, Tuple<int,int> tupleOfIndexes)
        {
            bool validPlace = false;

            if (Form1.gamePhase == Form1.GamePhase.finishing)
            {
                if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == PlaceOnBoardIs.free)
                {
                    validPlace = true;
                }
            }
            else
            {

                for (int i = 0; i < 4; i++)
                {
                    if (vacances[i].Item1 != -1)
                    {
                        if ((vacances[i].Item1 == tupleOfIndexes.Item1) && (vacances[i].Item2 == tupleOfIndexes.Item2))
                        {
                            validPlace = true;
                            break;
                        }
                    }
                }
            }
            
            if (validPlace)
            {
                if (blackIsPlaying)
                {
                    NewLabel.Image = Properties.Resources.black;
                    NewLabel.Update();
                    board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] = PlaceOnBoardIs.blackOccupied;
                    OldLabel.Image = null;
                    OldLabel.Update();
                    return true;
                }
                else
                {
                    NewLabel.Image = Properties.Resources.white;
                    NewLabel.Update();
                    board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] = PlaceOnBoardIs.whiteOccupied;
                    OldLabel.Image = null;
                    OldLabel.Update();
                    return true;
                }
            }
            return false;
        }

        public Tuple<int, int> GetTupleOfIndexes(Label label)
        {
            string labelName = label.Name;
            short index = GetIndexOfStone(labelName);
            return Linking.GetIndexesOnBoard(index);
        }

        public int CountMills(bool blackIsPlaying, PlaceOnBoardIs[,] board)
        {
            int numberOfMills = 0;
            Mill[] mills;
            if (blackIsPlaying)
            {
                mills = blackMills;
            }
            else
            {
                mills = whiteMills;
            }

            for (int i = 0; i < 4; i++)
            {
                if (mills[i] != null)
                {
                    numberOfMills++;
                }
            }

            return numberOfMills;

        }

        public int NumberOfStonesCurrentlyOnBoard(bool blackIsPlaying, PlaceOnBoardIs[,] board)
        {
            int black = 0;
            int white = 0;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board[i, j] == PlaceOnBoardIs.blackOccupied)
                    {
                        black++;
                    }
                    else if (board[i, j] == PlaceOnBoardIs.whiteOccupied)
                    {
                        white++;
                    }
                }
            }

            if (blackIsPlaying)
            {
                return black;
            }
            else
            {
                return white;
            }
        }

        public PlaceOnBoardIs[,] CopyBoard(PlaceOnBoardIs[,] board)
        {
            PlaceOnBoardIs[,] CopiedBoard = new PlaceOnBoardIs[7, 7];

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    CopiedBoard[i, j] = board[i, j];
                }
            }

            return CopiedBoard;
        }

        public Move[] GetIndexesOfPossibleMoves(bool blackIsPLaying, PlaceOnBoardIs[,] board)
        {
            Move[] indexesOfPossibleMoves = new Move[36];
            Tuple<int, int>[] adjacentVacantPositions = new Tuple<int, int>[4];

            if (Form1.gamePhase == Form1.GamePhase.opening)
            {
                for (short i = 0; i < 36; i++)
                {
                    Tuple<int, int> tupleOfINdexes = Linking.GetIndexesOnBoard(i);
                    if (tupleOfINdexes.Item1 != -1)
                    {
                        if (board[tupleOfINdexes.Item1, tupleOfINdexes.Item2] == PlaceOnBoardIs.free)
                        {
                            indexesOfPossibleMoves[i] = new Move(tupleOfINdexes.Item1, tupleOfINdexes.Item2, -1, -1, false, blackIsPLaying);
                        }
                        else
                        {
                            indexesOfPossibleMoves[i] = new Move(-1, -1, -1, -1, false, blackIsPLaying);
                        }
                    }
                    else
                    {
                        indexesOfPossibleMoves[i] = new Move(-1, -1, -1, -1, false, blackIsPLaying);
                    }
                }
            }
            else 
            {
                short helper1 = 0;
                short helper2 = 0;
                if (blackIsPLaying)
                {
                    for (short i = 0; i < 24; i++)
                    {
                        Tuple<int, int> tupleOfINdexes = Linking.GetIndexesOnBoard(i);
                        if (board[tupleOfINdexes.Item1, tupleOfINdexes.Item2] == PlaceOnBoardIs.blackOccupied)
                        {
                            adjacentVacantPositions = GetAdjacentVacantPositions(tupleOfINdexes.Item1, tupleOfINdexes.Item2, board);

                            for (int j = 0; j < 4; j++)
                            {
                                indexesOfPossibleMoves[helper2 * 4 + helper1] = new Move(adjacentVacantPositions[j].Item1,
                                                                                adjacentVacantPositions[j].Item2, tupleOfINdexes.Item1,
                                                                                tupleOfINdexes.Item2, false, blackIsPLaying);
                                helper1++;
                            }
                            helper2++;
                            helper1 = 0;
                        }
                    }
                }
                else
                {
                    for (short i = 0; i < 24; i++)
                    {
                        Tuple<int, int> tupleOfINdexes = Linking.GetIndexesOnBoard(i);
                        if (board[tupleOfINdexes.Item1, tupleOfINdexes.Item2] == PlaceOnBoardIs.whiteOccupied)
                        {
                            adjacentVacantPositions = GetAdjacentVacantPositions(tupleOfINdexes.Item1, tupleOfINdexes.Item2, board);

                            for (int j = 0; j < 4; j++)
                            {
                                indexesOfPossibleMoves[helper2 * 4 + helper1] = new Move(adjacentVacantPositions[j].Item1,
                                                                                adjacentVacantPositions[j].Item2, tupleOfINdexes.Item1,
                                                                                tupleOfINdexes.Item2, false, blackIsPLaying);
                                helper1++;
                            }
                            helper2++;
                            helper1 = 0;
                        }
                    }
                }
            }
             return indexesOfPossibleMoves;
        }
    }
}

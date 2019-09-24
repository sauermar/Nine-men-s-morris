using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mill
{
    class TakeStoneHeuristic
    {
        private readonly Random random = new Random();

        public Tuple<int, int> ChooseWhichStone(bool blackIsPlaying, Board.PlaceOnBoardIs[,] board)
        {
            int counter = 0;
            Tuple<int, int, int, int>[] almostMill = AlmostMill(blackIsPlaying, board);
            Tuple<int, int> tupleOfIndexes;
            short index;
            for (int i = 0; i < 60; i++)
            {
                if(almostMill[i] == null)
                {
                    break;
                }
                else
                {
                    counter++;
                }
            }

            if(counter > 0)
            {
                int num = random.Next(0, counter - 1);
                index = (short)random.Next(0, 1);
                if (index == 0)
                {
                    return tupleOfIndexes = new Tuple<int, int>(almostMill[num].Item1, almostMill[num].Item2);
                }
                else
                {
                    return tupleOfIndexes = new Tuple<int, int>(almostMill[num].Item3, almostMill[num].Item4);
                }
            }
            else
            {
                while(true)
                {
                    index = (short)random.Next(0, 23);
                    tupleOfIndexes = Linking.GetIndexesOnBoard(index);
                    if (!blackIsPlaying)
                    {
                        if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == Board.PlaceOnBoardIs.blackOccupied)
                        {
                            return tupleOfIndexes;
                        }
                    }
                    else
                    {
                        if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == Board.PlaceOnBoardIs.whiteOccupied)
                        {
                            return tupleOfIndexes;
                        }
                    }
                }
            }
             
        }

        private Tuple<int,int, int, int>[] AlmostMill(bool blackIsPlaying, Board.PlaceOnBoardIs[,] board)
        {
            Tuple<int, int, int, int>[] almostMill = new Tuple<int, int, int, int>[60];
            Tuple<int, int>[] OccupiedPositions = new Tuple<int, int>[4];
            Tuple<int, int> tupleOfIndexes;
            int helper = 0;
            if(blackIsPlaying)
            {
                for (short i = 0; i < 24; i++)
                {
                    tupleOfIndexes = Linking.GetIndexesOnBoard(i);
                    if(board[tupleOfIndexes.Item1,tupleOfIndexes.Item2] == Board.PlaceOnBoardIs.whiteOccupied)
                    {
                        OccupiedPositions = GetOccupiedPositions(tupleOfIndexes.Item1, tupleOfIndexes.Item2, 
                            Board.PlaceOnBoardIs.whiteOccupied, board);
                        for(int j = 0; j < 4; j++)
                        {
                            if (OccupiedPositions[j].Item1 != -1)
                            {
                                almostMill[helper] = new Tuple<int, int, int, int>(tupleOfIndexes.Item1, tupleOfIndexes.Item2,
                                                                            OccupiedPositions[j].Item1, OccupiedPositions[j].Item2);
                                helper++;
                            }
                        }
                    }
                }
            }
            else
            {

                for (short i = 0; i < 24; i++)
                {
                    tupleOfIndexes = Linking.GetIndexesOnBoard(i);
                    if (board[tupleOfIndexes.Item1, tupleOfIndexes.Item2] == Board.PlaceOnBoardIs.blackOccupied)
                    {
                        OccupiedPositions = GetOccupiedPositions(tupleOfIndexes.Item1, tupleOfIndexes.Item2,
                            Board.PlaceOnBoardIs.blackOccupied, board);
                        for (int j = 0; j < 4; j++)
                        {
                            if (OccupiedPositions[j].Item1 != -1)
                            {
                                almostMill[helper] = new Tuple<int, int, int, int>(tupleOfIndexes.Item1, tupleOfIndexes.Item2,
                                                                            OccupiedPositions[j].Item1, OccupiedPositions[j].Item2);
                                helper++;
                            }
                        }
                    }
                }

            }
            return almostMill;
        }

        private Tuple<int, int>[] GetOccupiedPositions(int x, int y, Board.PlaceOnBoardIs occupancy, Board.PlaceOnBoardIs[,] board)
        {
            Tuple<int, int>[] OccupiedPositions = { new Tuple<int,int>(-1, -1), new Tuple<int, int>(-1, -1),
                                                  new Tuple<int, int>(-1, -1), new Tuple<int, int>(-1, -1) };
            int a;
            //go to left
            if (x > 0)
            {
                a = x - 1;
                do
                {
                    if (board[a, y] == occupancy)
                    {
                        OccupiedPositions[0] = new Tuple<int, int>(a, y);
                        break;
                    }
                    else if (board[a, y] == Board.PlaceOnBoardIs.movable)
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
                    if (board[a, y] == occupancy)
                    {
                        OccupiedPositions[1] = new Tuple<int, int>(a, y);
                        break;
                    }
                    else if (board[a, y] == Board.PlaceOnBoardIs.movable)
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
                    if (board[x, a] == occupancy)
                    {
                        OccupiedPositions[2] = new Tuple<int, int>(x, a);
                        break;
                    }
                    else if (board[x, a] == Board.PlaceOnBoardIs.movable)
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
                    if (board[x, a] == occupancy)
                    {
                        OccupiedPositions[3] = new Tuple<int, int>(x, a);
                        break;
                    }
                    else if (board[x, a] == Board.PlaceOnBoardIs.movable)
                    {
                        ++a;
                    }
                    else
                    {
                        break;
                    }
                } while (a != 7);
            }

            return OccupiedPositions;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mill.BoardEvaluation;

namespace Mill.AI
{
    class MinimaxAI
    {
        private IBoardEvaluationHeuristic _boardEvaluationHeuristic;
        private const int Depth = 5;
        private TakeStoneHeuristic takestoneHeuristic = new TakeStoneHeuristic();
        private  Mill[] whiteMills = new Mill[4];
        private  Mill[] blackMills = new Mill[4];
        Move nextMaxMove;
        Move nextMinMove;

        public MinimaxAI(IBoardEvaluationHeuristic boardEvaluationHeuristic)
        {
            _boardEvaluationHeuristic = boardEvaluationHeuristic;
        }

        public Move AIMinimaxMove(Board board, bool blackIsPlaying)
        {
            int bestMoveValue = Minimax(board, Depth, blackIsPlaying, board.board );
            Move moveresult;

            if (blackIsPlaying)
            {
                moveresult = nextMinMove;
            }
            else
            {
                moveresult = nextMaxMove;
            }
            return moveresult;
        }

        private int Minimax(Board board, int depth, bool blackIsPlaying, Board.PlaceOnBoardIs[,] currentBoard)
        {
            if (depth == 0)
            {
                int value = _boardEvaluationHeuristic.EvaluateBoardState(board, blackIsPlaying, currentBoard);
                return value;
            }

            if (blackIsPlaying == false)
            {
                int maxEval = Int32.MinValue;
                foreach (Move possibleMove in board.GetIndexesOfPossibleMoves(blackIsPlaying, currentBoard))
                {
                    
                    if ((possibleMove != null) && (possibleMove.To.Item1 != -1))
                    {
                        Board.PlaceOnBoardIs[,] copiedBoard = board.CopyBoard(currentBoard);
                        if (Form1.gamePhase == Form1.GamePhase.opening)
                        {
                            copiedBoard[possibleMove.To.Item1, possibleMove.To.Item2] = Board.PlaceOnBoardIs.whiteOccupied;
                        }
                        else
                        {
                            copiedBoard[possibleMove.To.Item1, possibleMove.To.Item2] = Board.PlaceOnBoardIs.whiteOccupied;
                            copiedBoard[possibleMove.From.Item1, possibleMove.From.Item2] = Board.PlaceOnBoardIs.free;
                        }

                        if (board.IsMill(copiedBoard, this.whiteMills, this.blackMills))
                        {
                            copiedBoard = TakeStone(copiedBoard, blackIsPlaying);
                        }
                        int eval = Minimax(board, depth - 1, !blackIsPlaying, copiedBoard);
                        if (depth == Depth && eval > maxEval)
                        {
                            nextMaxMove = possibleMove;
                        }
                        maxEval = Math.Max(maxEval, eval);
                    }
                }
              return maxEval;
                
            }
            else
            {
                int minEval = Int32.MaxValue;
                foreach (Move possibleMove in board.GetIndexesOfPossibleMoves(blackIsPlaying, currentBoard))
                {
                    
                    if ((possibleMove != null) && (possibleMove.To.Item1 != -1))
                    {
                        Board.PlaceOnBoardIs[,] copiedBoard = board.CopyBoard(currentBoard);
                        if ((possibleMove != null) && (possibleMove.To.Item1 != -1))
                        {
                            if (Form1.gamePhase == Form1.GamePhase.opening)
                            {
                                copiedBoard[possibleMove.To.Item1, possibleMove.To.Item2] = Board.PlaceOnBoardIs.blackOccupied;
                            }
                            else
                            {
                                copiedBoard[possibleMove.To.Item1, possibleMove.To.Item2] = Board.PlaceOnBoardIs.blackOccupied;
                                copiedBoard[possibleMove.From.Item1, possibleMove.From.Item2] = Board.PlaceOnBoardIs.free;
                            }
                        }

                        if (board.IsMill(copiedBoard, this.whiteMills, this.blackMills))
                        {
                            copiedBoard = TakeStone(copiedBoard, blackIsPlaying);
                        }
                        int eval = Minimax(board, depth - 1, !blackIsPlaying, copiedBoard);
                        if (depth == Depth && eval < minEval)
                        {
                            nextMinMove = possibleMove;
                        }
                        minEval = Math.Min(minEval, eval);
                    }
                }
                return minEval;
            }
        }

        private Board.PlaceOnBoardIs[,] TakeStone(Board.PlaceOnBoardIs[,] board, bool blackIsPlaying)
        {
            Tuple<int,int> tupleOfINdexes = takestoneHeuristic.ChooseWhichStone(blackIsPlaying, board);
            board[tupleOfINdexes.Item1, tupleOfINdexes.Item2] = Board.PlaceOnBoardIs.free;
            return board;
        }
    }
}

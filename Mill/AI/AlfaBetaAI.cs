using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mill.BoardEvaluation;

namespace Mill.AI
{
    class AlfaBetaAI
    {
        private IBoardEvaluationHeuristic _boardEvaluationHeuristic;
        private const int Depth = 5;
        private TakeStoneHeuristic takestoneHeuristic = new TakeStoneHeuristic();
        private Mill[] whiteMills = new Mill[4];
        private Mill[] blackMills = new Mill[4];
        Move nextMaxMove;
        Move nextMinMove;
        private readonly Random random = new Random();

        public AlfaBetaAI(IBoardEvaluationHeuristic boardEvaluationHeuristic)
        {
            _boardEvaluationHeuristic = boardEvaluationHeuristic;
        }

        public Move AIAlfaBetaMove(Board board, bool blackIsPlaying)
        {
            int bestMoveValue = AlfaBeta(board, Depth, Int32.MinValue, Int32.MaxValue, blackIsPlaying, board.board);
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

        private int AlfaBeta(Board board, int depth, int alpha, int beta, bool blackIsPlaying, Board.PlaceOnBoardIs[,] currentBoard)
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
                        int eval = AlfaBeta(board, depth - 1, alpha, beta, !blackIsPlaying, copiedBoard);
                        if (depth == Depth && eval > maxEval)
                        {
                            nextMaxMove = possibleMove;
                        }
                        maxEval = Math.Max(maxEval, eval);
                        alpha = Math.Max(alpha, eval);
                        if (beta <= alpha)
                        {
                            break;
                        }
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
                        int eval = AlfaBeta(board, depth - 1, alpha, beta, !blackIsPlaying, copiedBoard);
                        if (depth == Depth && eval < minEval)
                        {
                            nextMinMove = possibleMove;
                        }
                        minEval = Math.Min(minEval, eval);
                        beta = Math.Min(beta, eval);
                        if (beta <= alpha)
                        {
                            break;
                        }
                    }
                }
                return minEval;
            }
        }

        private Board.PlaceOnBoardIs[,] TakeStone(Board.PlaceOnBoardIs[,] board, bool blackIsPlaying)
        {
            Tuple<int, int> tupleOfINdexes = takestoneHeuristic.ChooseWhichStone(blackIsPlaying, board);
            board[tupleOfINdexes.Item1, tupleOfINdexes.Item2] = Board.PlaceOnBoardIs.free;
            return board;
        }
        public Move AIRandomMove(Board board, bool blackIsPlaying)
        {
            bool possibleMoveFound = false;
            Move[] possiblemoves = board.GetIndexesOfPossibleMoves(blackIsPlaying, board.board);
            Move nextMove = null;
            while (!possibleMoveFound)
            {
                int i = random.Next(0, 35);
                if ((possiblemoves[i] != null) && (possiblemoves[i].To.Item1 != -1))
                {
                    possibleMoveFound = true;
                    nextMove = possiblemoves[i];
                }
            }
            return nextMove;
        }
    }
}

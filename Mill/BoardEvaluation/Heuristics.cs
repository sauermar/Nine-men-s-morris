using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mill.BoardEvaluation
{
        public class PiecesCountGameEvaluation : IBoardEvaluationHeuristic
        {
            public int EvaluateBoardState(Board board, bool blackIsPlaying, Board.PlaceOnBoardIs[,] copiedBoard)
            {
                if (blackIsPlaying)
                {
                    return board.NumberOfStonesCurrentlyOnBoard(true, copiedBoard) -
                           board.NumberOfStonesCurrentlyOnBoard(false, copiedBoard);
                }
                else
                {
                     return board.NumberOfStonesCurrentlyOnBoard(false, copiedBoard) -
                        board.NumberOfStonesCurrentlyOnBoard(true, copiedBoard);
                }
            }
        }

        public class MillsCountGameEvaluation : IBoardEvaluationHeuristic
        {
            public int EvaluateBoardState(Board board, bool blackIsPlaying, Board.PlaceOnBoardIs[,] copiedBoard)
            {
                if (!blackIsPlaying)
                {
                    return board.CountMills(blackIsPlaying, copiedBoard) * 10;
                }
                else return board.CountMills(blackIsPlaying, copiedBoard) * (-10);
            }
        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mill.BoardEvaluation
{
    public interface IBoardEvaluationHeuristic
    {
         int EvaluateBoardState(Board board, bool blackIsPlaying, Board.PlaceOnBoardIs[,] copiedBoard);
    }
    
}

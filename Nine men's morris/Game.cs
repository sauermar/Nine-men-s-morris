using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nine_men_s_morris
{
    class Game
    {
        // States of individual playing places on the board (24 in total)
        public enum States { Unoccupied, WhiteOccupied, BlackOccupied };

        /*array of board places and their states as
          6  a6-------d6-------g6            indexes: 21,22,23
             | \      |       / |
          5  |  b5----d5----f5  |            indexes: 18,19,20
             | | \    |     / | |
          4  | |  c4--d4--e4  | |            indexes: 15,16,17
             | |  |        |  | |
          3 a3-b3-c3      e3-f3-g3           indexes: 9,10,11 and 12,13,14    
             | |  |        |  | |
          2  | |  c2--d2--e2  | |            indexes: 6,7,8
             | | /    |     \ | | 
          1  |  b1----d1----f1  |            indexes: 3,4,5
             | /      |       \ |              
          0  a0-------d0-------g0            indexes: 0,1,2
             a  b  c  d   e  f  g 
          */
        private static Tuple<States, string>[] BoardPlaces = {
            Tuple.Create(States.Unoccupied, "a0"), Tuple.Create(States.Unoccupied,"d0"),
            Tuple.Create(States.Unoccupied, "g0"), Tuple.Create(States.Unoccupied,"b1"),
            Tuple.Create(States.Unoccupied, "d1"), Tuple.Create(States.Unoccupied,"f1"),
            Tuple.Create(States.Unoccupied, "c2"), Tuple.Create(States.Unoccupied,"d2"),
            Tuple.Create(States.Unoccupied, "e2"), Tuple.Create(States.Unoccupied,"a3"),
            Tuple.Create(States.Unoccupied, "b3"), Tuple.Create(States.Unoccupied,"c3"),
            Tuple.Create(States.Unoccupied, "e3"), Tuple.Create(States.Unoccupied,"f3"),
            Tuple.Create(States.Unoccupied, "g3"), Tuple.Create(States.Unoccupied,"c4"),
            Tuple.Create(States.Unoccupied, "d4"), Tuple.Create(States.Unoccupied,"e4"),
            Tuple.Create(States.Unoccupied, "b5"), Tuple.Create(States.Unoccupied,"d5"),
            Tuple.Create(States.Unoccupied, "f5"), Tuple.Create(States.Unoccupied,"a6"),
            Tuple.Create(States.Unoccupied, "d6"), Tuple.Create(States.Unoccupied,"g6"),
        };

        //posible mills index combinations (16 in total)
        private static Tuple<int, int, int>[] trinities = {
              Tuple.Create(0, 1, 2), Tuple.Create(3,4,5), Tuple.Create(6,7,8), Tuple.Create(9,10,11), Tuple.Create(12,13,14),
              Tuple.Create(15,16,17), Tuple.Create(18,19,20), Tuple.Create(21,22,23), Tuple.Create(0,9,21), Tuple.Create(3,10,18),
              Tuple.Create(6,11,15), Tuple.Create(1,4,7), Tuple.Create(16,19,22), Tuple.Create(8,12,17), Tuple.Create(5,13,20),
              Tuple.Create(2,14,23)
            };

        public static object This { get; private set; }

        /// <summary>
        /// Static method for usage in diferent game phases, which controls, whether the mill 
        /// was created on the board from array of places (go through all 16 possible mill formations).
        /// </summary>
        /// <returns></returns>
        public static bool MillOccured()
        {
            for (int i = 0; i < trinities.Length; i++)
            {
                if ((BoardPlaces[trinities[i].Item1].Item1 == States.BlackOccupied && BoardPlaces[trinities[i].Item2].Item1 == States.BlackOccupied
                    && BoardPlaces[trinities[i].Item3].Item1 == States.BlackOccupied) || (BoardPlaces[trinities[i].Item1].Item1 == States.WhiteOccupied
                    && BoardPlaces[trinities[i].Item2].Item1 == States.WhiteOccupied && BoardPlaces[trinities[i].Item3].Item1 == States.WhiteOccupied))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Function for operation during the whole game, using classes OpeningPhase.cs,Mid-gamePhase.cs and EndingPhase.cs 
        /// </summary>
        public void StartGame()
        {
            bool black = false;
            OpeningPhase openingPhase = new OpeningPhase();
            for (int i = 0; i < 24; i++)
            {
                BoardPlaces = openingPhase.AllowPlayerPickPlace(BoardPlaces, black);
                black = !black;
                if (i > 4)
                {
                    if (MillOccured())
                    {
                        // Phase where player can remove one stone, if black then, else
                    }
                }
            }
            
        }
        
  
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mill
{
    //class representing a structure of three stones creating a mill
    class Mill
    {
        public Tuple<int, int> Stone1 { get; }
        public Tuple<int, int> Stone2 { get; }
        public Tuple <int,int> Stone3 { get; }
        //true if the  mill is from black stones, false when the mill is from white stones
        public bool black { get; }

        public Mill(int x1, int y1, int x2, int y2, int x3, int y3, bool black)
        {
            Stone1 = new Tuple<int, int>(x1, y1);
            Stone2 = new Tuple<int, int>(x2, y2);
            Stone3 = new Tuple<int, int>(x3, y3);
            this.black = black;
        }

        public static bool Equal(Mill mill1,  Mill mill2)
        {
            if ((mill1.black == mill2.black) && (mill1.Stone1.Item1 == mill2.Stone1.Item1) && 
                (mill1.Stone1.Item2 == mill2.Stone1.Item2) && (mill1.Stone2.Item1 == mill2.Stone2.Item1)
                && (mill1.Stone2.Item2 == mill2.Stone2.Item2) && (mill1.Stone3.Item1 == mill2.Stone3.Item1)
                && (mill1.Stone3.Item2 == mill2.Stone3.Item2))
            {
                return true;
            }
            return false;
        }

    }
}

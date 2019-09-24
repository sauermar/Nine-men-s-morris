using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mill
{
    public class Move
    {
        public Tuple<int, int> To { get; }
        public Tuple<int, int> From { get; set; }
        public bool Human { get; }
        public bool Black { get; }

        public Move(int x1, int y1, int x2, int y2, bool human, bool black)
        {
            To = new Tuple<int, int>(x1, y1);
            From = new Tuple<int, int>(x2, y2);
            Human = human;
            Black = black;
        }
    }
}

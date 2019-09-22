using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mill
{
    // class for linking code logic with form logic, ergo making the code more readable and understandable
    class Linking
    {
        public static Tuple<int, int> GetIndexesOnBoard(short index)
        {
            Tuple<int, int> tupleOfIndexes;
            switch (index)
            {
                case 0:
                    tupleOfIndexes = new Tuple<int, int>(0, 0);
                    break;
                case 1:
                    tupleOfIndexes = new Tuple<int, int>(0, 3);
                    break;
                case 2:
                    tupleOfIndexes = new Tuple<int, int>(0, 6);
                    break;
                case 3:
                    tupleOfIndexes = new Tuple<int, int>(6, 0);
                    break;
                case 4:
                    tupleOfIndexes = new Tuple<int, int>(6, 3);
                    break;
                case 5:
                    tupleOfIndexes = new Tuple<int, int>(6, 6);
                    break;
                case 6:
                    tupleOfIndexes = new Tuple<int, int>(1, 1);
                    break;
                case 7:
                    tupleOfIndexes = new Tuple<int, int>(1, 3);
                    break;
                case 8:
                    tupleOfIndexes = new Tuple<int, int>(1, 5);
                    break;
                case 9:
                    tupleOfIndexes = new Tuple<int, int>(5, 1);
                    break;
                case 10:
                    tupleOfIndexes = new Tuple<int, int>(5, 3);
                    break;
                case 11:
                    tupleOfIndexes = new Tuple<int, int>(5, 5);
                    break;
                case 12:
                    tupleOfIndexes = new Tuple<int, int>(2, 2);
                    break;
                case 13:
                    tupleOfIndexes = new Tuple<int, int>(2, 3);
                    break;
                case 14:
                    tupleOfIndexes = new Tuple<int, int>(2, 4);
                    break;
                case 15:
                    tupleOfIndexes = new Tuple<int, int>(4, 2);
                    break;
                case 16:
                    tupleOfIndexes = new Tuple<int, int>(4, 3);
                    break;
                case 17:
                    tupleOfIndexes = new Tuple<int, int>(4, 4);
                    break;
                case 18:
                    tupleOfIndexes = new Tuple<int, int>(3, 0);
                    break;
                case 19:
                    tupleOfIndexes = new Tuple<int, int>(3, 1);
                    break;
                case 20:
                    tupleOfIndexes = new Tuple<int, int>(3, 2);
                    break;
                case 21:
                    tupleOfIndexes = new Tuple<int, int>(3, 4);
                    break;
                case 22:
                    tupleOfIndexes = new Tuple<int, int>(3, 5);
                    break;
                case 23:
                    tupleOfIndexes = new Tuple<int, int>(3, 6);
                    break;
                default:
                    tupleOfIndexes = new Tuple<int, int>(-1, -1);
                    break;
            }
            return tupleOfIndexes;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7_1
{
    public class FigureComparer<T> : IComparer<T> where T : IFigure
    {
        public int Compare(T x, T y)
        {
            if (x.Area < y.Area)
                return 1;
            else if (x.Area > y.Area)
                return -1;
            else
                return 0;
        }
    }
}

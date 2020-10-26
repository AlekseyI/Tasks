using System.Collections.Generic;

namespace L7_1
{
    public class FigureComparer : IComparer<IFigure>
    {
        public int Compare(IFigure x, IFigure y)
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

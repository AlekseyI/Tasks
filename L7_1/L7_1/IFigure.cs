using System;

namespace L7_1
{
    public interface IFigure : IComparable<IFigure>
    {
        double Area { get; }
    }
}

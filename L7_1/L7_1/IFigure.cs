﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7_1
{
    public interface IFigure : IComparable<IFigure>
    {
        double Area { get; }
    }
}

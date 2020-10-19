using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7_1
{
    public class Triangle : IFigure
    {
        public double C;
        public double H;

        public double Area
        {
            get
            {
                return (C * H) / 2;
            }
        }

        public Triangle() { }

        public Triangle(double c, double h)
        {
            C = c;
            H = h;
        }

        public int CompareTo(IFigure other)
        {
            if (other == null)
            {
                throw new ArgumentException(nameof(other));
            }

            return Area.CompareTo(other.Area);
        }

        public override string ToString()
        {
            return $"{nameof(Triangle)}: C = {C}, H = {H} Area = {Area}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7_1
{
    public class Circle : IFigure
    {
        public double R;

        public Circle() { }

        public Circle(double r)
        {
            R = r;
        }

        public double Area
        {
            get
            {
                return Math.PI * R * R;
            }
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
            return $"{nameof(Circle)}: R = {R}, Area = {Area}";
        }
    }
}

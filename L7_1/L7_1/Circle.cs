using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7_1
{
    public class Circle<T> : IFigure, IComparable<T> where T : IFigure
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

        public int CompareTo(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentException(nameof(obj));
            }

            return Area.CompareTo(obj.Area);
        }

        public override string ToString()
        {
            return $"{nameof(Circle<T>)}: R = {R}, Area = {Area}";
        }
    }
}

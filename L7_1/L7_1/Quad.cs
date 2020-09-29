using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7_1
{
    public class Quad<T> : IFigure, IComparable<T> where T : IFigure
    {
        public double A;
        public double Area
        {
            get
            {
                return A * A;
            }
        }

        public Quad() { }

        public Quad(double a)
        {
            A = a;
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
            return $"{nameof(Quad<T>)}: A = {A}, Area = {Area}";
        }
    }
}

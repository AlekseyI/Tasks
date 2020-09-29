using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7_1
{
    public class Triangle<T> : IFigure, IComparable<T> where T : IFigure
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
            return $"{nameof(Triangle<T>)}: C = {C}, H = {H} Area = {Area}";
        }
    }
}

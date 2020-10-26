using System;

namespace L7_1
{
    public class Quad : IFigure
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

        public override string ToString()
        {
            return $"{nameof(Quad)}: A = {A}, Area = {Area}";
        }

        public int CompareTo(IFigure other)
        {
            if (other == null)
            {
                throw new ArgumentException(nameof(other));
            }

            return Area.CompareTo(other.Area);
        }
    }
}

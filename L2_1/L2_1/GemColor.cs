using System;

namespace L2_1
{
    public class GemColor : ICloneable
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public GemColor(byte r, byte g, byte b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }

        public override string ToString()
        {
            return $"RGB = [{Red}, {Green}, {Blue}]";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}

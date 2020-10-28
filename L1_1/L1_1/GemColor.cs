using System;
using System.CodeDom;

namespace L1_1
{
    public struct GemColor
    {
        public const byte MinColorValue = 0;
        public const byte MaxColorValue = 255;

        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public GemColor(byte r, byte g, byte b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }

        public static GemColor operator +(GemColor gemColor1, GemColor gemColor2)
        {
            if (gemColor1.Equals(gemColor2))
            {
                throw new ArgumentException($"{nameof(gemColor1)} = {nameof(gemColor2)}");
            }

            return OperationOnGemColor(gemColor1, gemColor2, Add);
        }

        public static GemColor operator -(GemColor gemColor1, GemColor gemColor2)
        {
            if (gemColor1.Equals(gemColor2))
            {
                throw new ArgumentException($"{nameof(gemColor1)} = {nameof(gemColor2)}");
            }

            return OperationOnGemColor(gemColor1, gemColor2, Sub);
        }

        private static GemColor OperationOnGemColor(GemColor gemColor1, GemColor gemColor2, Func<byte, byte, byte> operation)
        {
            return new GemColor(operation(gemColor1.Red, gemColor2.Red), operation(gemColor1.Green, gemColor2.Green), operation(gemColor1.Blue, gemColor2.Blue));
        }

        private static byte Add(byte a, byte b)
        {
            int c = a + b;
            if (c > MaxColorValue)
            {
                return MaxColorValue;
            }
            return (byte)c;
        }

        private static byte Sub(byte a, byte b)
        {
            int c = a - b;
            if (c < MinColorValue)
            {
                return MinColorValue;
            }
            return (byte)c;
        }

        public override int GetHashCode()
        {
            return (Red.GetHashCode() + Green.GetHashCode() + Blue.GetHashCode()) << 2;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is GemColor))
            {
                return false;
            }

            var gemColor = (GemColor)obj;
            return Red == gemColor.Red && Green == gemColor.Green && Blue == gemColor.Blue;
        }

        public override string ToString()
        {
            return $"[{nameof(Red)} = {Red}, {nameof(Green)} = {Green}, {nameof(Blue)} = {Blue}]";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace L1_1
{
    public struct GemColor
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

        public static GemColor operator +(GemColor gemColor1, GemColor gemColor2)
        {
            return new GemColor((byte)(gemColor1.Red + gemColor2.Red), (byte)(gemColor1.Green + gemColor2.Green), (byte)(gemColor1.Blue + gemColor2.Blue));
        }

        public static GemColor operator -(GemColor gemColor1, GemColor gemColor2)
        {
            return new GemColor((byte)(gemColor1.Red - gemColor2.Red), (byte)(gemColor1.Green - gemColor2.Green), (byte)(gemColor1.Blue - gemColor2.Blue));
        }
    }
}
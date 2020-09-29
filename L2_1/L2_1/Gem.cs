using System;
using System.Reflection;

namespace L2_1
{
    public struct Gem : ICloneable
    {
        public string Name;
        public int Damage;
        public float RadiusAttack;
        public bool IsMassivelyAttack;
        public GemColor Color;

        public object DeepClone()
        {
            var gem = (Gem)Clone();
            gem.Color = (GemColor)gem.Color.Clone();
            return gem;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
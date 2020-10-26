using System;

namespace L5_1
{
    public class Auto : ICloneable
    {
        public string Name;
        public TypeAuto Type;

        public Auto(string name, TypeAuto type)
        {
            Name = name;
            Type = type;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Type)}: {Type}";
        }
    }
}
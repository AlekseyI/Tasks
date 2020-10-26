using System;

namespace L6_1
{
    public class SomeType
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public bool IsOk { get; set; }
        public DateTime Date { get; set; }

        public SomeType(){ }

        public SomeType(string name, int index, bool isOk, DateTime date)
        {
            Name = name;
            Index = index;
            IsOk = isOk;
            Date = date;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Index)}: {Index}, {nameof(IsOk)}: {IsOk}, {nameof(Date)}: {Date}";
        }
    }
}

using System;

namespace L10_1
{
    public class RepeatObjectException : Exception
    {
        public RepeatObjectException(string message) : base(message) { }
        public RepeatObjectException() : base("Duplicate item detected.") { }
    }
}

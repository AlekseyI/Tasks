using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_1
{
    public class RepeatObjectException : Exception
    {
        public RepeatObjectException(string message) : base(message) { }
        public RepeatObjectException() : base("Duplicate item detected.") { }
    }
}

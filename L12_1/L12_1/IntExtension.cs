using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L12_1
{
    public static class IntExtension
    {
        public static TimeSpan Time(this int time)
        {
            return TimeSpan.FromSeconds(time);
        }
    }
}

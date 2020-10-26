using System;

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

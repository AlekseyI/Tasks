﻿using System;

namespace L12_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Реализовать методы расширения для класса int, для операций над TimeSpan. Например
            // 1.Seconds() = (TimeSpan)00.00.01;

            int seconds = 3600;
            Console.WriteLine(seconds.Time());           
        }
    }
}

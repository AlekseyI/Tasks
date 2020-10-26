using System;
using System.Diagnostics;

namespace L4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Измерить время работы операций упаковки и распаковки

            int a = 10;

            Console.WriteLine("Упаковка");

            Stopwatch timer = new Stopwatch();
            timer.Start();
            object b = a;
            timer.Stop();
           
            TimeSpan time = timer.Elapsed;
            
            Console.WriteLine(time.TotalMilliseconds + " ms");
            Console.WriteLine();
            timer.Reset();


            Console.WriteLine("Распаковка");
            timer.Start();
            int c = (int) b;
            timer.Stop();
            
            time = timer.Elapsed;
            
            Console.WriteLine(time.TotalMilliseconds + " ms");
            timer.Reset();

        }
    }
}

using System;
using System.Diagnostics;
using System.Threading;

namespace L16_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Генерировать и считать среднее арифметическое для массива размером в 10М и 100М элементов.
            // Реализовать 2 варианта, параллельные вычисления и без них, оценить результаты.

            var numbers10M = GenerateNumbers(10000000);
            var numbers100M = GenerateNumbers(100000000);

            FindAvgSync(numbers10M, numbers100M);

            FindAvgParallel(numbers10M, numbers100M);

        }

        private static int[] GenerateNumbers(int count)
        {
            var numbers = new int[count];
            for (int i = 1; i < count; i++)
            {
                numbers[i] = i;
            }
            return numbers;
        }

        private static double Avg(int[] numbers, int start, int end)
        {
            double result = 0;
            for (int i = start; i < end; i++)
            {
                result += numbers[i];
            }
            return result / numbers.Length;
        }

        private static void FindAvgSync(int[] numbers10M, int[] numbers100M)
        {
            FindAndPrintAvgSync(numbers10M);
            FindAndPrintAvgSync(numbers100M);

            Console.WriteLine();
        }

        private static void FindAndPrintAvgSync(int[] numbers)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            var avgSync10M = Avg(numbers, 0, numbers.Length);

            timer.Stop();

            Console.WriteLine($"Sync avg {numbers.Length} = {avgSync10M}, time = {timer.Elapsed.TotalMilliseconds} ms");
        }

        private static void FindAvgParallel(int[] numbers10M, int[] numbers100M)
        {
            FindAndPrintAvgParallel(numbers10M);
            FindAndPrintAvgParallel(numbers100M);

            Console.WriteLine();
        }

        private static void FindAndPrintAvgParallel(int[] numbers)
        {
            Stopwatch timer = new Stopwatch();
            var avgParallel1 = 0d;
            var avgParallel2 = 0d;

            var thread1 = new Thread(() =>
            {
                avgParallel1 = Avg(numbers, 0, numbers.Length / 2);
            });

            var thread2 = new Thread(() =>
            {
                avgParallel2 = Avg(numbers, numbers.Length / 2, numbers.Length);
            });

            timer.Start();

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            timer.Stop();

            Console.WriteLine($"Parallel avg {numbers.Length} = {avgParallel1 + avgParallel2}, time = {timer.Elapsed.TotalMilliseconds} ms");
        }
    }
}

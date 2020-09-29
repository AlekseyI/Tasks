using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L17_1
{
    class Program
    {

        static void Main(string[] args)
        {
            // Реализовать очередь задач которая позволят добавлять задачи на исполнение из разных 
            // потоков одновременно и регулировать кол-во одновременно выполняемых задач.

            using (var tasks = new TaskQueue())
            {
                Console.WriteLine("Запуск 3 рабочих потоков");
                tasks.Start(3);

                Console.WriteLine("Добавление задач в очередь");
                tasks.Add(Task1);
                tasks.Add(Task2);
                tasks.Add(Task3);

                Thread.Sleep(500);
                Console.WriteLine("Задач в очереди = " + tasks.Amount);
                Thread.Sleep(5000);

                ThreadPool.QueueUserWorkItem((arg) =>
                {
                    Console.WriteLine("Добавление задач из другого потока");
                    tasks.Add(Task4);
                    tasks.Add(Task5);
                    tasks.Add(Task6);
                    Console.WriteLine("Задач в очереди = " + tasks.Amount);
                });

                Thread.Sleep(11000);

                Console.WriteLine("Остановка очереди");
                tasks.Stop();
                Console.WriteLine("Задач в очереди = " + tasks.Amount);

            }
        }

        public static void Task1()
        {
            for (int i = 0; i < 5000; i += 1000)
            {
                Console.WriteLine("Задача 1");
                Thread.Sleep(1000);
            }
        }

        public static void Task2()
        {
            while (true)
            {
                Console.WriteLine("Задача 2");
                Thread.Sleep(1000);
            }
        }

        public static void Task3()
        {
            for (int i = 0; i < 5000; i += 1000)
            {
                Console.WriteLine("Задача 3");
                Thread.Sleep(1000);

            }
        }

        public static void Task4()
        {
            for (int i = 0; i < 5000; i += 1000)
            {
                Console.WriteLine("Задача 4");
                Thread.Sleep(1000);

            }
        }

        public static void Task5()
        {
            for (int i = 0; i < 5000; i += 1000)
            {
                Console.WriteLine("Задача 5");
                Thread.Sleep(1000);

            }
        }

        public static void Task6()
        {
            for (int i = 0; i < 5000; i += 1000)
            {
                Console.WriteLine("Задача 6");
                Thread.Sleep(1000);

            }
        }
    }
}

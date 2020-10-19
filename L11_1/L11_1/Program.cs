using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L11_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Реализовать интерфейс INotifyPropertyChanged на произвольном классе продемонстрировать его работу

            ExampleINotifyPropertyChanged();

            // Реализовать очередь которая генерирует событие когда кол-во объектов в ней превышает n и событие когда становится пустой

            //GeneratorQueue(5);

            // Реализовать класс анализирующий поток чисел и если число отличается более чем x процентов выбрасывает событие

            //AnalizeStreamNumbers();
        }

        private static void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var person = (Person)sender;
            Console.WriteLine($"Значение свойства {e.PropertyName} было изменено на {person.GetType().GetProperty(e.PropertyName).GetValue(person)}");
        }

        private static void PropertyChangedQueue(object sender, PropertyChangedEventArgs e)
        {
            var queueEvent = (QueueEvent<int>)sender;
            if (queueEvent.IsMaxCount)
            {
                Console.WriteLine("Превышен максимальный лимит объектов в очереди");
            }
            else if (queueEvent.IsEmpty)
            {
                Console.WriteLine("Очередь пуста");
            }
        }

        private static void PropertyChangedAnalizer(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine(e.PropertyName);
        }

        private static void GeneratorQueue(int maxValue)
        {
            async void StratQueue()
            {
                Console.WriteLine($"Максимальный лимит очереди {maxValue} элементов");

                var queueEvent = new QueueEvent<int>(maxValue);

                var eventHandler = new PropertyChangedEventHandler(PropertyChangedQueue);
                queueEvent.PropertyChanged += eventHandler;

                for (int i = 0; i < maxValue + 2; i++)
                {
                    queueEvent.Enqueue(i);
                    Console.WriteLine($"Добавлен элемент {i} в очередь");
                    await Task.Delay(500);
                }

                Console.WriteLine();

                int count = queueEvent.Count;

                for (int i = count; i > 0; i--)
                {

                    Console.WriteLine($"Элемент {queueEvent.Dequeue()} убран из очереди");
                    await Task.Delay(500);
                }

                queueEvent.PropertyChanged -= eventHandler;
            }

            StratQueue();
            Console.ReadKey();
        }

        private static void ExampleINotifyPropertyChanged()
        {
            var person = new Person();
            var eventHandler = new PropertyChangedEventHandler(PropertyChanged);
            person.PropertyChanged += eventHandler;

            while (true)
            {
                Console.Write("Введите Имя или возраст(exit-выход): ");
                var input = Console.ReadLine();
                
                if (input == "exit")
                {
                    break;
                }

                try
                {
                    person.Age = int.Parse(input);
                }
                catch (FormatException)
                {
                    person.Name = input;
                }
            }

            person.PropertyChanged -= eventHandler;
        }

        private static void AnalizeStreamNumbers()
        {
            var streamNumbers = new double[] { 10, 4, 100, 2, 5, 52, 24, 3, 78 };
            var percentDifferent = 100;

            var analizer = new Analizer(streamNumbers[0], percentDifferent);
            var eventHandler = new PropertyChangedEventHandler(PropertyChangedAnalizer);
            analizer.PropertyChanged += eventHandler;

            foreach (var element in streamNumbers)
            {
                analizer.Analize(element);
            }
           
            analizer.PropertyChanged -= eventHandler;

            Console.ReadKey();
        }
    }
}

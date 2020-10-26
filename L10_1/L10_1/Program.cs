using System;

namespace L10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Реализовать коллекцию которая хранит только уникальные объекты UniqueCollection<T>, при попытке 
            // добавить существующий инстанс, выбрасывает исключение

            var uniqList = new UniqueCollection<string>();

            try
            {
                uniqList.Add("asd");
                uniqList.Add("asd");
            }
            catch (RepeatObjectException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
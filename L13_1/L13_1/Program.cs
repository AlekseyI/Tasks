using System;

namespace L13_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Рефлексия

            Type personType = typeof(Person);
            //Instance
            var person = (Person) Activator.CreateInstance(personType);
            person.Age = 25;
            person.Name = "Ivan";
            Console.WriteLine("Новый экземпляр объекта " + person);

            var person1 = new Person();
            person1.Age = 20;

            // Вызов метода с параметрами по имени
            var method = personType.GetMethod("DifferntAge");
            Console.WriteLine("Результат вызова метода DifferntAge = " + method.Invoke(person, new object[] { person1}));

            // Получение значения из приватного поля
            Console.WriteLine("Значение приватного поля _cash = " + personType.GetField("_cash", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(person));
        }
    }
}

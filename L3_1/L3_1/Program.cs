using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Реализовать класс Person (FirstName, LastName), определить операторы неявного/явного 
            // преобразования к строке, продемонстрировать работу.

            string firstName = "Иван";
            string lastName = "Иванов";
            string firstLastName = firstName + " " + lastName;

            var person1 = new Person { FirstName = firstName, LastName = lastName };
            Console.WriteLine(nameof(person1) + " : " + person1.ToString());

            // Неявное перобразование
            var person2 = person1;
            Console.WriteLine(nameof(person2) + " : " + person2.ToString());

            // Явное перобразование из строки
            var person3 = (Person)firstLastName;
            Console.WriteLine(nameof(person3) + " : " + person3.ToString());

            // Явное перобразование из объекта
            var person4 = (string)person1;
            Console.WriteLine(nameof(person4) + " : " + person4);

            // Не скомпилируется, т.к. сравнение происходит с учетом типом данных, но типы разные
            // Console.WriteLine($"{person1 == firstLastName}");

            // Скомпилируется, т.к. сравнение происходит на уровне базового класса object
            Console.WriteLine($"{person1.Equals(firstLastName)}");
        }
    }
}
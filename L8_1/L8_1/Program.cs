using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Реализовать свой класс Person(ФИО, Дата рождения, Место рождения, Номер паспорта), 
            // переопределить в нём методы. GetHashCode и Equals


            var person1 = new Person
            {
                FirstName = "Иван",
                SurName = "Сидоров",
                Patronymic = "Иванович",
                BirthDate = new DateTime(1990, 1, 1),
                PlaceBirth = "г. Петроваловск",
                PassportId = 1973625923
            };

            var person2 = new Person
            {
                FirstName = "Сергей",
                SurName = "Иванов",
                Patronymic = "Петрович",
                BirthDate = new DateTime(1985, 7, 16),
                PlaceBirth = "г. Камчатка",
                PassportId = 1765940563
            };

            var person3 = (Person)person1.Clone();

            Console.WriteLine(person1.Equals(person2));
            Console.WriteLine(person1 == person2);
            Console.WriteLine();

            Console.WriteLine(person1.Equals(person3));
            Console.WriteLine(person1 == person3);
            Console.WriteLine();

            Console.WriteLine(person2.Equals(person3));
            Console.WriteLine(person2 == person3);
            Console.WriteLine();

            Console.WriteLine(person1.GetHashCode());
            Console.WriteLine(person2.GetHashCode());
            Console.WriteLine(person3.GetHashCode());
        }
    }
}

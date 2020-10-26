using System;
using System.Collections.Generic;

namespace L9_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Реализовать упрощенную версию справочника места работ, где ключом является 
            // класс Person(ФИО, Дата рождения, Место рождения, Номер паспорта), значением -
            // string(текущее место работы).В качестве результата работы должно быть следующее: 
            // Вводим данные о физическом лице: ФИО, Дата рождения, Место рождения, Номер
            // паспорта и нам выдают его текущее место работы, если такой человек существует в
            // нашей базе.


            var persons = new Dictionary<Person, string>(2);

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

            var person3 = new Person
            {
                FirstName = "Евгений",
                SurName = "Иванов",
                Patronymic = "Петрович",
                BirthDate = new DateTime(1985, 7, 16),
                PlaceBirth = "г. Камчатка",
                PassportId = 1765940563
            };

            persons.Add(person1, "Менеджер");

            persons.Add(person2, "Тестировщик");

            var db = new PersonDb(persons);

            Console.WriteLine($"У пользователья с данными {person1} должность " + db.Find(person1));
            Console.WriteLine();
            Console.WriteLine($"У Пользователья с данными {person2} должность " + db.Find(person2));
            Console.WriteLine();

            try
            {
                Console.WriteLine(db.Find(person3));
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
            }

            // Выполнение нескольких операций чтения над List <T> безопасно , но могут возникнуть проблемы, если коллекция будет изменена во время чтения. Чтобы обеспечить безопасность потоков, необходимо заблокировать коллекцию во время операций чтения и записи.

            // В List можно добавлять повторяющиеся элементы

        }
    }
}

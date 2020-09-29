using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // описать произвольный тип со свойствами разных типов (строка, число, дата, bool)
            // генерировать 100 объектов с произвольными значениями
            // сделать выборки с применением операторов
            // where
            // order by
            // group by
            // any, all
            // sum, min, max

            var rand = new Random();
            int count = 100;
            var someTypes = new SomeType[count];

            for (int i = 0; i < count; i++)
            {
                someTypes[i] = new SomeType(GenerateName(rand, 8), i, rand.Next(count) % 2 == 0, RandomDay(rand));
                Console.WriteLine(someTypes[i].ToString());
            }

            Console.WriteLine();

            // Where
            Console.WriteLine("Элементы, где IsOk истина");
            dynamic lst = someTypes.Where((v) => v.IsOk);
            Print<IEnumerable>(lst);

            Console.WriteLine();

            // Order By
            Console.WriteLine("Элементы, где длина Name равна 8 и сортировка по Name");
            lst = someTypes.Where(v => v.Name.Length == 8).OrderBy(t => t.Name);
            Print<IEnumerable>(lst);

            Console.WriteLine();

            // Group By
            Console.WriteLine("Элементы сгруппированы по IsOk с подсчетом их кол-ва");
            lst = someTypes.GroupBy(v => v.IsOk).Select(t => new { IsOk = t.Key, Count = t.Count() });
            Print<IEnumerable>(lst);

            Console.WriteLine();

            // Any
            Console.WriteLine("Проверка на наличие хотя бы одной даты больше заданной");
            DateTime date = new DateTime(2020, 1, 1);
            dynamic result = someTypes.Any(v => v.Date > date);
            Console.WriteLine(result);

            Console.WriteLine();

            // All
            Console.WriteLine("Проверка, чтобы каждое имя было больше или равно 8");
            result = someTypes.All(v => v.Name.Length >= 8);
            Console.WriteLine(result);

            Console.WriteLine();

            // Sum
            Console.WriteLine("Сумма Index");
            result = someTypes.Sum(v => v.Index);
            Console.WriteLine("Сумма = " + result);

            Console.WriteLine();

            // Min
            Console.WriteLine("Минимальная дата");
            result = someTypes.Select(v => v.Date).Min();
            Console.WriteLine("Минимальная дата = " + result);

            Console.WriteLine();

            // Max
            Console.WriteLine("Максимальная дата");
            result = someTypes.Select(v => v.Date).Max();
            Console.WriteLine("Максимальная дата = " + result);
        }

        private static void Print<T>(T elements) where T : IEnumerable
        {
            if (elements == null)
            {
                return;
            }

            foreach (var element in elements)
            {
                Console.WriteLine(element.ToString());
            }
        }

        public static string GenerateName(Random rand, int len)
        {
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[rand.Next(consonants.Length)].ToUpper();
            Name += vowels[rand.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[rand.Next(consonants.Length)];
                b++;
                Name += vowels[rand.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        private static DateTime RandomDay(Random rand)
        {
            var year = rand.Next(1, 10000);
            var month = rand.Next(1, 13);
            var days = rand.Next(1, DateTime.DaysInMonth(year, month) + 1);

            return new DateTime(year, month, days,
                rand.Next(0, 24), rand.Next(0, 60), rand.Next(0, 60), rand.Next(0, 1000));
        }
    }
}

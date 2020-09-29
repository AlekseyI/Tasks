using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace L15_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Выделить числа из текста (1, 1000, 1 000 000, 100.23)

            var input = "(1, 1000, 1 000 000, 100.23)";
            
            var pattern = @"\d+(?:(?:[.]\d+)|(?:\s\d{3})+)?";
            var regFindNumbers = new Regex(pattern, RegexOptions.Compiled);
            var matches = regFindNumbers.Matches(input);

            Console.WriteLine(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
            Console.WriteLine();

            // Выделить параметры из строки запроса (http://ya.ru/api?r=1&x=23)

            input = "http://ya.ru/api?r=1&x=23";
            pattern = @"(?:\?|[&])(\w+)[=](\w+)";
            var regFindParameters = new Regex(pattern, RegexOptions.Compiled);
            matches = regFindParameters.Matches(input);

            Console.WriteLine(input);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Название параметра {match.Groups[1].Value}, значение параметра {match.Groups[2].Value}");
            }
            Console.WriteLine();

            // Удалить из выражения повторяющиеся пробелы, между токенами д.б. 1 пробел

            input = "Hello,   World   !";
            pattern = @"\s+";
            var regRemoveSpaces = new Regex(pattern, RegexOptions.Compiled);
            var result = regRemoveSpaces.Replace(input, " ");
            Console.WriteLine("До " + input);
            Console.WriteLine("После " + result);
            Console.WriteLine();

            // проверить что вводимое число - корректный номер телефона (+373 77767852, 77767852, 0 (777) 67852)

            var numbersPhone = new string[]
            {
                "+373 77767852",
                "+37 77767852",
                "+373 777678521",
                "77767852",
                "7776785",
                "777678521",
                "0 (777) 67852",
                "0 (777) 678521",
                "0 (77) 67852",
                "0 777 67852",
            };
            pattern = @"(?:^[+]\d{3}\s\d{8}$)|(?:^\d\s[(]\d{3}[)]\s\d{5}$)|(?:^\d{8}$)";

            foreach (var numberPhone in numbersPhone)
            {     
                var regValidatePhoneNumber = new Regex(pattern, RegexOptions.Compiled);
                Console.WriteLine($"Номер телефона {numberPhone} {(regValidatePhoneNumber.Match(numberPhone).Success ? "Правильный" : "Не правильный")}");  
            }
        }
    }
}
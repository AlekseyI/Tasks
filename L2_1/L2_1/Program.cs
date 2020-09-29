using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Интерфейс ICloneable, поверхностное и глубокое копирование


            Console.WriteLine("Не глубокое копирование");

            var gem1 = new Gem();
            gem1.Name = "gem1";
            gem1.Color = new GemColor(255, 255, 255);

            Console.WriteLine(gem1.Name);
            Console.WriteLine(gem1.Color);
            Console.WriteLine();

            var gem2 = (Gem) gem1.Clone();
            gem2.Name = "gem2";
            gem2.Color.Red = 0;
            gem2.Color.Green = 0;
            gem2.Color.Blue = 0;

            Console.WriteLine(gem2.Name);
            Console.WriteLine(gem2.Color);
            Console.WriteLine();

            Console.WriteLine(gem1.Name);
            Console.WriteLine(gem1.Color);
            Console.WriteLine();


            Console.WriteLine("Глубокое копирование");

            gem1 = new Gem();
            gem1.Name = "gem1";
            gem1.Color = new GemColor(255, 255, 255);

            Console.WriteLine(gem1.Name);
            Console.WriteLine(gem1.Color);
            Console.WriteLine();

            gem2 = (Gem) gem1.DeepClone();
            gem2.Name = "gem2";
            gem2.Color.Red = 0;
            gem2.Color.Green = 0;
            gem2.Color.Blue = 0;

            Console.WriteLine(gem2.Name);
            Console.WriteLine(gem2.Color);
            Console.WriteLine();

            Console.WriteLine(gem1.Name);
            Console.WriteLine(gem1.Color);
            Console.WriteLine();
        }
    }
}

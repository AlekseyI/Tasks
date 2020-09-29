using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сделать пример множества и его членов, реализовать интерфейс для перечисления.
            // Обойти всех членов при помощи оператора foreach, while


            var autos = new Auto[5]
            {
                new Auto("BMW", TypeAuto.Passenger),
                new Auto("Audi", TypeAuto.Passenger),
                new Auto("Зил", TypeAuto.Cargo),
                new Auto("Краз", TypeAuto.Cargo),
                new Auto("Toyota", TypeAuto.Passenger),
            };

            var parking = new Parking<Auto>(autos);

            Console.WriteLine("Все автомобили на парковке:");

            foreach (var auto in parking)
            {
                Console.WriteLine(auto.ToString());
            }

            Console.WriteLine();

            IEnumerator<Auto> parkingEnum = parking.GetEnumerator();
            while (parkingEnum.MoveNext())
            {
                Console.WriteLine(parkingEnum.Current.ToString());
            }
        }
    }
}
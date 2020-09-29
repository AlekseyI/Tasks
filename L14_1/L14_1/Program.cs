using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace L14_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Реализовать сериализацию объекта с вложенными объектами

            var lstCars = CreateObjects();

            // Json
            var strJsonCars = JsonConvert.SerializeObject(lstCars);

            Console.WriteLine(strJsonCars);
            Console.WriteLine();

            var carsFromJson = JsonConvert.DeserializeObject<List<Car>>(strJsonCars);

            Print(carsFromJson);

            // XML
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<Car>));

            using (FileStream fs = new FileStream("cars.xml", FileMode.Create, FileAccess.Write))
            {
                xmlFormatter.Serialize(fs, lstCars);
            }
            
            Console.WriteLine(File.ReadAllText("cars.xml"));
            Console.WriteLine();

            List<Car> carsFromXml;
            using (FileStream fs = new FileStream("cars.xml", FileMode.Open, FileAccess.Read))
            {
                carsFromXml = (List<Car>)xmlFormatter.Deserialize(fs);
            }

            Print(carsFromXml);

            // Binary
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            
            using(FileStream fs = new FileStream("cars.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fs, lstCars);        
            }

            Console.WriteLine(File.ReadAllText("cars.dat"));
            Console.WriteLine();

            List<Car> carsFromBinary;
            using(FileStream fs = new FileStream("cars.dat", FileMode.Open, FileAccess.Read))
            {
                carsFromBinary = (List<Car>)binaryFormatter.Deserialize(fs);
            }

            Print(carsFromBinary);

            // Сериализация с циклическими связанными объектами выкидывает исключение

        }

        private static void Print(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine();
        }

        private static List<Car> CreateObjects()
        {
            var workShop1 = new Workshop<Car>("A_WorkShop");
            var workShop2 = new Workshop<Car>("B_WorkShop");

            var car1 = new Car("Lada", workShop1);
            var car2 = new Car("Lexus", workShop1);
            var car3 = new Car("BMW", workShop2);
            var car4 = new Car("Mazda", workShop2);

            return new List<Car>()
            {
                car1,
                car2,
                car3,
                car4
            };
        }


        private static List<Car> CreateRefrencesObjects()
        {
            var workShop1 = new Workshop<Car>("A_WorkShop");
            var workShop2 = new Workshop<Car>("B_WorkShop");

            var lstWorkShops = new List<Workshop<Car>>()
            {
                workShop1,
                workShop2
            };

            var car1 = new Car("Lada", workShop1);
            var car2 = new Car("Lexus", workShop1);
            var car3 = new Car("BMW", workShop2);
            var car4 = new Car("Mazda", workShop2);

            workShop1.Cars = new List<Car>()
            {
                car1,
                car2
            };

            workShop2.Cars = new List<Car>()
            {
                car3,
                car4
            };

            return new List<Car>()
            {
                car1,
                car2,
                car3,
                car4
            };
        }
    }
}

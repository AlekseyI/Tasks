using System;

namespace L14_1
{
    [Serializable]
    public class Car
    {
        public string Name { get; set; }
        public Workshop<Car> Workshop { get; set; }

        public Car() { }

        public Car(string name)
        {
            Name = name;
        }

        public Car(string name, Workshop<Car> workShop)
        {
            Name = name;
            Workshop = workShop;
        }
    }
}

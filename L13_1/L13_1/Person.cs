using System;

namespace L13_1
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        private int _cash;

        public Person()
        {
            _cash = new Random().Next(0, 100);
        }

        public int DifferntAge(Person person)
        {
            return Math.Abs(Age - person.Age);
        }

        public override string ToString()
        {
            return $"Name = {Name}, Age = {Age}";
        }
    }
}

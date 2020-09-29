using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_1
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person() { }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static explicit operator Person(string firstLastName)
        {
            string[] splitNames = firstLastName.Split(' ');
            return new Person(splitNames[0], splitNames[1]);
        }

        public static explicit operator string(Person person)
        {
            return $"{person.FirstName} {person.LastName}";
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}

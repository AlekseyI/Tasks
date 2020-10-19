using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_1
{
    public class Person : BasePerson
    {
        public Person() { }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static explicit operator Person(string firstLastName)
        {
            if (firstLastName == null)
            {
                throw new ArgumentNullException(nameof(firstLastName));
            }

            string[] splitNames = firstLastName.Split(' ');

            if (splitNames.Length != 2)
            {
                throw new IndexOutOfRangeException(nameof(firstLastName));
            }

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

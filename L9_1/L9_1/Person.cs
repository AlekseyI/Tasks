using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L9_1
{
    public class Person : ICloneable
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlaceBirth { get; set; }
        public int PassportId { get; set; }

        public Person() { }

        public Person(string firstName, string surName, string patronymic, DateTime birthDate, string placeBirth, int passportId)
        {
            FirstName = firstName;
            SurName = surName;
            Patronymic = patronymic;
            BirthDate = birthDate;
            PlaceBirth = placeBirth;
            PassportId = passportId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Person))
            {
                return false;
            }

            var person = (Person)obj;
            return FirstName == person.FirstName && SurName == person.SurName && Patronymic == person.Patronymic && BirthDate == person.BirthDate && PlaceBirth == person.PlaceBirth && PassportId == person.PassportId;
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Equals(person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.Equals(person2);
        }

        public override int GetHashCode()
        {
            return (FirstName.GetHashCode() + SurName.GetHashCode() + Patronymic.GetHashCode() + BirthDate.GetHashCode() + PlaceBirth.GetHashCode() + PassportId.GetHashCode()) << 2;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"[ {nameof(FirstName)} = {FirstName}, {nameof(SurName)} = {SurName}, {nameof(Patronymic)} = {Patronymic}, {nameof(BirthDate)} = {BirthDate}, {nameof(PlaceBirth)} = {PlaceBirth}, {nameof(PassportId)} = {PassportId} ]";
        }
    }
}

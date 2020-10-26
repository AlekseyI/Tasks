using System.Collections.Generic;

namespace L9_1
{
    public class PersonDb
    {
        private Dictionary<Person, string> _db;

        public PersonDb()
        {
            _db = new Dictionary<Person, string>();
        }

        public PersonDb(Dictionary<Person, string> db)
        {
            _db = db;
        }

        public string Find(Person person)
        {
            try
            {
                return _db[person];
            }
            catch(KeyNotFoundException)
            {
                throw new KeyNotFoundException($"Пользователя с данными: {person} нет в базе");
            }     
        }
    }
}

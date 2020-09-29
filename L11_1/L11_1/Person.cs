using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L11_1
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private int _age;

        public Person() { }

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }


        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Age)));
            }
        }
    }
}

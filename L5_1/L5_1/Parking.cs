using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_1
{
    public class Parking<T> : IEnumerable<T>
    {
        private T[] _elements;

        public Parking(T[] elements)
        {
            _elements = (T[]) elements.Clone();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ParkingEnum<T>(_elements);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
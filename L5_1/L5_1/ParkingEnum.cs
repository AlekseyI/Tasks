using System;
using System.Collections;
using System.Collections.Generic;

namespace L5_1
{
    public class ParkingEnum<T> : IEnumerator<T>
    {

        private T[] _elements;
        private int position = -1;

        public T Current
        {
            get
            {
                try
                {
                    return _elements[position];
                }
                catch(IndexOutOfRangeException e)
                {
                    throw new IndexOutOfRangeException(e.Message);
                }
            }
        }

        object IEnumerator.Current => Current;

        public ParkingEnum(T[] elements)
        {
            _elements = elements;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _elements.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_1
{
    public class UniqueCollection<T>
    {
        private List<T> _elements;

        public T this[int index]
        {
            get
            {
                return _elements[index];
            }
            set
            {
                _elements[index] = value;
            }
        }

        public UniqueCollection(int capacity)
        {
            _elements = new List<T>(capacity);
        }

        public UniqueCollection()
        {
            _elements = new List<T>();
        }

        public void Add(T value)
        {
            foreach (var elem in _elements)
            {
                if (value.GetHashCode() == elem.GetHashCode())
                {
                    throw new RepeatObjectException();
                }
            }
            _elements.Add(value);
        }

        public void Insert(int index, T value)
        {
            _elements.Insert(index, value);
        }

        public bool Remove(T value)
        {
            return _elements.Remove(value);
        }

        public void RemoveAt(int index)
        {
            _elements.RemoveAt(index);
        }

        public void Clear()
        {
            _elements.Clear();
        }
    }
}

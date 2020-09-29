using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L11_1
{
    public class QueueEvent<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Queue<T> _elements;

        private int _maxCountToEvent;

        private bool _isMaxCount;

        private bool _isEmpty;

        public QueueEvent(int maxCountToEvent)
        {
            _elements = new Queue<T>();
            _maxCountToEvent = maxCountToEvent;
        }

        public QueueEvent(Queue<T> elements, int maxCountToEvent)
        {
            _elements = elements;
            _maxCountToEvent = maxCountToEvent;
        }

        public void Enqueue(T value)
        {
            _elements.Enqueue(value);

            if (_elements.Count > _maxCountToEvent)
            {
                IsMaxCount = true;
            }
        }

        public T Dequeue()
        {           
            if (_elements.Count - 1 == 0)
            {
                IsEmpty = true;
            }
            else
            {
                IsEmpty = false;
            }

            if (_elements.Count > _maxCountToEvent)
            {
                IsMaxCount = true;
            }
            else
            {
                IsMaxCount = false;
            }

            return _elements.Dequeue();
        }

        public int Count => _elements.Count;

        public T Peek()
        {
            return _elements.Peek();
        }

        public bool IsMaxCount
        {
            get
            {
                return _isMaxCount;
            }
            private set
            {
                _isMaxCount = value;
                if (_isMaxCount)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsMaxCount)));
                } 
            }
        }
        public bool IsEmpty
        {
            get
            {
                return _isEmpty;
            }
            private set
            {
                _isEmpty = value;
                if (_isEmpty)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEmpty)));
                }
            }
        }
    }
}

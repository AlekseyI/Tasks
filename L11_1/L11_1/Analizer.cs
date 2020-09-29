using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L11_1
{
    public class Analizer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double[] _elements;
        private int _percentDiffernet;
        private Thread _thread;
        public bool IsStop { get; private set; }

        public Analizer(double[] elements, int percentDiffernet)
        {
            _elements = elements;
            _percentDiffernet = percentDiffernet;
        }

        public void Start()
        {
            if (_thread == null)
            {
                IsStop = false;
                _thread = new Thread(
                    () =>
                    {
                    int count = _elements.Length;
                    for (int i = 1; i < count; i++)
                        {
                            double value;
                            if (_elements[0] > _elements[i])
                            {
                                value = (_elements[0] / _elements[i] - 1) * 100;
                            }
                            else
                            {
                                value = (_elements[i] / _elements[0] - 1) * 100;
                            }

                            if (value > _percentDiffernet)
                            {
                                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs($"Значение {_elements[i]} под индексом {i} отличается более чем на {_percentDiffernet} % от значения {_elements[0]}"));
                            }
                        }
                        IsStop = true;
                    });
                _thread.Start();
            }
        }

        public void Stop()
        {
            _thread.Abort();
            _thread = null;
            IsStop = true;
        }

    }
}

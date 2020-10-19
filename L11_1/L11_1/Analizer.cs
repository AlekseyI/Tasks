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

        private double _element;
        private double _percentDiffernet;

        public Analizer(double element, double percentDiffernet)
        {
            _element = element;
            _percentDiffernet = percentDiffernet;
        }

        public void Analize(double nextElement)
        {
            double percent;
            if (_element > nextElement)
            {
                percent = (_element / nextElement - 1) * 100;
            }
            else
            {
                percent = (nextElement / _element - 1) * 100;
            }

            if (percent > _percentDiffernet)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs($"Значение {nextElement} отличается более чем на {_percentDiffernet} % от значения {_element}"));
            }
            _element = nextElement;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L14_1
{
    [Serializable]
    public class Workshop<T>
    {
        public string Name { get; set; }
        public List<T> Cars { get; set; }

        public Workshop()
        {
            Cars = new List<T>();
        }

        public Workshop(string name)
        {
            Name = name;
            Cars = new List<T>();
        }

        public Workshop(string name, List<T> cars)
        {
            Name = name;
            Cars = cars;
        }
    }
}

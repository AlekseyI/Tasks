using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_1
{
    public interface IGem
    {
        string Name { get; set; }
        GemColor Color { get; set; }
        int Damage { get; set; }
        float RadiusAttack { get; set; }
        bool IsMassivelyAttack { get; set; }
    }
}
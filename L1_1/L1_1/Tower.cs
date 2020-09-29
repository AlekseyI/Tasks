using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_1
{
    public class Tower
    {
        public Gem UsingGem { get; set; }

        public Tower(Gem gem)
        {
            UsingGem = gem;
        }

        public void ActivateGem(bool isEnemyInRadius)
        {
            UsingGem.Attack(isEnemyInRadius);
        }
    }
}

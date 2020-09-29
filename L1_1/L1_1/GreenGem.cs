using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_1
{
    public class GreenGem : Gem
    {
        public GemAbility Ability { get; set; }
        public override byte ChanceAbility { get; set; }
        public override int FireRateDelay { get; set; }

        public GreenGem(string name)
        {
            Name = name;
            Color = new GemColor(0, 255, 0);
            Ability = GemAbility.DecreasedHealed;
            ChanceAbility = 40;
            Damage = 11;
            RadiusAttack = 1f;
            FireRateDelay = 1400;
            IsMassivelyAttack = false;
        }

        public override GemAbility SpecialAbility()
        {
            return Ability;
        }
    }
}
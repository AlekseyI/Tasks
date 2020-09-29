using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_1
{
    public class RedGem : Gem
    {
        public GemAbility Ability { get; set; }
        public override byte ChanceAbility { get; set; }
        public override int FireRateDelay { get; set; }

        public RedGem(string name)
        {
            Name = name;
            Color = new GemColor(255, 0, 0);
            Ability = GemAbility.DecreasedHealth;
            ChanceAbility = 20;
            Damage = 12;
            RadiusAttack = 1f;
            FireRateDelay = 1450;
            IsMassivelyAttack = true;
        }

        public override GemAbility SpecialAbility()
        {
            // По идее здесь можно реализовать логику, если Gem был соединен с Gem-ом другого цвета
            // и получил две способности например замедлять и уменьшать защиту
            return Ability;
        }
    }
}

using System;
using System.Threading.Tasks;

namespace L1_1
{
    public abstract class Gem : IGem
    {
        public GemColor Color { get; set; }
        public int Damage { get; set; }
        public float RadiusAttack { get; set; }
        public bool IsMassivelyAttack { get; set; }
        public string Name { get; set; }
        public abstract byte ChanceAbility { get; set; }
        public abstract int FireRateDelay { get; set; }

        private void UseAbility()
        {
            if (ChanceAbility > 100)
            {
                ChanceAbility = 99;
            }

            Random rnd = new Random();
            byte rndValue = (byte)rnd.Next(0, 100);

            if (rndValue <= ChanceAbility)
            {
                Console.WriteLine($"Gem {Name} накладывает эффект: {SpecialAbility()}");
            }
        }

        public async void Attack(bool isEnemyInRadius)
        {
            while(isEnemyInRadius)
            {
                Console.WriteLine($"Gem {Name} атакует моба");
                UseAbility();
                await Task.Delay(FireRateDelay);
            }
        }

        public abstract GemAbility SpecialAbility();
    }
}

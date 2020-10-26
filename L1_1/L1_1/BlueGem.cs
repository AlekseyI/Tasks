namespace L1_1
{
    public class BlueGem : Gem
    {
        public GemAbility Ability { get; set; }
        public override byte ChanceAbility { get; set; }
        public override int FireRateDelay { get; set; }

        public BlueGem(string name)
        {
            Name = name;
            Color = new GemColor(0, 0, 255);
            Ability = GemAbility.DecreasedSpeed;
            ChanceAbility = 45;
            Damage = 10;
            RadiusAttack = 1f;
            FireRateDelay = 1500;
            IsMassivelyAttack = false;
        }

        public override GemAbility SpecialAbility()
        {
            return Ability;
        }
    }
}

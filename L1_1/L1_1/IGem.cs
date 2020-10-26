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
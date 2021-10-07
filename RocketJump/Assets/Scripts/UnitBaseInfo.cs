public abstract class UnitBaseInfo
{
    public enum EUnitType
    {
        None = 0,
        Player,
        Friend,
        Enemy,
        NPC
    }

    public abstract EUnitType type { get; set; }
    public abstract string name { get; set; }
    public abstract float moveSpeed { get; set; }
}
using UnityEngine;

public abstract class UnitBaseInfo : MonoBehaviour
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
    public abstract string unitName { get; set; }
    public abstract float moveSpeed { get; set; }
}
using UnityEngine;

public abstract class UnitBase : MonoBehaviour
{
    public enum EUnitType
    {
        None,
        Friendly,
        Enemy,
        NPC
    }

    private EUnitType type = EUnitType.None;
    private bool isInvincible = false;
    private bool hasHP = false;
    private bool hasSkill = false;
    private bool hasEnemy = false;

    public void SetType(EUnitType type)
    {
        this.type = type;
    }

    public void SetInvincible(bool isInvincible)
    {
        this.isInvincible = isInvincible;
    }

    public void SetHP(bool hasHP)
    {
        this.hasHP = hasHP;
    }

    public void SetSkill(bool hasSkill)
    {
        this.hasSkill = hasSkill;
    }

    public void SetEnemy(bool hasEnemy)
    {
        this.hasEnemy = hasEnemy;
    }

    public abstract void Initialize(UnitBase baseInfo);

    public abstract void Initialize(EUnitType type = EUnitType.None, bool isInvincible = false, bool hasHP = false, bool hasSkill = false, bool hasEnemy = false);
}
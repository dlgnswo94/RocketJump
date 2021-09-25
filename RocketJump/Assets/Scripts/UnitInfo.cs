using UnityEngine;

public abstract class UnitInfo : UnitBase
{
    private UnitBase info;

    public override void Initialize(UnitBase baseInfo = null)
    {
        if (info == null)
            return;

        info = baseInfo; 
    }

    public override void Initialize(EUnitType type = EUnitType.None, bool isInvincible = false, bool hasHP = false, bool hasSkill = false, bool hasEnemy = false)
    {
        info.SetType(type);
        info.SetInvincible(isInvincible);
        info.SetHP(hasHP);
        info.SetSkill(hasSkill);
        info.SetEnemy(hasEnemy);
    }

    public UnitBase GetUnitBase()
    {
        if (info == null)
            return null;

        return info;
    }
}
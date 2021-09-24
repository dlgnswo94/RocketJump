using UnityEngine;

public class Unit : UnitBase
{
    private Info info;

    protected override void Initialize(Info info = null)
    {
        if (info == null)
            return;

        this.info = info; 
    }

    protected override void Initialize(EType type = EType.None, bool isInvincible = false, bool hasHP = false, bool hasSkill = false, bool hasEnemy = false)
    {
        info.SetType(type);
        info.SetInvincible(isInvincible);
        info.SetHP(hasHP);
        info.SetSkill(hasSkill);
        info.SetEnemy(hasEnemy);
    }
}
using UnityEngine;
using System.Collections.Generic;

public class UnitInstance : UnitBase
{
    public override EUnitType type { get; set; }
    public override string unitName { get; set; }
    public override float moveSpeed { get; set; }
    public override IUnitHP.UnitHP hp { get; set; }
    public override IUnitSkill.Skills skillList { get; set; }

    public UnitInstance(EUnitType type = EUnitType.None, string name = "Please give a name.", float moveSpeed = 0f, int hp = 1)
    {
        this.type = type;
        unitName = name;
        this.moveSpeed = moveSpeed;
        this.hp = new IUnitHP.UnitHP(hp);
        skillList = new IUnitSkill.Skills();
    }
}
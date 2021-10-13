using System;
using System.Collections;
using System.Collections.Generic;

public abstract class UnitBase : UnitBaseInfo, IUnitHP, IUnitSkill, IUnitCrowdControl
{
    public abstract override EUnitType type { get; set; }
    public abstract override string unitName { get; set; }
    public abstract override float moveSpeed { get; set; }
    public abstract IUnitHP.UnitHP hp { get; set; }
    public abstract IUnitSkill.Skills skillList { get; set; }
    public IUnitCrowdControl.CrowdControlAffected crowdControlAffected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class UnitBase : UnitBaseInfo, IUnitHP, IUnitSkill, IUnitCrowdControl
{
    public abstract override EUnitType type { get; set; }
    public abstract override string name { get; set; }
    public abstract override float moveSpeed { get; set; }
    public abstract IUnitHP.UnitHP hp { get; set; }
    public abstract Dictionary<IUnitSkill.ESkillNumber, IUnitSkill.SkillSet> skills { get; set; }
    public abstract IUnitCrowdControl.CrowdControlAffectedDuration crowdControlAffectedDuration { get; set; }
}
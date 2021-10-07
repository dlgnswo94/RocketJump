using UnityEngine;
using System.Collections.Generic;

public class UnitInstance : UnitBase
{
    public override EUnitType type { get; set; }
    public override string name { get; set; }
    public override float moveSpeed { get; set; }
    public override IUnitHP.UnitHP hp { get; set; }
    public override Dictionary<IUnitSkill.ESkillNumber, IUnitSkill.SkillSet> skills { get; set; }
    public override IUnitCrowdControl.CrowdControlAffectedDuration crowdControlAffectedDuration { get; set; }

    public UnitInstance(EUnitType type = EUnitType.None, string name = "Please give a name.", float moveSpeed = 0f, int hp = 0)
    {
        this.type = type;
        this.name = name;
        this.moveSpeed = moveSpeed;
        this.hp = new IUnitHP.UnitHP(hp);
        skills = new Dictionary<IUnitSkill.ESkillNumber, IUnitSkill.SkillSet>();
        crowdControlAffectedDuration = new IUnitCrowdControl.CrowdControlAffectedDuration();
    }

    public void AddSkill(string name, int damage, float coolTime)
    {
        if (skills == null)
        {
            Debug.LogError("스킬을 지정할 공간이 없습니다! 초기화가 제대로 이루어졌는지 확인!");
            return;
        }

        IUnitSkill.SkillSet newSkill = new IUnitSkill.SkillSet(name, damage, coolTime);

        if (newSkill == null)
        {
            Debug.LogError("새 스킬을 등록할 수 없습니다!");
            return;
        }

        IUnitSkill.ESkillNumber skillCount = (IUnitSkill.ESkillNumber)skills.Count + 1;

        if (skillCount == IUnitSkill.ESkillNumber.MAX)
        {
            Debug.LogWarning("스킬을 더 이상 등록할 수 없습니다! 스킬은 최대 16개까지 등록할 수 있습니다.");
            return;
        }

        skills.Add(skillCount, newSkill);
    }

    public bool IsContainsKey(IUnitSkill.ESkillNumber number)
    {
        if (skills == null)
            return false;

        return skills.ContainsKey(number);
    }

    public bool IsContainsValue(IUnitSkill.SkillSet skillSet)
    {
        if (skills == null)
            return false;

        return skills.ContainsValue(skillSet);
    }

    public IUnitSkill.SkillSet FindSkillSetWithSkillName(string name)
    {
        if (skills == null)
            return null;

        for (int i = 0; i < skills.Count; i++)
        {
            IUnitSkill.ESkillNumber eSkillNum = (IUnitSkill.ESkillNumber)i;

            if (!IsContainsKey(eSkillNum))
                continue;

            if (skills[eSkillNum] == null || skills[eSkillNum] == new IUnitSkill.SkillSet())
                continue;

            string skillName = skills[eSkillNum].GetName();

            if (skillName != name)
                continue;

            return skills[eSkillNum];
        }

        Debug.LogWarning("일치하는 스킬 이름이 없습니다!");
        return null;
    }

    public IUnitSkill.SkillSet FindSkillSetWithSkillNumber(IUnitSkill.ESkillNumber skillNumber)
    {
        if (skills == null)
            return null;

        if (!skills.ContainsKey(skillNumber))
        {
            Debug.LogWarning("일치하는 스킬 넘버가 없습니다!");
            return null;
        }

        if (skills[skillNumber] == null || skills[skillNumber] == new IUnitSkill.SkillSet())
        {
            Debug.LogWarning("스킬이 잘못 지정되었습니다.");
            return null;
        }

        return skills[skillNumber];
    }

}
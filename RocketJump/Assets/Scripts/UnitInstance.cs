using UnityEngine;
using System.Collections.Generic;

public class UnitInstance : UnitBase
{
    public override EUnitType type { get; set; }
    public override string unitName { get; set; }
    public override float moveSpeed { get; set; }
    public override IUnitHP.UnitHP hp { get; set; }
    public override Dictionary<IUnitSkill.ESkillNumber, IUnitSkill.SkillSet> skills { get; set; }
    public override IUnitCrowdControl.CrowdControlAffectedDuration crowdControlAffectedDuration { get; set; }

    public UnitInstance(EUnitType type = EUnitType.None, string name = "Please give a name.", float moveSpeed = 0f, int hp = 0)
    {
        this.type = type;
        this.unitName = name;
        this.moveSpeed = moveSpeed;
        this.hp = new IUnitHP.UnitHP(hp);
        skills = new Dictionary<IUnitSkill.ESkillNumber, IUnitSkill.SkillSet>();
        crowdControlAffectedDuration = new IUnitCrowdControl.CrowdControlAffectedDuration();
    }

    public void Damaged(int damage)
    {
        if (hp == null)
        {
            Debug.LogError("Check HP initialize");
            return;
        }
        
        int currentHP = hp.GetHP();

        if (currentHP > 0)
        {
            hp.SetHP(currentHP - damage);
        }

        CheckHP();
    }

    public void CheckHP()
    {
        if (hp == null)
        {
            Debug.LogError("Check HP initialize.");
            return;
        }

        if(hp.GetHP() <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (gameObject == null)
        {
            Debug.LogError("Can't find gameobject.");
            return;
        }

        Destroy(gameObject);
    }
    
    public void AddSkill(IUnitCrowdControl.EUnitCrowdControl ccType, string name, int damage, float coolTime)
    {
        if (skills == null)
        {
            Debug.LogError("There's no space to designate skills! Check if the initialization is done properly!");
            return;
        }

        IUnitSkill.SkillSet newSkill = new IUnitSkill.SkillSet(ccType, name, damage, coolTime);

        if (newSkill == null)
        {
            Debug.LogError("You can't register a new skill!");
            return;
        }

        IUnitSkill.ESkillNumber skillCount = (IUnitSkill.ESkillNumber)skills.Count + 1;

        if (skillCount == IUnitSkill.ESkillNumber.MAX)
        {
            Debug.LogWarning("You can no longer register your skills! Up to 16 skills can be registered.");
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

        Debug.LogWarning("There's no skill name that matches!");
        return null;
    }

    public IUnitSkill.SkillSet FindSkillSetWithSkillNumber(IUnitSkill.ESkillNumber skillNumber)
    {
        if (skills == null)
            return null;

        if (!skills.ContainsKey(skillNumber))
        {
            Debug.LogWarning("There's no skill number that matches!");
            return null;
        }

        if (skills[skillNumber] == null || skills[skillNumber] == new IUnitSkill.SkillSet())
        {
            Debug.LogWarning("The skill is specified incorrectly.");
            return null;
        }

        return skills[skillNumber];
    }

}
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
            Debug.LogError("��ų�� ������ ������ �����ϴ�! �ʱ�ȭ�� ����� �̷�������� Ȯ��!");
            return;
        }

        IUnitSkill.SkillSet newSkill = new IUnitSkill.SkillSet(name, damage, coolTime);

        if (newSkill == null)
        {
            Debug.LogError("�� ��ų�� ����� �� �����ϴ�!");
            return;
        }

        IUnitSkill.ESkillNumber skillCount = (IUnitSkill.ESkillNumber)skills.Count + 1;

        if (skillCount == IUnitSkill.ESkillNumber.MAX)
        {
            Debug.LogWarning("��ų�� �� �̻� ����� �� �����ϴ�! ��ų�� �ִ� 16������ ����� �� �ֽ��ϴ�.");
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

        Debug.LogWarning("��ġ�ϴ� ��ų �̸��� �����ϴ�!");
        return null;
    }

    public IUnitSkill.SkillSet FindSkillSetWithSkillNumber(IUnitSkill.ESkillNumber skillNumber)
    {
        if (skills == null)
            return null;

        if (!skills.ContainsKey(skillNumber))
        {
            Debug.LogWarning("��ġ�ϴ� ��ų �ѹ��� �����ϴ�!");
            return null;
        }

        if (skills[skillNumber] == null || skills[skillNumber] == new IUnitSkill.SkillSet())
        {
            Debug.LogWarning("��ų�� �߸� �����Ǿ����ϴ�.");
            return null;
        }

        return skills[skillNumber];
    }

}
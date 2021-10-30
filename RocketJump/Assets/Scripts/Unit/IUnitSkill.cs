using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitSkill
{
    public Skills skillList { get; set; }

    public enum ESkillNumber
    {
        None = 0,
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh,
        Eighth,
        Ninth,
        Tenth,
        Eleventh,
        Twelfth,
        Thirteenth,
        Fourteenth,
        Fifteenth,
        Sixteenth,
        MAX
    }

    public class Skills
    {
        public SortedList<ESkillNumber, SkillSet> skillList;

        public Skills()
        {
            skillList = new SortedList<ESkillNumber, SkillSet>();
            DefaultValueChecker<SortedList<ESkillNumber, SkillSet>>.IsDefaultValue(skillList, "This skillList is null", "This skillList is not default value");
        }

        public void ClearSkillList()
        {
            if (ErrorHelper.IsNull(this) || ErrorHelper.IsNull(skillList))
            {
                LogHelper.ErrorMessage("Check the skillList initialize.");
                return;
            }

            skillList.Clear();
        }

        public void AddSkill(IUnitCrowdControl.EUnitCrowdControl ccType, string name, int damage, float coolTime)
        {
            if (ErrorHelper.IsNull(this) || ErrorHelper.IsNull(skillList))
            {
                LogHelper.ErrorMessage("There's no space to designate skills! Check if the initialization is done properly!");
                return;
            }

            SkillSet newSkill = new SkillSet(ccType, name, damage, coolTime);

            if (ErrorHelper.IsNull(newSkill, "You can't register a new skill!"))
                return;

            ESkillNumber skillNum = (ESkillNumber)skillList.Count + 1;

            if (StandardChecker.IsCorrect(true, skillNum >= ESkillNumber.MAX, StandardChecker.EErrorLevel.Warning, 
                "You can no longer register your skills! Up to 16 skills can be registered."))
                return;

            skillList.Add(skillNum, newSkill);
        }

        public void AddSkill(SkillSet newSkill)
        {
            if (ErrorHelper.IsNull(this) || ErrorHelper.IsNull(skillList))
            {
                LogHelper.ErrorMessage("There's no space to designate skills! Check if the initialization is done properly!");
                return;
            }

            if (ErrorHelper.IsNull(newSkill, "You can't register a new skill!"))
                return;

            ESkillNumber skillNum = (ESkillNumber)skillList.Count + 1;

            if (StandardChecker.IsCorrect(true, skillNum >= ESkillNumber.MAX, StandardChecker.EErrorLevel.Warning,
                "You can no longer register your skills! Up to 16 skills can be registered."))
                return;

            skillList.Add(skillNum, newSkill);
        }

        public void EditSkill(ESkillNumber skillNumber, IUnitCrowdControl.EUnitCrowdControl ccType, string name, int damage, float coolTime)
        {
            if(!IsContainsKey(skillNumber))
            {
                LogHelper.WarningMessage("There is no skill that matches the skill number.");
                return;
            }

            SkillSet newSkill = new SkillSet(ccType, name, damage, coolTime);

            if (ErrorHelper.IsNull(newSkill, "You can't register a new skill!"))
                return;

            skillList[skillNumber] = newSkill; 
        }

        public bool IsContainsKey(ESkillNumber number)
        {
            if (ErrorHelper.IsNull(this) || ErrorHelper.IsNull(skillList))
            {
                LogHelper.ErrorMessage("Check the skillList initialize.");
                return false;
            }

            return skillList.ContainsKey(number);
        }

        public bool IsContainsValue(SkillSet skillSet)
        {
            if (ErrorHelper.IsNull(this) || ErrorHelper.IsNull(skillList))
            {
                LogHelper.ErrorMessage("Check the skillList initialize.");
                return false;
            }

            return skillList.ContainsValue(skillSet);
        }

        public SkillSet FindSkillSetWithSkillNumber(ESkillNumber skillNumber)
        {
            if (ErrorHelper.IsNull(this) || ErrorHelper.IsNull(skillList))
            {
                LogHelper.ErrorMessage("Check the skillList initialize.");
                return null;
            }

            if (!skillList.ContainsKey(skillNumber))
            {
                LogHelper.WarningMessage("There's no skill number that matches!");
                return null;
            }

            if (ErrorHelper.IsNull(skillList[skillNumber]) || skillList[skillNumber] == new SkillSet())
            {
                LogHelper.WarningMessage("The skill is specified incorrectly.");
                return null;
            }

            return skillList[skillNumber];
        }
    }

    public class SkillSet
    {
        // 나중에 애니메이션 관련 변수 & CC기 정보도 추가해야됨.
        private IUnitCrowdControl.EUnitCrowdControl ccType;
        private string name;
        private int damage;
        private float coolTime;
        // private Animator . . .

        public SkillSet(IUnitCrowdControl.EUnitCrowdControl ccType = IUnitCrowdControl.EUnitCrowdControl.None, string name = "", int damage = 0, float coolTime = 0f)
        {
            this.ccType = ccType;
            this.name = name;
            this.damage = damage;
            this.coolTime = coolTime;
        }

        public string GetName()
        {
            return name;
        }

        public int GetDamage()
        {
            return damage;
        }

        public float GetCoolTime()
        {
            return coolTime;
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }

        public void SetCoolTime(float coolTime)
        {
            this.coolTime = coolTime;
        }
    }
}
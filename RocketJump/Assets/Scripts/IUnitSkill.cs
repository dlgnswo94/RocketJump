using System;
using System.Collections;
using System.Collections.Generic;

public interface IUnitSkill
{
    public Dictionary<ESkillNumber, SkillSet> skills { get; set; }

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

    public class SkillSet
    {
        // ���߿� �ִϸ��̼� ���� ���� & CC�� ������ �߰��ؾߵ�.
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
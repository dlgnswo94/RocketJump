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
        // 나중에 애니메이션 관련 변수 & CC기 정보도 추가해야됨.
        private string name;
        private int damage;
        private float coolTime;
        // private Animator . . .

        public SkillSet(string name = "", int damage = 0, float coolTime = 0f)
        {
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
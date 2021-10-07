using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitCrowdControl
{
    public enum EUnitCrowdControl
    {
        None = 0,
        Slow,
        Stun,
        Silence,
        Blind
    }

    public CrowdControlAffectedDuration crowdControlAffectedDuration { get; set; } 

    public class CrowdControlAffectedDuration
    {
        private float slowDuration;
        private float stunDuration;
        private float silenceDuration;
        private float blindDuration;

        public CrowdControlAffectedDuration()
        {
            slowDuration = 0f;
            stunDuration = 0f;
            silenceDuration = 0f;
            blindDuration = 0f;
        }

        public void SetCrowdControlAffectedDuration(EUnitCrowdControl crowdControlType, float duration, float amount, int damage)
        {
            switch(crowdControlType)
            {
                case EUnitCrowdControl.Slow:
                    slowDuration += duration;
                    break;

                case EUnitCrowdControl.Stun:
                    stunDuration += duration;
                    break;

                case EUnitCrowdControl.Silence:
                    silenceDuration += duration;
                    break;

                case EUnitCrowdControl.Blind:
                    blindDuration += duration;
                    break;
            }
        }

        public float GetSlowDuration()
        {
            return slowDuration;
        }

        public float GetStunDuration()
        {
            return stunDuration;
        }

        public float GetSilenceDuration()
        {
            return silenceDuration;
        }

        public float GetBlindDuration()
        {
            return blindDuration;
        }
    }

    public class CrowdControlAffect
    {
        private EUnitCrowdControl crowdControl;
        private float duration;
        private float amount;
        private int damage;

        public CrowdControlAffect(EUnitCrowdControl crowdControl = EUnitCrowdControl.None, float duration = 0f, float amount = 0f, int damage = 0)
        {
            this.crowdControl = crowdControl;
            this.duration = duration;
            this.amount = amount;
            this.damage = damage;
        }

        public EUnitCrowdControl GetCrowdControl()
        {
            return crowdControl;
        }

        public float GetDuration()
        {
            return duration;
        }

        public float GetAmount()
        {
            return amount;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void SetDuration(float duration)
        {
            this.duration = duration;
        }

        public void SetAmount(float amount)
        {
            this.amount = amount;
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }
    }
}
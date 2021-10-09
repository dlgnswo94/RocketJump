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

    public class CrowdControlAffected
    {
        private Queue<CrowdControlAffect> crowdControlAffects;
        private const int maxQueueLength = 16;
        private int length = 0;

        public CrowdControlAffected()
        {
            crowdControlAffects = new Queue<CrowdControlAffect>();
        }
        
        public void EnqueueCrowdControlAffect(CrowdControlAffect cca)
        {
            if (ErrorHelper.IsNull(crowdControlAffects, "There is no space to store CCA."))
                return;

            if (ErrorHelper.IsMaximum(length, maxQueueLength, "The maximum queue size is {0}.", maxQueueLength))
                return;

            crowdControlAffects.Enqueue(cca);
            length++;
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
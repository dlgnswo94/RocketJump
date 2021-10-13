using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitCrowdControl
{
    public CrowdControlAffected crowdControlAffected { get; set; }

    public enum EUnitCrowdControl
    {
        None = 0,
        Slow,
        Stun,
        Silence,
        Blind,
        MAX
    }

    public enum EUnitCrodwControlTimerMode
    {
        None = 0,
        Plus,
        Minus,
        Multiply,
        MAX
    }

    public class CrowdControlAffected
    {
        private Queue<CrowdControlAffect> crowdControlAffects;
        private SortedList<EUnitCrowdControl, float> crowdControlAffectDuration;
        private const int maxQueueLength = 16;
        private int length = 0;

        private delegate float CountdownDuration (CrowdControlAffect crowdControlAffect, 
            float interp = 0f, EUnitCrodwControlTimerMode timerMode = EUnitCrodwControlTimerMode.Plus);
        
        public CrowdControlAffected()
        {
            crowdControlAffects = new Queue<CrowdControlAffect>();
            crowdControlAffectDuration = new SortedList<EUnitCrowdControl, float>();

            for (EUnitCrowdControl i = EUnitCrowdControl.None + 1; i < EUnitCrowdControl.MAX; i++)
            {
                if (ErrorHelper.IsNull(crowdControlAffectDuration, "Check if the crawdControlAffectDeration is initialized well."))
                    return;

                crowdControlAffectDuration.Add(i, 0f);
            }
            CountdownDuration countdownDuration = CountDuration;
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

        public CrowdControlAffect DequeueCrowdControlAffect()
        {
            if (ErrorHelper.IsNull(crowdControlAffects, "The queue has not been properly initialized."))
                return null;

            if (crowdControlAffects.Peek() == null)
            {
                LogHelper.WarningMessage("There are no more CCs left in the queue.");
                return null;
            }

            return crowdControlAffects.Dequeue();
        }

        public void ApplyCrowdControlAffectDuration()
        {
            CrowdControlAffect newCrowdControlAffect = DequeueCrowdControlAffect();

            if (ErrorHelper.IsNull(newCrowdControlAffect, "There is no new CrowdControlAffect."))
                return;

            if (ErrorHelper.IsNull(crowdControlAffectDuration, "Check if the CrowdControlAffectDuration is initialized well."))
                return;

            crowdControlAffectDuration[newCrowdControlAffect.GetCrowdControl()] = newCrowdControlAffect.GetDuration();
        }

        public float CountDuration(CrowdControlAffect crowdControlAffect, float interp = 0f, EUnitCrodwControlTimerMode timerMode = EUnitCrodwControlTimerMode.Plus)
        {
            return 0f;
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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamEnDEVor.Unit.Enum;
using TeamEnDEVor.Utility;

public interface IUnitSkill
{
    public class UnitSkill
    {
        private EUnitCrowdControlType ccType;
        private float duration;
        private Action skillAction;

        public UnitSkill(EUnitCrowdControlType ccType = EUnitCrowdControlType.None, float duration = 0f, Action skillAction = null)
        {
            this.ccType = ccType;
            this.duration = duration;
            this.skillAction = skillAction;
        }

        public UnitSkill GetUnitSkill()
        {
            if (ErrorChecker.IsNull(this))
                return new UnitSkill();
            return this;
        }

        public EUnitCrowdControlType GetCrowdControlType()
        {
            if (ErrorChecker.IsNull(this))
                return EUnitCrowdControlType.None;
            return ccType;
        }

        public float GetDuration()
        {
            if (ErrorChecker.IsNull(this))
                return 0f;
            return duration;
        }

        public Action GetSkillAction()
        {
            if (ErrorChecker.IsNull(this))
                return null;
            return skillAction;
        }
    }
}
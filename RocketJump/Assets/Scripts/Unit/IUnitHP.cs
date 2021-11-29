using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeamEnDEVor
{
    namespace Unit
    {
        public interface IUnitHP
        {
            public abstract float hp { get; set; }

            public abstract float GetHP();
            public abstract void SetHP(float hp);
            public abstract float GiveDamage(float hp, float damage);
            public abstract float TakeDamage(float hp, float damage);
            public abstract float Die();
        }
    }
}
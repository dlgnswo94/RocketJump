using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeamEnDEVor
{
    namespace Unit
    {
        public abstract class UnitBase : UnitBaseInfo, IUnitMovement, IUnitHP
        {
            public abstract float speed { get; set; }
            public abstract float hp { get; set; }

            public abstract float Die();
            public abstract float GetHP();
            public abstract float GetSpeed();
            public abstract float GiveDamage(float hp, float damage);
            public abstract void Move();
            public abstract void SetHP(float hp);
            public abstract void SetSpeed(float speed);
            public abstract void Stop();
            public abstract float TakeDamage(float hp, float damage);
        }
    }
}
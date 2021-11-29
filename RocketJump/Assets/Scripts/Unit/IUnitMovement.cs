using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeamEnDEVor
{
    namespace Unit
    {
        public interface IUnitMovement
        {
            public abstract float speed { get; set; }

            public abstract float GetSpeed();
            public abstract void SetSpeed(float speed);
            public abstract void Move();
            public abstract void Stop();
        }
    }
}
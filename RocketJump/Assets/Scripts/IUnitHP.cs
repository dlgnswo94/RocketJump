using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitHP
{
    public UnitHP hp { get; set; }

    public class UnitHP
    {
        public int hp;

        public UnitHP(int hp = 0)
        {
            this.hp = hp;
        }

        public void SetHP(int hp)
        {
            this.hp = hp;
        }

        public int GetHP()
        {
            return hp;
        }

        public void Damaged(int damage, GameObject unitObj)
        {
            if (this == null)
            {
                Debug.LogError("Check HP initialize.");
                return;
            }

            if (hp > 0)
                hp = hp - damage;

            if (unitObj == null)
            {
                Debug.LogError("unitObj is NULL! Check the unitObj.");
                return;
            }

            CheckHP(unitObj);
        }

        public void CheckHP(GameObject unitObj)
        {
            if (this == null)
            {
                Debug.LogError("Check HP initialize.");
                return;
            }

            if (unitObj == null)
            {
                Debug.LogError("unitObj is NULL! Check the unitObj.");
                return;
            }

            if (hp <= 0)
                Die(unitObj);
        }

        public void Die(GameObject unitObj)
        {
            if (unitObj == null)
            {
                Debug.LogError("Can't find gameobject.");
                return;
            }

            Object.Destroy(unitObj);
        }
    }
}
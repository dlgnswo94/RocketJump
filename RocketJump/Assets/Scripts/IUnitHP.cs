using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitHP
{
    public UnitHP hp { get; set; }

    public class UnitHP
    {
        public int hp;

        public UnitHP(int hp)
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
    }
}
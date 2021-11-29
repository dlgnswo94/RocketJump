using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeamEnDEVor
{
    namespace Unit
    {
        public interface IUnitBaseInfo
        {
            public enum EUnitType
            {
                None = 0,
                Player,
                Enemy,
                Friendly,
                NPC
            }

            public abstract EUnitType type { get; set; }
            public abstract string unitName { get; set; }
            public abstract GameObject unitObj { get; set; }

            public abstract EUnitType GetUnitType();
            public abstract string GetName();
            public abstract GameObject GetUnitObject();
            public abstract void SetUnitType(EUnitType type);
            public abstract void SetName(string unitName);
            public abstract void SetUnitObject(GameObject unitObj);
        }
    }
}
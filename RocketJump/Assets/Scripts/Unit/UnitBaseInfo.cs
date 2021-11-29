using UnityEngine;

namespace TeamEnDEVor
{
    namespace Unit
    {
        public abstract class UnitBaseInfo : MonoBehaviour, IUnitBaseInfo
        {
            public abstract IUnitBaseInfo.EUnitType type { get; set; }
            public abstract string unitName { get; set; }
            public abstract GameObject unitObj { get; set; }

            public abstract string GetName();
            public abstract GameObject GetUnitObject();
            public abstract IUnitBaseInfo.EUnitType GetUnitType();
            public abstract void SetName(string unitName);
            public abstract void SetUnitObject(GameObject unitObj);
            public abstract void SetUnitType(IUnitBaseInfo.EUnitType type);
        }
    }
}
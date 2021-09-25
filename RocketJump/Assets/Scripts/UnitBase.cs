using UnityEngine;

public abstract class UnitBase : MonoBehaviour
{
    protected enum EType
    {
        None,
        Friendly,
        Enemy,
        NPC
    }

    protected class Info 
    {
        public EType type { get; private set; } = EType.None;
        public bool isInvincible { get; private set; } = false;
        public bool hasHP { get; private set; } = false;
        public bool hasSkill { get; private set; } = false;
        public bool hasEnemy { get; private set; } = false;

        public void SetType(EType type)
        {
            this.type = type;
        }

        public void SetInvincible(bool isInvincible)
        {
            this.isInvincible = isInvincible;
        }

        public void SetHP(bool hasHP)
        {
            this.hasHP = hasHP;
        }

        public void SetSkill(bool hasSkill)
        {
            this.hasSkill = hasSkill;
        }

        public void SetEnemy(bool hasEnemy)
        {
            this.hasEnemy = hasEnemy;
        }
    };

    protected abstract void Initialize(Info info = null);

    protected abstract void Initialize(EType type = EType.None, bool isInvincible = false, bool hasHP = false, bool hasSkill = false, bool hasEnemy = false);
}
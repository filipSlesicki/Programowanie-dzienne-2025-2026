using UnityEngine;

namespace TowerDefence
{
    public abstract class AttackModuleData : ScriptableObject
    {
        public abstract IAttackModule CreateModule(Tower tower);
    }
}

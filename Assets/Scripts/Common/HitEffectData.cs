using UnityEngine;

namespace TowerDefence
{
    public abstract class HitEffectData : ScriptableObject
    {
        public abstract void ApplyTo(Health health, Vector3 hitPosition);
    }
}

using UnityEngine;

namespace TowerDefence
{
    public abstract class BulletModifierData : ScriptableObject
    {
        // Called on every hit. Return true to release the bullet, false to keep it flying.
        public abstract bool OnBulletHit(Bullet bullet, Health hitHealth);
    }
}

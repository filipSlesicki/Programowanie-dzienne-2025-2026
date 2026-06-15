using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "DamageEffect", menuName = "TowerDefence/HitEffects/Damage")]
    public class DamageEffectData : HitEffectData
    {
        [SerializeField] private int damage = 1;

        public override void ApplyTo(Health health, Vector3 hitPosition)
        {
            if (health != null)
                health.TakeDamage(damage);
        }
    }
}

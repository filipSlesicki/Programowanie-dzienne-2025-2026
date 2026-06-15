using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "PoisonEffect", menuName = "TowerDefence/HitEffects/Poison")]
    public class PoisonEffectData : HitEffectData
    {
        [SerializeField] private int damagePerTick = 1;
        [SerializeField] private float tickInterval = 0.5f;
        [SerializeField] private float duration = 3f;

        public override void ApplyTo(Health health, Vector3 hitPosition)
        {
            Enemy enemy = health != null ? health.GetComponent<Enemy>() : null;
            if (enemy != null)
                enemy.AddStatusEffect(new PoisonStatusEffect(damagePerTick, tickInterval, duration));
        }
    }
}

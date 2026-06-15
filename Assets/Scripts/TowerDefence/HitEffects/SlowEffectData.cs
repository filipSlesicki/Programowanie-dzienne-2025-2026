using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "SlowEffect", menuName = "TowerDefence/HitEffects/Slow")]
    public class SlowEffectData : HitEffectData
    {
        [SerializeField, Range(0.01f, 0.99f)] private float speedMultiplier = 0.5f;
        [SerializeField] private float duration = 2f;

        public override void ApplyTo(Health health, Vector3 hitPosition)
        {
            Enemy enemy = health != null ? health.GetComponent<Enemy>() : null;
            if (enemy != null)
                enemy.AddStatusEffect(new SlowStatusEffect(speedMultiplier, duration));
        }
    }
}

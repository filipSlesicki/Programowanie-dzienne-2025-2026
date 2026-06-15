using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "ChainEffect", menuName = "TowerDefence/HitEffects/Chain")]
    public class ChainEffectData : HitEffectData
    {
        [SerializeField] private float jumpRange = 8f;
        [SerializeField] private LayerMask enemyLayer;

        public float JumpRange => jumpRange;
        public LayerMask EnemyLayer => enemyLayer;

        // Chain is handled directly in Bullet.OnTriggerEnter — no-op here for zone attacks
        public override void ApplyTo(Health health, Vector3 hitPosition) { }
    }
}

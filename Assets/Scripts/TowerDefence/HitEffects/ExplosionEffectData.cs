using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "ExplosionEffect", menuName = "TowerDefence/HitEffects/Explosion")]
    public class ExplosionEffectData : HitEffectData
    {
        [SerializeField] private float radius = 3f;
        [SerializeField] private int damage = 5;
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private GameObject explosionVfxPrefab;

        private static readonly Collider[] buffer = new Collider[32];

        public override void ApplyTo(Health health, Vector3 hitPosition)
        {
            if (explosionVfxPrefab != null)
                Object.Destroy(Object.Instantiate(explosionVfxPrefab, hitPosition, Quaternion.identity), 2f);

            int count = Physics.OverlapSphereNonAlloc(hitPosition, radius, buffer, enemyLayer);
            for (int i = 0; i < count; i++)
            {
                Health h = buffer[i].GetComponent<Health>();
                if (h != null)
                    h.TakeDamage(damage);
            }
        }

    }
}

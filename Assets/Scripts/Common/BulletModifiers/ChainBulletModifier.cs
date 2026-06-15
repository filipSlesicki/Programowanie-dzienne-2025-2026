using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "ChainBulletModifier", menuName = "TowerDefence/BulletModifiers/Chain")]
    public class ChainBulletModifier : BulletModifierData
    {
        [SerializeField] private float jumpRange = 8f;
        [SerializeField] private LayerMask enemyLayer;

        public override bool OnBulletHit(Bullet bullet, Health hitHealth)
        {
            Collider[] nearby = Physics.OverlapSphere(bullet.transform.position, jumpRange, enemyLayer);

            Collider best = null;
            float bestDist = jumpRange;
            foreach (var col in nearby)
            {
                if (col.gameObject == hitHealth.gameObject) continue;
                float d = Vector3.Distance(bullet.transform.position, col.transform.position);
                if (d < bestDist) { bestDist = d; best = col; }
            }

            if (best != null)
            {
                bullet.transform.LookAt(best.transform);
                return false;
            }
            return true;
        }
    }
}

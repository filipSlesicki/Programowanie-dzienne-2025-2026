using UnityEngine;

namespace TowerDefence
{
    public class DamageZoneAttack : IAttackModule
    {
        private readonly ZoneAttackData data;
        private readonly Tower tower;
        private static readonly Collider[] buffer = new Collider[32];

        private readonly GameObject vfxInstance;

        public DamageZoneAttack(ZoneAttackData data, Tower tower)
        {
            this.data = data;
            this.tower = tower;

            if (data.AttackVfxPrefab != null)
            {
                vfxInstance = Object.Instantiate(
                    data.AttackVfxPrefab,
                    tower.transform.position,
                    Quaternion.identity,
                    tower.transform
                );
                vfxInstance.transform.localScale = Vector3.one * tower.TowerData.Range * 2f;
            }
        }

        public void Attack()
        {
            int count = Physics.OverlapSphereNonAlloc(
                tower.transform.position,
                tower.TowerData.Range,
                buffer,
                data.EnemyLayer
            );

            for (int i = 0; i < count; i++)
            {
                Health health = buffer[i].GetComponent<Health>();
                if (health == null)
                    continue;

                Vector3 hitPos = buffer[i].transform.position;
                foreach (HitEffectData effect in tower.TowerData.HitEffects)
                    effect.ApplyTo(health, hitPos);
            }
        }

        public void Tick(float deltaTime) { }

        public void DrawGizmos()
        {
            if (tower?.TowerData == null)
                return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(tower.transform.position, tower.TowerData.Range);
        }
    }
}

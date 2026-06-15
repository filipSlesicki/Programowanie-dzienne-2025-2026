using UnityEngine;

namespace TowerDefence
{
    public class SpawnBulletAttack : IAttackModule
    {
        private readonly BulletAttackData data;
        private readonly Tower tower;

        public SpawnBulletAttack(BulletAttackData data, Tower tower)
        {
            this.data = data;
            this.tower = tower;
        }

        public void Attack()
        {
            Transform spawnPoint = tower.ShootPosition;
            GameObject obj = ObjectPoolingSystem.Instance.Get(
                data.BulletPrefab.gameObject, spawnPoint.position, spawnPoint.rotation);

            if (obj.TryGetComponent(out Bullet bullet))
                bullet.Configure(tower.TowerData.HitEffects, data.BulletModifier);
        }
    }
}

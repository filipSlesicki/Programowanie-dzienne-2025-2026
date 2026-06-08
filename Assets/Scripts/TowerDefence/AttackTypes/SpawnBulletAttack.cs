using UnityEngine;

namespace TowerDefence
{
    public class SpawnBulletAttack : MonoBehaviour, IAttackModule
    {
        public Bullet bulletPrefab;
        public Transform shootPosition;

        public void Attack()
        {
            ObjectPoolingSystem.Instance.Get(bulletPrefab.gameObject, shootPosition.position, shootPosition.rotation);

        }
    }
}

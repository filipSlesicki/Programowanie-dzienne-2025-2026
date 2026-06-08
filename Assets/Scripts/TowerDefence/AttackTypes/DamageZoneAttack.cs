using UnityEngine;

namespace TowerDefence
{
    public class DamageZoneAttack : MonoBehaviour, IAttackModule
    {
        public float radius = 5;
        public int damage = 1;
        public LayerMask enemyLayer;
        private Collider[] enemiesInRange = new Collider[32];

        public void Attack()
        {
            int enemyCount = Physics.OverlapSphereNonAlloc(transform.position, radius, enemiesInRange,enemyLayer);
            for (int i = 0; i < enemyCount; i++)
            {
                enemiesInRange[i].GetComponent<Health>().TakeDamage(damage);
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}

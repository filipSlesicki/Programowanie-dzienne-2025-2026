using UnityEngine;

namespace TowerDefence
{
    public class Tower : MonoBehaviour
    {
        public EnemyDetection enemyDetection;
        public float attackSpeed = 1;
        public int damage;
        private float cooldown;
        public Bullet bulletPrefab;
        public Transform shootPosition;
        private bool placed;

        public void Place()
        {
            placed = true;
        }

        void Update()
        {
            if (!placed)
            {
                return;
            }
            cooldown -= Time.deltaTime;
            if (enemyDetection.target != null)
            {
                if(cooldown <= 0)
                {
                    Enemy enemy = enemyDetection.target;
                    Vector3 enemyPosition = enemy.transform.position;
                    float enemySpeed = enemy.moveSpeed;
                    Vector3 enemyMoveDirection = enemy.GetMoveDirection();
                    float distanceToEnemy = Vector3.Distance(transform.position, enemyPosition);
                    float bulletTravelTime = distanceToEnemy / bulletPrefab.speed;
                    Vector3 enemyPositionAfterTime = enemyPosition + enemyMoveDirection * enemy.moveSpeed * bulletTravelTime;
                    enemyPositionAfterTime.y = transform.position.y;
                    transform.LookAt(enemyPositionAfterTime);
                    Instantiate(bulletPrefab, shootPosition.position, transform.rotation);
                    cooldown = attackSpeed;
                }
            }
        }
    }
}

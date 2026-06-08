using UnityEngine;

namespace TowerDefence
{
    public class Tower : MonoBehaviour
    {
        public EnemyDetection enemyDetection;
        public float attackSpeed = 1;
        public IAttackModule attackModule;
        public int damage;
        private float cooldown;
        public Bullet bulletPrefab;
        public Transform shootPosition;
        private bool placed;

        private void Awake()
        {
            attackModule = GetComponent<IAttackModule>();
            Debug.Log("awake");
        }

        public void Place()
        {
            placed = true;
        }

        public void Setup(TowerData towerData)
        {
            Debug.Log("Setup");
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
                    attackModule.Attack();
                    
                    cooldown = attackSpeed;
                }
            }
        }
    }
}

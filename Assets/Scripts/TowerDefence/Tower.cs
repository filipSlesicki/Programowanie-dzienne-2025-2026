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

        void Update()
        {
            cooldown-= Time.deltaTime;
            if (enemyDetection.target != null)
            {
                if(cooldown <= 0)
                {
                    transform.LookAt(enemyDetection.target);
                    Instantiate(bulletPrefab, shootPosition.position, transform.rotation);
                    cooldown = attackSpeed;
                }
            }
        }
    }
}

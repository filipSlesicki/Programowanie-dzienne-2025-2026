using UnityEngine;

namespace TowerDefence
{
    public class Tower : MonoBehaviour
    {
        public EnemyDetection enemyDetection;
        [SerializeField] private Transform shootPosition;

        public Transform ShootPosition => shootPosition;
        public TowerData TowerData { get; private set; }

        private IAttackModule attackModule;
        private float cooldown;
        private bool placed;

        public void Place() => placed = true;

        public void Setup(TowerData data)
        {
            TowerData = data;

            SphereCollider detectionCollider = enemyDetection.GetComponent<SphereCollider>();
            if (detectionCollider != null)
                detectionCollider.radius = data.Range;

            attackModule = data.AttackModule.CreateModule(this);
        }

        void Update()
        {
            if (!placed || attackModule == null)
                return;

            attackModule.Tick(Time.deltaTime);

            cooldown -= Time.deltaTime;

            if (enemyDetection.target == null || cooldown > 0)
                return;

            Enemy enemy = enemyDetection.target;
            transform.LookAt(PredictEnemyPosition(enemy));
            attackModule.Attack();
            cooldown = TowerData.AttackSpeed;
        }

        private void OnDrawGizmosSelected() => attackModule?.DrawGizmos();

        private Vector3 PredictEnemyPosition(Enemy enemy)
        {
            float bulletSpeed = 0f;
            if (TowerData.AttackModule is BulletAttackData bulletData)
                bulletSpeed = bulletData.BulletSpeed;

            if (bulletSpeed <= 0f)
                return enemy.transform.position;

            Vector3 enemyPos = enemy.transform.position;
            float travelTime = Vector3.Distance(transform.position, enemyPos) / bulletSpeed;
            Vector3 predicted = enemyPos + enemy.GetMoveDirection() * enemy.moveSpeed * travelTime;
            predicted.y = transform.position.y;
            return predicted;
        }
    }
}

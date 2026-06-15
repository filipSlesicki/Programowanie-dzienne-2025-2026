using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "BulletAttackData", menuName = "TowerDefence/AttackModules/BulletAttack")]
    public class BulletAttackData : AttackModuleData
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float bulletSpeed = 10f;
        [SerializeField] private BulletModifierData bulletModifier;

        public Bullet BulletPrefab => bulletPrefab;
        public float BulletSpeed => bulletSpeed;
        public BulletModifierData BulletModifier => bulletModifier;

        public override IAttackModule CreateModule(Tower tower) => new SpawnBulletAttack(this, tower);
    }
}

using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "ZoneAttackData", menuName = "TowerDefence/AttackModules/ZoneAttack")]
    public class ZoneAttackData : AttackModuleData
    {
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private GameObject attackVfxPrefab;

        public LayerMask EnemyLayer => enemyLayer;
        public GameObject AttackVfxPrefab => attackVfxPrefab;

        public override IAttackModule CreateModule(Tower tower) => new DamageZoneAttack(this, tower);
    }
}

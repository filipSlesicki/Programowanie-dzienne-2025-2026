using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "LaserAttackData", menuName = "TowerDefence/AttackModules/Laser")]
    public class LaserAttackData : AttackModuleData
    {
        [SerializeField] private Material laserMaterial;
        [SerializeField, Min(0.01f)] private float laserWidth = 0.05f;

        public Material LaserMaterial => laserMaterial;
        public float LaserWidth => laserWidth;

        public override IAttackModule CreateModule(Tower tower) => new LaserAttack(this, tower);
    }
}

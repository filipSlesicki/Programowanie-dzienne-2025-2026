using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "PierceBulletModifier", menuName = "TowerDefence/BulletModifiers/Pierce")]
    public class PierceBulletModifier : BulletModifierData
    {
        [SerializeField] private int pierceCount = 2;

        public int PierceCount => pierceCount;

        public override bool OnBulletHit(Bullet bullet, Health hitHealth)
        {
            bullet.hitsRemaining--;
            return bullet.hitsRemaining <= 0;
        }
    }
}

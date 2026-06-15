using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "TowerData", menuName = "TowerDefence/TowerData")]
    public class TowerData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public Tower Prefab { get; private set; }

        [field: SerializeField] public float AttackSpeed { get; private set; } = 1f;
        [field: SerializeField] public float Range { get; private set; } = 5f;

        [field: SerializeField] public AttackModuleData AttackModule { get; private set; }
        [field: SerializeField] public HitEffectData[] HitEffects { get; private set; }
    }
}

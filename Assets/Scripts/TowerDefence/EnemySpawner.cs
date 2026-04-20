using UnityEngine;

namespace TowerDefence
{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform spawnPosition;
        public GameObject enemyPrefab;
        public float spawnInterval = 2;

        void Start()
        {
            InvokeRepeating("Spawn", spawnInterval,spawnInterval);
        }

        private void Spawn()
        {
            Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
        }


}
}

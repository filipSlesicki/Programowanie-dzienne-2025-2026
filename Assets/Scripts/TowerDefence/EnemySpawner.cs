using System.Collections;
using UnityEngine;

namespace TowerDefence
{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform spawnPosition;
        public GameObject enemyPrefab;
        public float spawnInterval = 2;
        public Wave[] waves;
        public float waveInterval = 5;
        private int waveIndex = -1;
        

        void Start()
        {
           StartCoroutine(SpawnLoop());
        }

        private void Spawn()
        {
            Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
        }

        private IEnumerator SpawnLoop()
        {
            while (waveIndex < waves.Length)
            {
                yield return StartCoroutine(SpawnNextWave());
                yield return new WaitForSeconds(waveInterval);
            }
        }

        private IEnumerator SpawnNextWave()
        {
            waveIndex++;
            Wave wave = waves[waveIndex];
            for (int i = 0; i < wave.EnemyCount; i++)
            {
                Spawn();
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}

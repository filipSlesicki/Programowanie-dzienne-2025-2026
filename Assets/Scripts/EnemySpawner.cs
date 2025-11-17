using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterwal = 1;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] float minXPosition = -6;
    [SerializeField] float maxXPosition = 6;
    [SerializeField] GameObject enemyPrefab;
    float spawnTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer < 0)
        {
            Spawn();
            spawnTimer = spawnInterwal;
        }
    }

    void Spawn()
    {
        spawnPosition.x = Random.Range(minXPosition, maxXPosition);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}

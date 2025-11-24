using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToSpawn;
    [SerializeField] float dropChance = 10;

    public void SpawnDropItem()
    {
        if (Random.value * 100 < dropChance)
        {
            Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], transform.position, transform.rotation);
        }
    }
}

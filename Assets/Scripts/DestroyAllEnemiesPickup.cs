using UnityEngine;

public class DestroyAllEnemiesPickup : MonoBehaviour
{
    [SerializeField] float range = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 playerPosition = other.transform.position;
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Wall");
            float bestDistance = float.MaxValue;
            GameObject closestEnemy = null;

            foreach (GameObject enemy in allEnemies)
            {
                float distance = Vector3.Distance(playerPosition, enemy.transform.position);
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            if (closestEnemy != null)
            {
                Destroy(closestEnemy);
            }

            Destroy(gameObject);
        }
    }
}

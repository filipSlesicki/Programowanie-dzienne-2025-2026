using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] float shootInterval;
    void Start()
    {
        InvokeRepeating(nameof(Shoot), shootInterval, shootInterval);
    }
    private void Shoot()
    {
        GameObject shotBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        shotBullet.GetComponent<Bullet>().ignoreTag = "Wall";
    }
}

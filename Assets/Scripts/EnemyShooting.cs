using TowerDefence;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] ObjectPool pool;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] float shootInterval;
    void Start()
    {
        InvokeRepeating(nameof(Shoot), shootInterval, shootInterval);
    }
    private void Shoot()
    {
        //Bullet shotBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation).GetComponent<Bullet>();
        Bullet shotBullet = pool.Get(bulletSpawnPoint.position, bulletSpawnPoint.rotation).GetComponent<Bullet>();
        shotBullet.ignoreTag = "Wall";
        shotBullet.SetPool(pool);
    }
}

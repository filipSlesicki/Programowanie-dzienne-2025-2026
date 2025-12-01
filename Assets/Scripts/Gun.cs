using System.Data;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Vector3 playerOffset;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private int damage = 1;
    [SerializeField] private float timeBetweenShots = 1;
    [SerializeField] private float spread = 0;
    [SerializeField] private int bulletCount = 1;
    private float timer;
    private float nextShootTime;

    //private void Update()
    //{
    //    timer -= Time.deltaTime;
    //}

    public void Shoot()
    {
        if(Time.time >= nextShootTime)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                float spreadAngle = Random.Range(-spread, spread);
                GameObject bullet = Instantiate(bulletPrefab,
                    bulletSpawnPoint.position,
                    bulletSpawnPoint.rotation * Quaternion.Euler(0, spreadAngle, 0));
                bullet.GetComponent<Bullet>().damage = damage;
                nextShootTime = Time.time + timeBetweenShots;
            }

        }
    }
        
}

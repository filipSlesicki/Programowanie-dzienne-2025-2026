using UnityEngine;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{
    public Vector3 playerOffset;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private int damage = 1;
    [SerializeField] private float timeBetweenShots = 1;
    [SerializeField] private float spread = 0;
    [SerializeField] private int bulletCount = 1;
    [SerializeField] private bool isHitscan;
    [SerializeField] private float range = 5;
    private float timer;
    private float nextShootTime;

    //private void Update()
    //{
    //    timer -= Time.deltaTime;
    //}

    public void Shoot()
    {
        if (Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + timeBetweenShots;
            if (isHitscan)
            {
                if (Physics.Raycast(bulletSpawnPoint.position, bulletSpawnPoint.forward, out RaycastHit hit, range))
                {
                    if (hit.collider.TryGetComponent(out Health health))
                    {
                        health.TakeDamage(damage);
                    }
                }
            }
            else
            {
                for (int i = 0; i < bulletCount; i++)
                {
                    float spreadAngle = Random.Range(-spread, spread);
                    GameObject bullet = Instantiate(bulletPrefab,
                        bulletSpawnPoint.position,
                        bulletSpawnPoint.rotation * Quaternion.Euler(0, spreadAngle, 0));
                    bullet.GetComponent<Bullet>().damage = damage;

                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, range))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * range);
            Gizmos.DrawSphere(hitInfo.point, 0.1f);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(hitInfo.point, hitInfo.normal * range);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(ray.origin, ray.direction * range);
        }

    }

}

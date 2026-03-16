using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] float shootInterval;
    [SerializeField] bool canShoot;

    private void Start()
    {
        if (canShoot)
        {
            InvokeRepeating(nameof(Shoot), shootInterval, shootInterval);
        }
    }

    void Update()
    {
        Vector3 playerPosition = Player.Instance.transform.position;
        Vector3 toPlayer = playerPosition - transform.position;

        transform.Translate(0, 0, -speed * Time.deltaTime);
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}

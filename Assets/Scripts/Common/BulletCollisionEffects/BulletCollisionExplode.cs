using System;
using UnityEngine;

public class BulletCollisionExplode : BulletCollisionEffect
{
    [SerializeField] GameObject explosion;
    [SerializeField] float explosionRadius;
    [SerializeField] LayerMask targetLayers;
    [SerializeField] int explosionDamage;



    protected override void OnBulletCollide(Health _)
    {
        GameObject spawnedExplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(spawnedExplosion, 1);
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, explosionRadius, targetLayers);
        for (int i = 0; i < collidersInRange.Length; i++)
        {
            Health health = collidersInRange[i].GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(explosionDamage);
            }
        }
    }

}

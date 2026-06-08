using UnityEngine;

public class BulletCollisionDamage : BulletCollisionEffect
{
    public int damage =1;
    protected override void OnBulletCollide(Health health)
    {
        health.TakeDamage(damage);
    }
}

using TowerDefence;
using UnityEngine;

public class BulletCollsionSlow : BulletCollisionEffect
{
    public float speedMultiplier = 0.5f;
    public float slowDuration;
    protected override void OnBulletCollide(Health health)
    {
        Enemy enemy = health.GetComponent<Enemy>();
        enemy.AddSpeedModifier(new EnemySpeedModifier(speedMultiplier, slowDuration));
    }
}

using UnityEngine;

public class BulletCollisionJumpToNext : BulletCollisionEffect
{
    public float jumpRange;
    public LayerMask enemyLayer;

    protected override void OnBulletCollide(Health health)
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, jumpRange, enemyLayer);
        Collider closestEnemy = null;
        float bestDistance = jumpRange;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < bestDistance && enemy.gameObject != health.gameObject)
            {
                bestDistance = distance;
                closestEnemy = enemy;
            }
        }
        if (closestEnemy != null)
        {
            transform.LookAt(closestEnemy.transform);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

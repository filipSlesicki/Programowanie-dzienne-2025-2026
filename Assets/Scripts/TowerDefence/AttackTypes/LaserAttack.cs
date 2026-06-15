using UnityEngine;

namespace TowerDefence
{
    public class LaserAttack : IAttackModule
    {
        private readonly Tower tower;
        private readonly LineRenderer lineRenderer;
        private float effectTimer;

        public LaserAttack(LaserAttackData data, Tower tower)
        {
            this.tower = tower;

            lineRenderer = tower.gameObject.AddComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
            lineRenderer.startWidth = data.LaserWidth;
            lineRenderer.endWidth = data.LaserWidth;
            lineRenderer.useWorldSpace = true;
            if (data.LaserMaterial != null)
            {
                lineRenderer.material = data.LaserMaterial;
            }

            lineRenderer.enabled = false;
        }

        public void Attack() { }

        public void Tick(float deltaTime)
        {
            Enemy target = tower.enemyDetection.target;

            if (target == null)
            {
                lineRenderer.enabled = false;
                return;
            }

            effectTimer -= deltaTime;
            if (effectTimer <= 0f)
            {
                effectTimer = tower.TowerData.AttackSpeed;
                Health health = target.GetComponent<Health>();
                Vector3 targetPos = target.transform.position;
                foreach (HitEffectData effect in tower.TowerData.HitEffects)
                    effect.ApplyTo(health, targetPos);
            }

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, tower.ShootPosition.position);
            lineRenderer.SetPosition(1, target.transform.position);
        }
    }
}

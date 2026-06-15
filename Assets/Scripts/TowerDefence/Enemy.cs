using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class Enemy : MonoBehaviour
    {
        Transform[] pathPoints;
        public float moveSpeed = 2;
        private float currentSpeed;
        int nextPointIndex = 0;
        Health health;
        public int Reward = 1;
        private List<StatusEffect> statusEffects = new();

        public void AddStatusEffect(StatusEffect effect)
        {
            statusEffects.Add(effect);
            effect.OnApply(this);
        }

        public void MultiplySpeed(float multiplier) => currentSpeed *= multiplier;

        public Vector3 GetMoveDirection()
        {
            return (pathPoints[nextPointIndex].position - transform.position).normalized;
        }

        public float GetNormalizedDistanceAlongPath()
        {
            float distanceToNextPoint = Vector3.Distance(pathPoints[nextPointIndex].position, transform.position);

            if (nextPointIndex == 0)
                return distanceToNextPoint;

            float distanceBetweenPreviousAndNextPoint = Vector3.Distance(
                pathPoints[nextPointIndex - 1].position, pathPoints[nextPointIndex].position);
            return nextPointIndex + 1 - distanceToNextPoint / distanceBetweenPreviousAndNextPoint;
        }

        void Start()
        {
            currentSpeed = moveSpeed;
            pathPoints = Path.Instance.points;
            health = GetComponent<Health>();
            health.onDestroy.AddListener(() => MoneyManager.Instance.AddMoney(Reward));
        }

        void Update()
        {
            TickStatusEffects();
            transform.position = Vector3.MoveTowards(
                transform.position,
                pathPoints[nextPointIndex].position,
                currentSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, pathPoints[nextPointIndex].position) == 0)
            {
                if (nextPointIndex == pathPoints.Length - 1)
                {
                    PlayerBase.Instance.Health.TakeDamage(1);
                    Destroy(gameObject);
                    return;
                }
                nextPointIndex++;
            }
        }

        private void TickStatusEffects()
        {
            float dt = Time.deltaTime;
            for (int i = statusEffects.Count - 1; i >= 0; i--)
            {
                statusEffects[i].Tick(dt);
                if (statusEffects[i].IsExpired)
                {
                    statusEffects[i].OnRemove(this);
                    statusEffects.RemoveAt(i);
                }
            }
        }
    }
}

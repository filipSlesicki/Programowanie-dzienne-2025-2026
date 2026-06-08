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
        private List<EnemySpeedModifier> speedModifiers = new();

        public void AddSpeedModifier(EnemySpeedModifier speedModifier)
        {
            speedModifiers.Add(speedModifier);
            currentSpeed *= speedModifier.modifier;
        }

        public void RemoveSpeedModifier(EnemySpeedModifier speedModifier)
        {
            currentSpeed /= speedModifier.modifier;
            speedModifiers.Remove(speedModifier);
        }

        public Vector3 GetMoveDirection()
        {
            return (pathPoints[nextPointIndex].position - transform.position).normalized;
        }

        public float GetNormalizedDistanceAlongPath()
        {
            float distanceToNextPoint = Vector3.Distance(pathPoints[nextPointIndex].position, transform.position);

            if (nextPointIndex == 0)
            {
                return distanceToNextPoint;
            }
            float distanceBetweenPreviousAndNextPoint = Vector3.Distance(pathPoints[nextPointIndex - 1].position, pathPoints[nextPointIndex].position);
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
            TickModifiers();
            transform.position = Vector3.MoveTowards(transform.position, pathPoints[nextPointIndex].position, currentSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, pathPoints[nextPointIndex].position) == 0)
            {
                if (nextPointIndex == pathPoints.Length - 1)
                {
                    //Reached end
                    PlayerBase.Instance.Health.TakeDamage(1);
                    Destroy(gameObject);
                    return;
                }

                nextPointIndex++;
            }
        }

        private void TickModifiers()
        {
            float deltaTime = Time.deltaTime;
      
            foreach (var modifier in speedModifiers.ToArray())
            {
                modifier.Tick(deltaTime);
                if (modifier.expired)
                {
                    RemoveSpeedModifier(modifier);
                }
            }
        }
    }
}

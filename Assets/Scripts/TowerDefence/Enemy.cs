using UnityEngine;

namespace TowerDefence
{
    public class Enemy : MonoBehaviour
    {
        Transform[] pathPoints;
        public float moveSpeed = 2;
        int nextPointIndex = 0;
        Health health;
        public int Reward = 1;

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
            pathPoints = Path.Instance.points;
            health = GetComponent<Health>();
            health.onDestroy.AddListener(() => MoneyManager.Instance.AddMoney(Reward));
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, pathPoints[nextPointIndex].position, moveSpeed * Time.deltaTime);
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
    }
}

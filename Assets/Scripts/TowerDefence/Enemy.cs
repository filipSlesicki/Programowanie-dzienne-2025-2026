using UnityEngine;

namespace TowerDefence
{
    public class Enemy : MonoBehaviour
    {
        Transform[] pathPoints;
        public float moveSpeed = 2;
        int pointIndex = 0;

        void Start()
        {
            pathPoints = Path.Instance.points;
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, pathPoints[pointIndex].position, moveSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, pathPoints[pointIndex].position) == 0)
            {
                if (pointIndex == pathPoints.Length - 1)
                {
                    //Reached end
                    PlayerBase.Instance.Health.TakeDamage(1);
                    Destroy(gameObject);
                    return;
                }

                pointIndex++;
            }
        }
    }
}

using UnityEngine;

namespace TowerDefence
{
    public class Path : MonoBehaviour
    {
        public Transform[] points;
        public static Path Instance;

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(points[0].position, 0.5f);
            for (int i = 0; i < points.Length-1; i++)
            {
                Gizmos.DrawLine(points[i].position, points[i + 1].position);
            }
        }
    }
}

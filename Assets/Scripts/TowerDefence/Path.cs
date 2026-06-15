using System.Linq;
using UnityEngine;

namespace TowerDefence
{
    public class Path : MonoBehaviour
    {
        public Transform[] points;
        public LineRenderer lineRenderer;
        public static Path Instance;

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            lineRenderer.positionCount = points.Length;
            lineRenderer.SetPositions(points.Select(p => p.position).ToArray());
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

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerDefence
{
    public class EnemyDetection : MonoBehaviour
    {
        public Enemy target;
        private List<Enemy> enemiesInRange = new();

        private void Update()
        {
            if(target != null && !target.isActiveAndEnabled)
            {
                enemiesInRange.Remove(target);
                target = null;
                SelectClosestEnemy();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Enemy enemy))
            {
                enemiesInRange.Add(enemy);
                SelectClosestEnemy();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemiesInRange.Remove(enemy);
                if(enemy == target)
                {
                    SelectClosestEnemy();
                }
            }
        }

        private void SelectClosestEnemy()
        {
            target = enemiesInRange.OrderByDescending(enemy => enemy.GetNormalizedDistanceAlongPath()).FirstOrDefault();

        }
    }
}

using UnityEngine;

namespace TowerDefence
{
    public class EnemyDetection : MonoBehaviour
    {
        public Transform target;
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Enemy"))
            {
                print("in range");
                target = other.transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                target = null;
            }
        }
    }
}

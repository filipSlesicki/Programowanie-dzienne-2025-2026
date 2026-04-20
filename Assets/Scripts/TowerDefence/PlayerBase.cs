using UnityEngine;

namespace TowerDefence
{
    public class PlayerBase : MonoBehaviour
    {
        public Health Health;
        public static PlayerBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindAnyObjectByType<PlayerBase>();
                }
                return instance;
            }
        }

        

        private static PlayerBase instance;
        public void OnDeath()
        {
            Debug.Log("Game over");
        }
    }
}

using UnityEngine;

namespace TowerDefence
{
    public class EnemySpeedModifier
    {
        public float modifier;
        public float durartaion;
        public bool expired;
        private float timeLeft;

        public EnemySpeedModifier(float modifier, float durartaion)
        {
            this.modifier = modifier;
            this.durartaion = durartaion;
            timeLeft = durartaion;
        }

        public void Tick(float deltaTime)
        {
            timeLeft -= deltaTime;
            expired = timeLeft <= 0;
        }
    }
}

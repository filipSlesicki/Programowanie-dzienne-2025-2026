namespace TowerDefence
{
    public class SlowStatusEffect : StatusEffect
    {
        private readonly float speedMultiplier;
        private float timeLeft;

        public SlowStatusEffect(float speedMultiplier, float duration)
        {
            this.speedMultiplier = speedMultiplier;
            timeLeft = duration;
        }

        public override void OnApply(Enemy enemy) => enemy.MultiplySpeed(speedMultiplier);

        public override void Tick(float deltaTime)
        {
            timeLeft -= deltaTime;
            if (timeLeft <= 0f)
                IsExpired = true;
        }

        public override void OnRemove(Enemy enemy) => enemy.MultiplySpeed(1f / speedMultiplier);
    }
}

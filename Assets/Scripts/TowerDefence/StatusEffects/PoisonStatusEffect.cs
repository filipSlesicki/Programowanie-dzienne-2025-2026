namespace TowerDefence
{
    public class PoisonStatusEffect : StatusEffect
    {
        private readonly int damagePerTick;
        private readonly float tickInterval;
        private float durationLeft;
        private float tickTimer;
        private Health cachedHealth;

        public PoisonStatusEffect(int damagePerTick, float tickInterval, float duration)
        {
            this.damagePerTick = damagePerTick;
            this.tickInterval = tickInterval;
            durationLeft = duration;
            tickTimer = tickInterval;
        }

        public override void OnApply(Enemy enemy) => cachedHealth = enemy.GetComponent<Health>();

        public override void Tick(float deltaTime)
        {
            durationLeft -= deltaTime;
            if (durationLeft <= 0f)
            {
                IsExpired = true;
                return;
            }

            tickTimer -= deltaTime;
            if (tickTimer <= 0f)
            {
                cachedHealth?.TakeDamage(damagePerTick);
                tickTimer = tickInterval;
            }
        }

        public override void OnRemove(Enemy enemy) { }
    }
}

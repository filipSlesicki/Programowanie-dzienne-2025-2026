namespace TowerDefence
{
    public abstract class StatusEffect
    {
        public bool IsExpired { get; protected set; }

        public abstract void OnApply(Enemy enemy);
        public abstract void Tick(float deltaTime);
        public abstract void OnRemove(Enemy enemy);
    }
}

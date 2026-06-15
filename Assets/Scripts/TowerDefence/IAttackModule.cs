namespace TowerDefence
{
    public interface IAttackModule
    {
        void Attack();
        void Tick(float deltaTime) { }
        void DrawGizmos() { }
    }
}

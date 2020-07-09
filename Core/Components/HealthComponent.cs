namespace ActionRPG.Core.Components
{
    public class HealthComponent : IComponent
    {
        public ComponentIndex Code => ComponentIndex.Health;
        public int HealthPoints;

        public HealthComponent(int maxHealth)
        {
            this.HealthPoints = maxHealth;
        }
    }
}
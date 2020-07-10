namespace ActionRPG.Core.Components
{
    public class HealthComponent : IComponent
    {
        public ComponentIndex Code => ComponentIndex.Health;
        public int MaxHealth;
        public int HealthPoints;

        public HealthComponent(int maxHealth)
        {
            this.MaxHealth = maxHealth;
            this.HealthPoints = maxHealth;
        }
    }
}
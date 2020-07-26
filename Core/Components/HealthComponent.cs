namespace ActionRPG.Core.Components
{
    public delegate void HealthUpdateEvent(HealthComponent component);

    public class HealthComponent : IComponent
    {
        public ComponentIndex Code => ComponentIndex.Health;
        public int MaxHealth;
        public int HealthPoints;
        public HealthUpdateEvent Handlers;

        public HealthComponent(int maxHealth)
        {
            this.MaxHealth = maxHealth;
            this.HealthPoints = maxHealth;
        }

        public void SetHealth(int newHealth)
        {
            this.HealthPoints = newHealth;
            Handlers?.Invoke(this);
        }
    }
}
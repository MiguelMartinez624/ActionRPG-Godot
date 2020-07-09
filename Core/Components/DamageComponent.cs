namespace ActionRPG.Core.Components
{
    public class DamageComponent : IComponent
    {
        public ComponentIndex Code => ComponentIndex.Damage;
        public bool ItsAttacking = false;
    }
}
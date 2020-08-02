namespace ActionRPG.Core.Components
{
    public class InventoryComponent : IComponent
    {
        public ComponentIndex Code => ComponentIndex.Equipement;
        public int MaxCap;
    }
}
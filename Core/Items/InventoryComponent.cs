using System.Collections.Generic;
using ActionRPG.Core.Components;


namespace ActionRPG.Core.Items
{
    public class InventoryComponent : IComponent
    {
        public ComponentIndex Code => ComponentIndex.Equipement;
        public int MaxCap = 20;
        public List<Item> Items = new List<Item>();
    }
}
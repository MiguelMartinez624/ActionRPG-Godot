using ActionRPG.Core.Components;
using System.Collections.Generic;


namespace ActionRPG.Core.Items
{
    public class EquipmentComponent : IComponent
    {
        public ComponentIndex Code => ComponentIndex.Equipement;
        public Dictionary<ItemType, Item> EquipMap;
    }
}
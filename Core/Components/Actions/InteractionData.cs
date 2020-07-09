using ActionRPG.Core.Items;

namespace ActionRPG.Core.Components
{
    public struct InteractionData<T>
    {
        public Weapon Weapon;
        public T TargetData;
    }
}
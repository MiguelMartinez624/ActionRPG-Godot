namespace ActionRPG.Core.Components
{
    public interface IComponentsHolder
    {
        IComponent GetComponent(ComponentIndex index);
    }
}
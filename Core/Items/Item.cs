namespace ActionRPG.Core.Items
{
    public interface Item
    {
        string Name { get; set; }
        ItemType Type { get; }
    }
}
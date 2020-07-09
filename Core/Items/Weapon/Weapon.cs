namespace ActionRPG.Core.Items
{
    public abstract class Weapon : Item
    {
        public string Name
        {
            get { return Name; }
            set { Name = value; }
        }

        public ItemType Type => ItemType.Weapon;

        public int Damage;
        public int Durability;
    }
}
namespace ActionRPG.Core.Items
{
    public class Sword : Weapon
    {
        public Sword(int damage, int durability)
        {
            this.Damage = damage;
            this.Durability = durability;
        }
    }
}
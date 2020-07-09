using System;

namespace ActionRPG.Core.Components
{
    public class TakeDamageAction : IInteractionAction<HealthComponent>
    {
        public void Execute(InteractionData<HealthComponent> data)
        {
            if (data.Weapon != null)
            {
                data.TargetData.HealthPoints -= data.Weapon.Damage;
                Console.WriteLine("life that left");
            }
        }
    }
}
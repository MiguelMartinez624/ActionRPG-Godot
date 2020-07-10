using Godot;
using System;
using ActionRPG.Core.Components;

public class HurtBox : Area2D
{
    private HealthComponent _healthComponent;


    public void AttackHealthComponent(HealthComponent component)
    {
        this._healthComponent = component;
    }
    
    public void OnHurtBox_AreaEntered(HitBox area)
    {
        InteractionData<HealthComponent> data;
        data.Weapon = area.Weapon;
        data.TargetData = this._healthComponent;

        new TakeDamageAction().Execute(data);
        if (this._healthComponent.HealthPoints <= 0)
        {
            QueueFree();
        }
        else
        {
            Console.WriteLine("Tes salvaste");
        }

        // Replace with function body.
    }

}

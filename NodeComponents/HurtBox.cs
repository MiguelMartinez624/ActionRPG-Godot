using Godot;
using System;
using ActionRPG.Core.Components;

public delegate void HurtHandler(InteractionData<HealthComponent> data);

public class HurtBox : Area2D
{
    private HealthComponent _healthComponent;
    public HurtHandler OnHurtHandler;

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

        this.OnHurtHandler(data);


        // Replace with function body.
    }
}
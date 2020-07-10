using Godot;
using System;
using ActionRPG.Core.Components;

public class Grass : Node2D
{
    public HealthComponent HealthComponent = new HealthComponent(10);
    public HurtBox hurtBox;

    public override void _Ready()
    {
        this.hurtBox = this.GetNode<HurtBox>("./HurtBox");
        this.hurtBox.AttackHealthComponent(this.HealthComponent);
    }
}
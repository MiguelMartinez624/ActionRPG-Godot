using Godot;
using System;
using ActionRPG.Core.Components;

public class Grass : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public HealthComponent HealthComponent = new HealthComponent(10);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public void OnHurtBox_AreaEntered(HitBox area)
    {
        InteractionData<HealthComponent> data;
        data.Weapon = area.Weapon;
        data.TargetData = this.HealthComponent;

        new TakeDamageAction().Execute(data);
        if (this.HealthComponent.HealthPoints <= 0)
        {
            QueueFree();
        }
        else
        {
            Console.WriteLine("Tes salvaste");
        }

        // Replace with function body.
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
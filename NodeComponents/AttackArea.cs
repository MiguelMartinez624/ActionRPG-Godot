using Godot;
using System;
using ActionRPG.Core.Items;

public class AttackArea : Position2D
{
    private HitBox _hitBox;
   
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this._hitBox = this.GetNode<HitBox>("./HitBox");
    }

    public void SetWeapon(Weapon weapon)
    {
        this._hitBox.Weapon = weapon;
    }

    public void UpdateOrientation(Vector2 v)
    {
        if (v.x > 0)
        {
            this.RotationDegrees = 180f;
        }
        else if (v.x < 0)
        {
            this.RotationDegrees = 0f;
        }
        else if (v.y > 0)
        {
            this.RotationDegrees = 270f;
        }
        else
        {
            this.RotationDegrees = 90f;
        }
    }

    public void DisabledHitBox()
    {
        var area = this.GetChild<Area2D>(0);
        var collider = area.GetChild<CollisionShape2D>(0);
        collider.Disabled = true;
    }
}
using Godot;
using System;
using ActionRPG.Core.Items;

public class HitBox : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public Weapon Weapon;

    public string WeaponName = "la matadora";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
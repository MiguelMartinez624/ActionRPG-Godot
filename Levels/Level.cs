using System;
using Godot;

namespace ActionRPG
{
    public class Level : Node2D
    {
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";
        [Export] public bool HavePlayer;

        [Export] public Vector2 LeftEntryPosition;
        [Export] public Vector2 RightEntryPosition;
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
}
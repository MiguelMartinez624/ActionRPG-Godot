using System;
using Godot;

// AreaPortal trigger area (scene) transitions.
namespace ActionRPG
{
    public class AreaPortal : Area2D
    {
        [Export] public string AreaName;


        public void OnAreaPortal_AreaEntered(Player area)
        {
            GetTree().ChangeScene($"res://World/{this.AreaName}.tscn");
            // GetTree().GetRoot()
        }

//  }
    }
}
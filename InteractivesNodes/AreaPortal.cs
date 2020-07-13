using System;
using Godot;

// AreaPortal trigger area (scene) transitions.
namespace ActionRPG
{
    public class AreaPortal : Area2D
    {
        [Export] public string AreaName;


        public void OnAreaPortal_AreaEntered(Player player)
        {
            var global = (Global) GetNode("/root/Global");
            global.GotoScene(player, $"res://World/{this.AreaName}.tscn");
 
        }

//  }
    }
}
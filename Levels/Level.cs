using System;
using ActionRPG.Core.Items;
using Godot;

namespace ActionRPG
{
    public class Level : Spatial
    {
        [Export] public bool HavePlayer;
        [Export] public Vector3 LeftEntryPosition;
        [Export] public Vector3 RightEntryPosition;
        [Export] public Vector3 InitialRespawnPosition { get; set; }


        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
        }

        public void InsertPlayer(Player player, string entryPoint)
        {
           
            AddChild(player);

            // switch (entryPoint)
            // {
            //     case "left":
            //         player = this.LeftEntryPosition;
            //         break;
            //     case "right":
            //         player.GlobalPosition = this.RightEntryPosition;
            //         break;
            //     default:
            //         player.GlobalPosition = this.InitialRespawnPosition;
            //         break;
            // }
        }
    }
}
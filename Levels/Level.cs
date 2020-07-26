using System;
using ActionRPG.Core.Items;
using Godot;

namespace ActionRPG
{
    public class Level : Node2D
    {
        [Export] public bool HavePlayer;
        [Export] public Vector2 LeftEntryPosition;
        [Export] public Vector2 RightEntryPosition;
        [Export] public Vector2 InitialRespawnPosition { get; set; }


        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
        }

        public void InsertPlayer(Player player, string entryPoint)
        {
            var ysort = this.GetNode<YSort>("./YSortEntities");
            ysort?.AddChild(player);

            switch (entryPoint)
            {
                case "left":
                    player.GlobalPosition = this.LeftEntryPosition;
                    break;
                case "right":
                    player.GlobalPosition = this.RightEntryPosition;
                    break;
                default:
                    player.GlobalPosition = this.InitialRespawnPosition;
                    break;
            }
        }
    }
}
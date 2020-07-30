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
        [Export] public Vector3 UpRespawnPosition;
        [Export] public Vector3 DownRespawnPosition;
        [Export] public Vector3 InitialRespawnPosition { get; set; }


        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
        }

        public void InsertPlayer(Player player, string entryPoint)
        {
            var playerGlobalTransform = player.GlobalTransform;
            switch (entryPoint)
            {
                case "left":
                    playerGlobalTransform.origin = this.LeftEntryPosition;
                    break;
                case "right":
                    playerGlobalTransform.origin = this.RightEntryPosition;
                    break;
                case "down":
                    var up = GetNode<Area>("./UpPosition");
                    player.GlobalTranslate(up.GlobalTransform.origin); 
                    break;
                case "up":
                    var down = GetNode<Area>("./DownPosition");
                    player.GlobalTranslate(down.GlobalTransform.origin); 
                    
                    break;
                default:
                    playerGlobalTransform.origin = this.InitialRespawnPosition;
                    break;
            }

            AddChild(player);
        }
    }
}
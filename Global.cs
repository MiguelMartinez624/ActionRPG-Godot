using System;
using Godot;
using Object = System.Object;

namespace ActionRPG
{
    public class Global : Node
    {
        public Node CurrentScene { get; set; }
        public Node CurrentYsort { get; set; }
        public Player Player;

        public override void _Ready()
        {
        }


        public void GotoScene(Player player, string sceneName, string side)
        {
            this.Player = player;
            CallDeferred(nameof(DeferredGotoScene), sceneName, side);
        }

        public void DeferredGotoScene(string path, string side)
        {
            try
            {
                Console.WriteLine("Changing scene");
                var prevScene = CurrentScene;
                var game = GetTree().Root.GetNode("./Game");
                // Load the new scene level
                var newLevel = ResourceLoader.Load<PackedScene>(path).Instance();

                // Remove level
                game.RemoveChild(game.GetChild(game.GetChildCount() - 1));

                // Removes al player de la scena
                this.Player.GetParent().RemoveChild(this.Player);

                // Get the root tree to and we add the new scene
                game.AddChild(newLevel);

                // Teletransport
                var level = (Level) newLevel;
                level.InsertPlayer(this.Player, side);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
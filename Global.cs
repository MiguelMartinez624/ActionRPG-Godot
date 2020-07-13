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
            Viewport root = GetTree().GetRoot();
            CurrentScene = root.GetChild(root.GetChildCount() - 1);
        }


        public void GotoScene(Player player, string sceneName)
        {
            this.Player = player;

            CallDeferred(nameof(DeferredGotoScene), sceneName);
        }

        public void DeferredGotoScene(string path)
        {
            try
            {
                Console.WriteLine("Changing scene");
                var prevScene = CurrentScene;
                // It is now safe to remove the current scene


                var newScene = ResourceLoader.Load<PackedScene>(path);
                CurrentScene = (Level) newScene.Instance();


                GetTree().GetRoot().AddChild(CurrentScene);
                GetTree().SetCurrentScene(CurrentScene);

                this.Player.GetParent().RemoveChild(this.Player);
                Console.WriteLine(this.Player.GetParent());
                var ysort = CurrentScene.GetNode<YSort>("./YSortEntities");
                ysort?.AddChild(this.Player);
                var level = (Level) this.CurrentScene;
                this.Player.GlobalPosition = level.LeftEntryPosition;
                prevScene.QueueFree();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
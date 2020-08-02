using Godot;
using System;
using ActionRPG;

public class Game : Node
{
    public Level CurrentLevel { get; set; }
    public Player Player { get; set; }

    public override void _Ready()
    {
        this.CurrentLevel = this.GetChild<Level>(1);
        if (!this.CurrentLevel.HavePlayer)
        {
            if (this.Player == null)
            {
                var resource = ResourceLoader.Load<PackedScene>("./Player/Player.tscn");
                Player = (Player) resource.Instance();

                // Attach player components to the UI
                var playerUI = GetChild<CanvasLayer>(0).GetNode<PlayerUI>("./PlayerUI");
                playerUI.AttackPlayerHealthToStatus(Player.HealthComponent);
            }

            this.CurrentLevel.InsertPlayer(this.Player, "initial");
        }
    }
}
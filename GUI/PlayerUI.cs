using Godot;
using System;
using ActionRPG.Core.Components;

namespace ActionRPG
{
    public class PlayerUI : Control
    {
        private TextureProgress healthBar;

        public override void _Ready()
        {
            this.healthBar = this.GetChild(0).GetChild(0).GetChild<TextureProgress>(1);
        }

        public void AttackPlayerHealthToStatus(HealthComponent component)
        {
            this.healthBar.Value = component.HealthPoints;
            component.Handlers += this._updateHealthBar;
        }

        private void _updateHealthBar(HealthComponent component)
        {
            this.healthBar.Value = component.HealthPoints;
        }

        public override void _ExitTree()
        {
            base._ExitTree();
            Console.WriteLine("ME MATARON");
        }
    }
}
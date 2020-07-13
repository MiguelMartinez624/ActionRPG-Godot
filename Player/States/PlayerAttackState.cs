using System;
using ActionRPG.Core.StateMachine;
using Godot;

namespace ActionRPG.States
{
    public class PlayerAttackState : IState<Player>
    {
        public StatesIndex Code => StatesIndex.Attack;

        public void OnEnter(Player target, float deltaTime)
        {
            Console.WriteLine(this.Code);
        }

        public StatesIndex Execute(Player target, float deltaTime)
        {
            if (!target.DamageComponent.ItsAttacking)
            {
                return StatesIndex.Idle;
            }

            target.MovementComponent.Restart();
            target.HealthComponent.HealthPoints -= 2;
            GD.Print($"reamaining player life {target.HealthComponent.HealthPoints}");
            return StatesIndex.Attack;
        }

        public void OnLeave(Player target, float deltaTime)
        {
            target.DisableAttack();
        }
    }
}
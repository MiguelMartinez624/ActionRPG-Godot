using System;
using ActionRPG.Core.Components;
using ActionRPG.Core.StateMachine;
using Godot;

namespace ActionRPG.States
{
    public class PlayerIdleState : IState<Player>
    {
        public StatesIndex Code => StatesIndex.Idle;
        private IdleAction _action = new IdleAction();

        public PlayerIdleState()
        {
            Console.WriteLine(this.Code);
        }

        public void OnEnter(Player components, float deltaTime)
        {
           
            components.MovementComponent.Restart();
        }

        public StatesIndex Execute(Player components, float deltaTime)
        {
            if (components.DamageComponent.ItsAttacking)
            {
                return StatesIndex.Attack;
            }
            return this._action.Execute(components.MovementComponent, deltaTime);
        }

        public void OnLeave(Player components, float deltaTime)
        {
            components.MovementComponent.Restart();

        }
    }
}
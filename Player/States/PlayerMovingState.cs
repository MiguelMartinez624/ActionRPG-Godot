using System;
using ActionRPG.Core.Components;
using ActionRPG.Core.StateMachine;

namespace ActionRPG.States
{
    public class PlayerMovingState : IState<Player>
    {
        public StatesIndex Code => StatesIndex.MoveForward;
        private MoveForwardAction _action = new MoveForwardAction();

        public void OnEnter(Player target, float deltaTime)
        {
        }

        public StatesIndex Execute(Player target, float deltaTime)
        {
            if (target.DamageComponent.ItsAttacking)
            {
                return StatesIndex.Attack;
            }

     
            var newStateIndex = this._action.Execute(target.MovementComponent, deltaTime);
            
            return newStateIndex;
        }

        public void OnLeave(Player target, float deltaTime)
        {
        }
    }
}
using System;
using ActionRPG.Core.StateMachine;

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

            return StatesIndex.Attack;
        }

        public void OnLeave(Player target, float deltaTime)
        {
            target.DisableAttack();
        }
    }
}
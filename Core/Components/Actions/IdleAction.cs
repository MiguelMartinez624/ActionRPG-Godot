using System;
using ActionRPG.Core.StateMachine;
using Godot;

namespace ActionRPG.Core.Components
{
    public class IdleAction : IAction<MovementComponent>
    {
        public StatesIndex Execute(MovementComponent target, float deltaTime)
        {
            var (itsMovingBackward, itsMovingForward, itsMovingLeft, itsMovingRight) = target;
            // Cancelation
            if (itsMovingForward || itsMovingLeft ||
                itsMovingRight || itsMovingBackward)
            {
                return StatesIndex.MoveForward;
            }

            target.Velocity = Vector3.Zero;
            target.ItsMovingBackward = false;
            target.ItsMovingLeft = false;
            target.ItsMovingRight = false;
            target.ItsMovingForward = false;
            return StatesIndex.Idle;
        }
    }
}
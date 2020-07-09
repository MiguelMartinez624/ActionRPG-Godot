using ActionRPG.Core.StateMachine;
using Godot;

namespace ActionRPG.Core.Components
{
    public class MoveForwardAction : IAction<MovementComponent>
    {
        public StatesIndex Execute(MovementComponent target, float deltaTime)
        {
            target.Velocity = Vector2.Zero;
            var (itsMovingBackward, itsMovingForward, itsMovingLeft, itsMovingRight) = target;
            
            if (!itsMovingForward && !itsMovingLeft && !itsMovingRight && !itsMovingBackward)
            {
                return StatesIndex.Idle;
            }

            if (itsMovingLeft)
            {
                target.Velocity.x -= 1;
            }

            if (itsMovingRight)
            {
                target.Velocity.x += 1;
            }

            if (itsMovingForward)
            {
                target.Velocity.y += 1;
            }

            if (itsMovingBackward)
            {
                target.Velocity.y -= 1;
            }

            target.Velocity = target.Velocity.Normalized() * target.Speed;
            return StatesIndex.MoveForward;
        }
    }
}
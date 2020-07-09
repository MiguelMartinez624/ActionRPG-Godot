using ActionRPG.Core.Components;
using Godot;

namespace ActionRPG.Core.StateMachine
{
    public abstract class MovingForward : IState<MovementComponent>
    {
        public StatesIndex Code => StatesIndex.MoveForward;
        public ComponentIndex ComponentCode => ComponentIndex.Movement;

        
        
        public void OnEnter(MovementComponent components, float deltaTime)
        {
        }

        public StatesIndex Execute(MovementComponent components, float deltaTime)
        {
            components.Velocity = new Vector2();
            var (itsMovingForward, itsMovingLeft, itsMovingRight, itsMovingBackward) = components;
            // Cancelation
            if (!itsMovingForward && !itsMovingLeft && itsMovingRight && itsMovingBackward)
            {
                return StatesIndex.Idle;
            }

            if (itsMovingLeft)
            {
                components.Velocity.x -= 1;
            }

            if (itsMovingRight)
            {
                components.Velocity.x += 1;
            }

            if (itsMovingForward)
                components.Velocity.y += 1;

            if (itsMovingBackward)
            {
                components.Velocity.y -= 1;
            }

           
            return this.Code;
        }


        public void OnLeave(MovementComponent components, float deltaTime)
        {
        }
    }
}
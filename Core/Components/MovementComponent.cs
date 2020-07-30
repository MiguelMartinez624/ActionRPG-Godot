using Godot;

namespace ActionRPG.Core.Components
{
    public class MovementComponent : IComponent
    {
        public MovementComponent(int speed)
        {
            Speed = speed;
        }

        public readonly int Speed;
        public Vector3 Velocity;
        public ComponentIndex Code => ComponentIndex.Movement;

        // 
        public bool ItsMovingForward = false;
        public bool ItsMovingBackward = false;
        public bool ItsMovingRight = false;
        public bool ItsMovingLeft = false;

        public void Restart()
        {
            this.Velocity = Vector3.Zero;
            ItsMovingForward = false;
            ItsMovingBackward = false;
            ItsMovingRight = false;
            ItsMovingLeft = false;
        }

        public void Deconstruct(out bool itsMovingForward, out bool itsMovingBackward, out bool itsMovingLeft,
            out bool itsMovingRight)
        {
            itsMovingBackward = this.ItsMovingBackward;
            itsMovingForward = this.ItsMovingForward;
            itsMovingLeft = this.ItsMovingLeft;
            itsMovingRight = this.ItsMovingRight;
        }
    }
}
namespace ActionRPG
{
    // PlayerState holds the internal player entity state
    public class PlayerState
    {
        public bool ItsMovingForward { get; private set; } = false;
        public bool ItsAttacking { get; private set; } = false;
    }
}
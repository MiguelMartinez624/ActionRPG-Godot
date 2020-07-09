using ActionRPG.Core.Components;
using Godot.Collections;

namespace ActionRPG.Core.StateMachine
{
    public class StatesRegister
    {
        static private Dictionary<StatesIndex, IState<dynamic>> _state =
            new Dictionary<StatesIndex, IState<dynamic>>()
            {
                {StatesIndex.MoveForward, new MovementComponent() as IState<dynamic>}
            };

        static public IState<dynamic> GetStateByIndex(StatesIndex index)
        {
            return StatesRegister._state[index];
        }
    }
}
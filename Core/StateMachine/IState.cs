using ActionRPG.Core.Components;

namespace ActionRPG.Core.StateMachine
{
 

    public interface IState<T>
    {
        StatesIndex Code { get; }
        void OnEnter(T target, float deltaTime);
        StatesIndex Execute(T target, float deltaTime);
        void OnLeave(T target, float deltaTime);
    }
}
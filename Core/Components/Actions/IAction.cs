using ActionRPG.Core.StateMachine;

namespace ActionRPG.Core.Components
{
    public interface IAction<IComponent>
    {
        StatesIndex Execute(IComponent target, float deltaTime);
    }

    public interface IInteractionAction<T>
    {
        void Execute(InteractionData<T> data);
    }
}
using System.Collections.Generic;
using ActionRPG.Core.Components;


namespace ActionRPG.Core.StateMachine
{
    public class StateMachine<T>
    {
        public IState<T> CurrentState;
        public StatesIndex DefaultStateIndex = StatesIndex.Idle;
        private Dictionary<StatesIndex, IState<T>> _states;

        private T _target;

        public StateMachine(T target, StatesIndex defaultState)
        {
            this._target = target;
            this._states = new Dictionary<StatesIndex, IState<T>>();
        }

        // crear interfaces para hacer Imovable que necesitara implementar la
        public void Update(float deltaTime)
        {
            if (this.CurrentState == null)
            {
                var defaultState = this._states[this.DefaultStateIndex];
                if (defaultState != null)
                {
                    this.CurrentState = defaultState;
                }
            }

            if (this.CurrentState != null)
            {
                var newStateIndex = this.CurrentState.Execute(this._target, deltaTime);
                if (newStateIndex != this.CurrentState.Code)
                {
                    var newState = this._states[newStateIndex];
                    this.CurrentState.OnLeave(this._target, deltaTime);
                    this.CurrentState = newState;
                    this.CurrentState.OnEnter(this._target, deltaTime);
                }
            }
        }

        public StateMachine<T> AddState(IState<T> state)
        {
            this._states.Add(state.Code, state);
            return this;
        }
    }
}
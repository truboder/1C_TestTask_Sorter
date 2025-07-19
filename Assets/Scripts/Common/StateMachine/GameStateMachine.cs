using System;
using System.Collections.Generic;

namespace Common.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, BaseState> _states = new();
        private BaseState _currentState;
        
        public event Action<Type> OnStateChanged;

        public void AddState(BaseState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void Enter<TState>() where TState : BaseState
        {
            if (_currentState?.GetType() == typeof(TState))
            {
                return;
            }

            if (!_states.TryGetValue(typeof(TState), out BaseState state))
            {
                return;
            }
            
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
            OnStateChanged?.Invoke(typeof(TState));
        }

        public void Update()
        {
            _currentState?.Update();
        }

        public void Dispose()
        {
            _currentState?.Exit();
            _states.Clear();
        }
    }
}
using System;

namespace Common.StateMachine
{
    public interface IGameStateMachine : IDisposable
    {
        void AddState(BaseState state);
        void Enter<TState>() where TState : BaseState;
        void Update();
        event Action<Type> OnStateChanged;
    }
}
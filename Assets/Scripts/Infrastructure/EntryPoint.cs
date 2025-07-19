using Common.StateMachine;
using Infrastructure.StateMachine.States;

namespace Infrastructure
{
    public class EntryPoint
    {
        private readonly IGameStateMachine _gameStateMachine;

        public EntryPoint(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Initialize()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}
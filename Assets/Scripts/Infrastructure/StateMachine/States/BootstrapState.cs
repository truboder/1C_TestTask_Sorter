using Common.StateMachine;

namespace Infrastructure.StateMachine.States
{
    public class BootstrapState : BaseState
    {
        public BootstrapState(IGameStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            StateMachine.Enter<MainMenuState>();
        }

        public override void Update() { }

        public override void Exit() { }
    }
}
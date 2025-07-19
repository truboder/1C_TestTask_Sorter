using Common.StateMachine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.States
{
    public class WinState : BaseState
    {
        public WinState(IGameStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            if (SceneManager.GetActiveScene().name != "WinScene")
            {
                SceneManager.LoadScene("WinScene");
            }
        }
        
        public override void Update() { }

        public override void Exit() { }
    }
}
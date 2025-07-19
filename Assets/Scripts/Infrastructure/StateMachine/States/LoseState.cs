using Common.StateMachine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.States
{
    public class LoseState : BaseState
    {
        public LoseState(IGameStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            if (SceneManager.GetActiveScene().name != "LoseScene")
            {
                SceneManager.LoadScene("LoseScene");
            }
        }

        public override void Update() { }

        public override void Exit() { }
    }
}
using Common.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.States
{
    public class BootstrapState : BaseState
    {
        public BootstrapState(IGameStateMachine stateMachine) : base(stateMachine)
        {
            Debug.Log("BootstrapState constructed.");
        }

        public override void Enter()
        {
            if (SceneManager.GetActiveScene().name != "MainMenuScene")
            {
                SceneManager.LoadScene("MainMenuScene");
            }
            StateMachine.Enter<MainMenuState>();
        }

        public override void Update() { }

        public override void Exit() { }
    }
}
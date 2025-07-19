using UnityEngine;

namespace Common.StateMachine
{
    public abstract class BaseState : MonoBehaviour
    {
        protected readonly IGameStateMachine StateMachine;

        protected BaseState(IGameStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
        
        public abstract void Enter();
        public abstract void Update();
        
        public abstract void Exit();
    }
}


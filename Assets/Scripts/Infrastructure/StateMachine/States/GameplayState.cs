using Common.StateMachine;
using Gameplay.Health;
using Gameplay.Scoring;
using Gameplay.Shapes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.States
{
    public class GameplayState : BaseState
    {
        private readonly HealthService _healthService;
        private readonly ScoreService _scoreService;
        private readonly SpawnSystem _spawnSystem;

        public GameplayState(IGameStateMachine stateMachine, HealthService healthService, ScoreService scoreService, SpawnSystem spawnSystem)
            : base(stateMachine)
        {
            _healthService = healthService;
            _scoreService = scoreService;
            _spawnSystem = spawnSystem;
        }
        
        public override void Enter()
        {
            if (SceneManager.GetActiveScene().name != "GameplayScene")
            {
                SceneManager.LoadScene("GameplayScene");
            }
            
            _healthService.Reset();
            _scoreService.Reset();
            _spawnSystem.Initialize();
        }

        public override void Update() { }

        public override void Exit() { }
    }
}
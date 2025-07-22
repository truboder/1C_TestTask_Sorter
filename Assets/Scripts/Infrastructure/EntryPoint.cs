using Common.StateMachine;
using Gameplay.Health;
using Gameplay.Scoring;
using Gameplay.Shapes;
using Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class EntryPoint : IInitializable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly HealthService _healthService;
        private readonly ScoreService _scoreService;
        private readonly SpawnSystem _spawnSystem;

        public EntryPoint(IGameStateMachine gameStateMachine, HealthService healthService, ScoreService scoreService, SpawnSystem spawnSystem)
        {
            Debug.Log("EntryPoint constructed. Checking dependencies...");
            if (gameStateMachine == null) Debug.LogError("IGameStateMachine is null.");
            if (healthService == null) Debug.LogError("HealthService is null.");
            if (scoreService == null) Debug.LogError("ScoreService is null.");
            if (spawnSystem == null) Debug.LogError("SpawnSystem is null.");
            _gameStateMachine = gameStateMachine;
            _healthService = healthService;
            _scoreService = scoreService;
            _spawnSystem = spawnSystem;
        }

        public void Initialize()
        {
            _gameStateMachine.AddState(new MainMenuState(_gameStateMachine));
            _gameStateMachine.AddState(new GameplayState(_gameStateMachine, _healthService, _scoreService, _spawnSystem));
            _gameStateMachine.AddState(new WinState(_gameStateMachine));
            _gameStateMachine.AddState(new LoseState(_gameStateMachine));
            Debug.Log("Entering BootstrapState...");
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}
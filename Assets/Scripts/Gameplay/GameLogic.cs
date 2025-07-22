using Common.Events;
using Common.StateMachine;
using Gameplay.Health;
using Gameplay.Scoring;
using Gameplay.Shapes;
using Gameplay.Shapes.Factory;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameLogic : IInitializable
    {
        private readonly EventBus _eventBus;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly HealthService _healthService;
        private readonly ScoreService _scoreService;
        private readonly ShapeFactory _shapeFactory;

        public GameLogic(EventBus eventBus, IGameStateMachine gameStateMachine, HealthService healthService, ScoreService scoreService, ShapeFactory shapeFactory)
        {
            _eventBus = eventBus;
            _gameStateMachine = gameStateMachine;
            _healthService = healthService;
            _scoreService = scoreService;
            _shapeFactory = shapeFactory;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<ShapeSortedCorrectlyEvent>(OnShapeSortedCorrectly);
            _eventBus.Subscribe<ShapeSortedIncorrectlyEvent>(OnShapeSortedIncorrectly);
            _eventBus.Subscribe<ShapeMissedEvent>(OnShapeMissed);
            _eventBus.Subscribe<PlayerDefeatedEvent>(OnPlayerDefeated);
            _eventBus.Subscribe<AllShapesProcessedEvent>(OnAllShapesProcessed);
        }

        private void OnShapeSortedCorrectly(ShapeSortedCorrectlyEvent evt)
        {
            _scoreService.AddScore(1);
            _shapeFactory.Return(evt.Shape);
        }

        private void OnShapeSortedIncorrectly(ShapeSortedIncorrectlyEvent evt)
        {
            _healthService.TakeDamage(1);
            _shapeFactory.Return(evt.Shape);
        }

        private void OnShapeMissed(ShapeMissedEvent evt)
        {
            _healthService.TakeDamage(1);
            _shapeFactory.Return(evt.Shape);
        }

        private void OnPlayerDefeated(PlayerDefeatedEvent evt)
        {
            _gameStateMachine.Enter<LoseState>();
        }

        private void OnAllShapesProcessed(AllShapesProcessedEvent evt)
        {
            if (_healthService.IsAlive)
            {
                _gameStateMachine.Enter<WinState>();
            }
        }
    }
}
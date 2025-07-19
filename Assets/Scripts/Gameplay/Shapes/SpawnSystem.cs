using System.Collections;
using Common.Corountines;
using Common.Events;
using Cysharp.Threading.Tasks;
using Gameplay.Shapes.Factory;
using Gameplay.StaticData;
using UnityEngine;
using Zenject;

namespace Gameplay.Shapes
{
    public class SpawnSystem : IInitializable
    {
        private readonly GameSettings _settings;
        private readonly ICoroutineRunService _coroutineRunner;
        private readonly IShapeFactory _shapeFactory;
        private readonly EventBus _eventBus;
        private int _shapesToSpawn;
        private int _spawnedCount;
        
        public SpawnSystem(GameSettings settings, ICoroutineRunService coroutineRunner, IShapeFactory shapeFactory, EventBus eventBus)
        {
            _settings = settings;
            _coroutineRunner = coroutineRunner;
            _shapeFactory = shapeFactory;
            _eventBus = eventBus;
        }
        
        public void Initialize()
        {
            _shapesToSpawn = (int)Random.Range(_settings.ShapesCountRange.Min, _settings.ShapesCountRange.Max);
            _spawnedCount = 0;
            _eventBus.Subscribe<ShapeSortedCorrectlyEvent>(OnShapeSorted);
            _eventBus.Subscribe<ShapeSortedIncorrectlyEvent>(OnShapeSorted);
            _eventBus.Subscribe<ShapeMissedEvent>(OnShapeMissed);
            _coroutineRunner.StartCoroutine(SpawnShapes());
        }
        
        private IEnumerator SpawnShapes()
        {
            Vector3[] lanePositions = { new Vector3(-8f, 2f, 0f), new Vector3(-8f, 0f, 0f), new Vector3(-8f, -2f, 0f) };

            while (_spawnedCount < _shapesToSpawn)
            {
                ShapeType type = (ShapeType)Random.Range(0, 4);
                float speed = Random.Range(_settings.ShapeSpeedRange.Min, _settings.ShapeSpeedRange.Max);
                int lane = Random.Range(0, 3);
                
                _shapeFactory.Create(type, lanePositions[lane], speed);
                _spawnedCount++;
                
                yield return new WaitForSeconds(Random.Range(_settings.SpawnTimeoutRange.Min, _settings.SpawnTimeoutRange.Max));
            }
        }
        
        private void OnShapeSorted(ShapeSortedCorrectlyEvent evt)
        {
            CheckWinCondition();
        }

        private void OnShapeSorted(ShapeSortedIncorrectlyEvent evt)
        {
            CheckWinCondition();
        }

        private void OnShapeMissed(ShapeMissedEvent evt)
        {
            CheckWinCondition();
        }

        private void CheckWinCondition()
        {
            if (_spawnedCount >= _shapesToSpawn)
            {
                _eventBus.Publish(new AllShapesProcessedEvent());
            }
        }
    }
}
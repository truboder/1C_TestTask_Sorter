using Common.Corountines;
using Common.Events;
using Gameplay.Health;
using Gameplay.Inputs;
using Gameplay.Scoring;
using Gameplay.Shapes;
using Gameplay.Shapes.Factory;
using Gameplay.StaticData;
using Gameplay.UI;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameplayLevelInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private Shape _shapePrefab;
        [SerializeField] private HealthUI _healthUI;
        [SerializeField] private ScoreUI _scoreUI;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EventBus>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CoroutineRunService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameSettings>().FromInstance(_gameSettings).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HealthService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ScoreService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ShapeFactory>().AsSingle().WithArguments(_shapePrefab).NonLazy();
            Container.BindInterfacesAndSelfTo<SpawnSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HealthUI>().FromInstance(_healthUI).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ScoreUI>().FromInstance(_scoreUI).AsSingle().NonLazy();
        }
    }
}
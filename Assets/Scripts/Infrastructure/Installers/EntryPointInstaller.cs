using Common.Coroutines;
using Common.Events;
using Common.StateMachine;
using Gameplay.Health;
using Gameplay.Scoring;
using Gameplay.Shapes;
using Gameplay.Shapes.Factory;
using Gameplay.StaticData;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class EntryPointInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private Shape _shapePrefab;
        
        public override void InstallBindings()
        {
            Debug.Log("EntryPointInstaller is running.");
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EventBus>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CoroutineRunService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameSettings>().FromInstance(_gameSettings).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HealthService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ScoreService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ShapeFactory>().AsSingle().WithArguments(_shapePrefab).NonLazy();
            Container.BindInterfacesAndSelfTo<SpawnSystem>().AsSingle().NonLazy();
        }
    }
}
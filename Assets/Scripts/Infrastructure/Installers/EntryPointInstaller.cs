using Common.StateMachine;
using Gameplay.Health;
using Gameplay.Scoring;
using Gameplay.Shapes;
using Infrastructure.StateMachine.States;
using Zenject;

namespace Infrastructure.Installers
{
    public class EntryPointInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle().NonLazy();

            var gameStateMachine = Container.Resolve<IGameStateMachine>();
            gameStateMachine.AddState(new BootstrapState(gameStateMachine));
            gameStateMachine.AddState(new MainMenuState(gameStateMachine));
            gameStateMachine.AddState(new GameplayState(gameStateMachine, Container.Resolve<HealthService>(), Container.Resolve<ScoreService>(), Container.Resolve<SpawnSystem>()));
            gameStateMachine.AddState(new WinState(gameStateMachine));
            gameStateMachine.AddState(new LoseState(gameStateMachine));
        }
    }
}
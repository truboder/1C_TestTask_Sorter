using Gameplay;
using Gameplay.Inputs;
using Gameplay.UI;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameplayLevelInstaller : MonoInstaller
    {
        [SerializeField] private HealthUI _healthUI;
        [SerializeField] private ScoreUI _scoreUI;

        public override void InstallBindings()
        {
            
            Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HealthUI>().FromInstance(_healthUI).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ScoreUI>().FromInstance(_scoreUI).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameLogic>().AsSingle().NonLazy();
        }
    }
}
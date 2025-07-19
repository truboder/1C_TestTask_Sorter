using Gameplay.UI;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class WinSceneInstaller : MonoInstaller
    {
        [SerializeField] private WinUI _winUI;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WinUI>().FromInstance(_winUI).AsSingle().NonLazy();
        }
    }
}
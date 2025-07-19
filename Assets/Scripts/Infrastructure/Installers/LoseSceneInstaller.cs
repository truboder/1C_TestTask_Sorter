using Gameplay.UI;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class LoseSceneInstaller : MonoInstaller
    {
        [SerializeField] private LoseUI _loseUI;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LoseUI>().FromInstance(_loseUI).AsSingle().NonLazy();
        }
    }
}
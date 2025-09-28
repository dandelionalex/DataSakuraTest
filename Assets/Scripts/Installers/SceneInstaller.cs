using UnityEngine;
using Zenject;
using Zoo.Config;
using Zoo.Signals;

namespace Zoo.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] GameConfig _gameConfig;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.BindInstance(_gameConfig).AsSingle();
            Container.Bind<AnimalFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle();

            Container.DeclareSignal<AnimalDiedSignal>();
            Container.DeclareSignal<ScoresUpdatedSignal>();
        }
    }
}

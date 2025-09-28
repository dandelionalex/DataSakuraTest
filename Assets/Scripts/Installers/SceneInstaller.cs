using UnityEngine;
using Zenject;
using Zoo.Config;
using Zoo.Signals;
using Zoo.Factories;

namespace Zoo.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] GameConfig     _gameConfig;
        [SerializeField] PrefabsConfig  _prefabConfig;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.BindInstance( _gameConfig ).AsSingle();
            Container.BindInstance( _prefabConfig ).AsSingle();

            Container.Bind<AnimalFactory>().AsSingle();
            Container.Bind<UIInWorldFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle();

            Container.DeclareSignal<AnimalDiedSignal>();
            Container.DeclareSignal<ScoresUpdatedSignal>();
        }
    }
}

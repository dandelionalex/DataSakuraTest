using UnityEngine;
using Zenject;
using Zoo.Config;

namespace Zoo.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameConfig _gameConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_gameConfig).AsSingle();
            Container.Bind<AnimalFactory>().AsSingle();
            //UI
        }
    }
}

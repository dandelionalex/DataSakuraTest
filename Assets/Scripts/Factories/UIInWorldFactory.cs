using UnityEngine;
using Zenject;
using Zoo.Config;

namespace Zoo.Factories
{
    public sealed class UIInWorldFactory
    {
        DiContainer _container;
        PrefabsConfig _prefabsConfig;

        public UIInWorldFactory( DiContainer container, PrefabsConfig prefabsConfig )
        {
            _container      = container;
            _prefabsConfig  = prefabsConfig;
        }

        public GameObject Spawn( Vector3 position, Transform parent )
        {
            var view = _container.InstantiatePrefab( _prefabsConfig.TastyPrefab, position, Quaternion.identity, parent );

            return view;
        }
    }
}
using UnityEngine;
using Zenject;
using Zoo.Config;
using Zoo.View;

namespace Zoo
{
    public sealed class AnimalFactory
    {
        private DiContainer _container;

        public AnimalFactory(DiContainer container)
        {
            _container = container;
        }

        public AnimalPresenter Spawn(AnimalConfig animalConfig, Vector3 position, Transform parent)
        {
            var view = _container.InstantiatePrefab(animalConfig.prefab, position, Quaternion.identity, parent);
            var animalView = view.GetComponent<AnimalView>();

            if (animalView == null)
            {
                throw new System.Exception("an AnimalView script must be attached to animal prefab");
            }

            var animalPresenter = new AnimalPresenter
            {
                AnimalView = animalView,
                MovementBehaviour = animalConfig.MovementBehaviour

            };

            return animalPresenter;
        }
    }
}
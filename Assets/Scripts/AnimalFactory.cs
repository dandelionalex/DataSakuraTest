using UnityEngine;
using Zenject;
using Zoo.Config;
using Zoo.View;

namespace Zoo
{
    public class AnimalFactory
    {
        private DiContainer _container;

        public AnimalFactory(DiContainer container)
        {
            _container = container;
        }

        public AnimalPresenter Spawn(AnimalConfig animalConfig, Vector3 position)
        {
            var view = _container.InstantiatePrefab(animalConfig.prefab);
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
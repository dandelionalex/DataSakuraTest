using UnityEngine;
using Zenject;
using Zoo.Config;
using Zoo.View;

namespace Zoo.Factories
{
    public sealed class AnimalFactory
    {
        DiContainer _container;

        public AnimalFactory(DiContainer container)
        {
            _container = container;
        }

        public IAnimalPresenter Spawn(AnimalConfig animalConfig, Vector3 position, Transform parent)
        {
            var view = _container.InstantiatePrefab(animalConfig.prefab, position, Quaternion.identity, parent);
            var animalView = view.GetComponent<AnimalView>();

            if (animalView == null)
            {
                throw new System.Exception("an AnimalView script must be attached to animal prefab");
            }

            var animalPresenter = new AnimalPresenter(animalView, animalConfig.MovementBehaviour, animalConfig.animalType);
            animalView.AnimalPresenter = animalPresenter;

            return animalPresenter;
        }
    }
}
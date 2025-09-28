using System;
using UnityEngine;
using Zoo.Config;
using Zoo.Enums;
using Zoo.View;

namespace Zoo
{
    public interface IAnimalPresenter
    {
        bool IsDied { get; }
        AnimalType AnimalType { get; }
        Action<IAnimalPresenter> OnDie { get; set; }
        Transform AnimalTransform { get; }
        void StartMove();
        void PlayAnimation(string key);
        void Die();
    }

    public sealed class AnimalPresenter : IAnimalPresenter, IDisposable
    {
        const string DIE_ANIMATION = "die";
        public AnimalView AnimalView { get; }
        public BaseMovement MovementBehaviour { get; }
        public AnimalType AnimalType { get; }

        public bool IsDied { get; private set; }

        public Transform AnimalTransform => AnimalView.transform;

        public Action<IAnimalPresenter> OnDie { get; set; }

        public AnimalPresenter(AnimalView animalView, BaseMovement movementBehaviour, AnimalType animalType)
        {
            AnimalView = animalView;
            AnimalType = animalType;

            AnimalView.OnCollideWithSomething += OnCollision;
            MovementBehaviour = movementBehaviour;
        }

        public void Dispose()
        {
            AnimalView.OnCollideWithSomething -= OnCollision;
        }

        public void PlayAnimation(string key)
        {
            AnimalView.PlayAnimation(key);
        }

        public void StartMove()
        {
            MovementBehaviour.StartMove(this, AnimalView);
        }

        void OnCollision(Collision other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Animal"))
                return;

            if (IsDied)
                return;

            var otherAnimal = other.gameObject.GetComponent<AnimalView>();
            var otherType = otherAnimal.AnimalPresenter.AnimalType;

            if (AnimalType == AnimalType.Prey && AnimalType == otherType)
            {
                otherAnimal.AnimalPresenter.Die();
                Die();
            }
            else if (AnimalType == AnimalType.Predator && otherType == AnimalType.Prey)
            {
                otherAnimal.AnimalPresenter.Die();
            }
            else if (AnimalType == AnimalType.Predator && AnimalType == otherType )
            {
                if (!otherAnimal.AnimalPresenter.IsDied)
                    otherAnimal.AnimalPresenter.Die();
            }
        }

        public void Die()
        {
            if (IsDied)
                return;

            IsDied = true;
            OnDie?.Invoke(this);
            //AnimalView.PlayAnimation(DIE_ANIMATION); //TODO: add callback to animation and kill after
            GameObject.Destroy(AnimalView.gameObject);
        }
    }
}
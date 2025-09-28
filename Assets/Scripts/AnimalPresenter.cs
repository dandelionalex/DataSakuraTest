using System;
using UnityEngine;
using Zoo.Config;
using Zoo.View;

namespace Zoo
{
    public interface IAnimalPresenter
    {
        bool IsDied { get; }
        Action<IAnimalPresenter> Die { get; set; }
        Transform AnimalTransform { get; }
        void StartMove();
        void PlayAnimation(string key);
    }

    public sealed class AnimalPresenter : IAnimalPresenter, IDisposable
    {
        public AnimalView AnimalView { get; }
        public BaseMovement MovementBehaviour { get; }

        public bool IsDied => false;

        public Transform AnimalTransform => AnimalView.transform;

        public Action<IAnimalPresenter> Die { get; set; }

        public AnimalPresenter(AnimalView animalView, BaseMovement movementBehaviour)
        {
            AnimalView = animalView;
            AnimalView.OnCollideWithSomething += OnCollision;
            MovementBehaviour = movementBehaviour;
            
        }

        private void OnCollision(Collision other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Animal"))
                return;

            Debug.Log("dead");

            Die?.Invoke(this);
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


    }
}
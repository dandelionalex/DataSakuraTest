using UnityEngine;
using Zoo.Config;
using Zoo.View;

namespace Zoo
{
    public interface IAnimalPresenter
    {
        bool IsDied { get; }
        Transform AnimalTransform { get; }
        void StartMove();
        void PlayAnimation(string key);
    }

    public class AnimalPresenter : IAnimalPresenter
    {
        public AnimalView AnimalView;
        public BaseMovement MovementBehaviour;

        public bool IsDied => false;

        public Transform AnimalTransform => AnimalView.transform;

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
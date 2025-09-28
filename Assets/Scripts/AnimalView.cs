using System;
using UnityEngine;

namespace Zoo.View
{
    public interface IAnimalView
    {
        Action<Collision> OnCollideWithSomething { get; set; }
        void PlayAnimation(string key);
        IAnimalPresenter AnimalPresenter { get; set; }
    }

    [RequireComponent(typeof(Animator))]
    public sealed class AnimalView : MonoBehaviour, IAnimalView
    {
        [SerializeField] Animator _animator;

        public Action<Collision> OnCollideWithSomething { get; set; }
        public IAnimalPresenter AnimalPresenter { get; set; }

        void OnCollisionEnter(Collision collision)
        {
            OnCollideWithSomething?.Invoke(collision);
        }

        public void PlayAnimation(string key)
        {
            _animator.SetTrigger(key);
        }
    }
}
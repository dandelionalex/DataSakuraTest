using System;
using UnityEngine;

namespace Zoo.View
{
    public interface IAnimalView
    {
        Action<Collider> OnCollideWithSomething { get; }
        void PlayAnimation(string key);
    }

    [RequireComponent(typeof(Animator))]
    public class AnimalView : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        public Action<Collider> OnCollideWithSomething { get; }

        void OnTggerEnter(Collider other)
        {
            Debug.Log($"OnTriggerEnter {other.gameObject.name}");
            OnCollideWithSomething?.Invoke(other);
        }

        public void PlayAnimation(string key)
        {
            _animator.SetTrigger(key);
        }
    }
}
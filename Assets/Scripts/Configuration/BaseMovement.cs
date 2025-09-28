using UnityEngine;

namespace Zoo.Config
{
    public abstract class BaseMovement : ScriptableObject
    {
        protected Vector3[] directions = new Vector3[]
        {
            Vector3.forward,
            Vector3.right,
            Vector3.back,
            Vector3.left
        };

        public virtual void StartMove(IAnimalPresenter target, MonoBehaviour context)
        {

        }

        public virtual void StopMove()
        {
            
        }
    }
}
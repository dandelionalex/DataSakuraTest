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

        protected void AdjustRotation(Transform transform, Vector3 direction)
        {
            var rot = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = rot;
        }

        protected Vector3 GetNextRandomTarget()
        {
            var i = Random.Range(0, directions.Length);
            return directions[i];
        }
    }
}
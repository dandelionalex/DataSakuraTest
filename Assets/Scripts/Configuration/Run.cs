using System.Collections;
using UnityEngine;

namespace Zoo.Config
{
    [CreateAssetMenu(fileName = "Run", menuName = "Zoo/RunBehaviour")]
    public class Run : BaseMovement
    {
        private const string RUN = "run";
        [SerializeField] private float _speed;

        public override void StartMove(IAnimalPresenter target, MonoBehaviour context)
        {
            base.StartMove(target, context);
            target.PlayAnimation(RUN);
            context.StartCoroutine(RunRoutine(target, context));
        }

        IEnumerator RunRoutine(IAnimalPresenter target, MonoBehaviour context)
        {
            var transform = target.AnimalTransform;
            var currentDirection = GetNextRandomTarget();
            
            AdjustRotation(transform, currentDirection);

            while (!target.IsDied)
            {
                yield return null;

                if (Physics.Raycast(transform.position, currentDirection, 1.2f))
                {
                    currentDirection *= -1;
                    AdjustRotation(transform, currentDirection);
                }

                transform.position += currentDirection * _speed;
            }
        }

        private Vector3 GetNextRandomTarget()
        {
            var i = Random.Range(0, directions.Length);
            return directions[i];
        }

        private void AdjustRotation(Transform transform, Vector3 direction)
        {
            var rot = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = rot;
        }
    }
}
using System.Collections;
using UnityEngine;

namespace Zoo.Config
{
    [CreateAssetMenu(fileName = "Run", menuName = "Zoo/RunBehaviour")]
    public class Run : BaseMovement
    {
        const string RUN = "run";
        [SerializeField] float _speed;

        public override void StartMove( IAnimalPresenter target, MonoBehaviour context )
        {
            base.StartMove(target, context);
            target.PlayAnimation(RUN);
            context.StartCoroutine( RunRoutine( target, context ) );
        }

        IEnumerator RunRoutine( IAnimalPresenter target, MonoBehaviour context )
        {
            var transform = target.AnimalTransform;
            var currentDirection = GetNextRandomTarget();
            
            AdjustRotation( transform, currentDirection );

            while (!target.IsDied)
            {
                yield return null;
                var mask           = LayerMask.GetMask("Wall");

                if ( Physics.Raycast(transform.position, currentDirection, 1.2f, mask) )
                {
                    currentDirection *= -1;
                    AdjustRotation(transform, currentDirection);
                }

                transform.position += currentDirection * _speed;
            }
        }
    }
}
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Zoo.Config
{
    [CreateAssetMenu(fileName = "Jump", menuName = "Zoo/JumpBehaviour")]
    public class Jump : BaseMovement
    {
        const string JUMP = "jump";

        [SerializeField] float _delay;
        [SerializeField] float _distance;
        [SerializeField] float _jumpHight;

        public override void StartMove(IAnimalPresenter target, MonoBehaviour context)
        {
            base.StartMove(target, context);
            context.StartCoroutine(JumpRoutine(target, context));
        }

        IEnumerator JumpRoutine(IAnimalPresenter target, MonoBehaviour context)
        {
            Sequence doTweenSequence = null;
            var transform = target.AnimalTransform;

            while (!target.IsDied)
            {
                yield return new WaitForSeconds(_delay);

                var currentDirection    = GetNextRandomTarget();
                var mask                = LayerMask.GetMask("Wall");

                if (Physics.Raycast(transform.position, currentDirection, _distance, mask))
                {
                    currentDirection *= -1;
                }

                AdjustRotation(transform, currentDirection);
                var jumpTarget = transform.position + currentDirection * _distance;

                doTweenSequence?.Kill();

                target.PlayAnimation(JUMP);
                doTweenSequence = transform
                    .DOJump(jumpTarget, _jumpHight, 1, 1)
                    .SetLink(context.gameObject);
            }
        }
    }
}
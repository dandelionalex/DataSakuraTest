using System.Collections;
using UnityEngine;

namespace Zoo.UI
{
    public class AutoDestroy : MonoBehaviour
    {
        [SerializeField] int _timeToDestroy;

        void Start()
        {
            StartCoroutine( DestroyRoutine() );
        }

        IEnumerator DestroyRoutine()
        {
            yield return new WaitForSeconds( _timeToDestroy );
            Destroy( gameObject );
        }
    }
}
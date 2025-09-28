using TMPro;
using UnityEngine;
using Zenject;

namespace Zoo.UI
{
    public class ScoresPanel : MonoBehaviour
    {
        [SerializeField] TMP_Text PreysDied;
        [SerializeField] TMP_Text PredatorsDied;

        const string PREYS_TEXT = "";
        const string PREDATORS_TEXT = "";

        [Inject] SignalBus signalBus;

        void Onable()
        {
            
        }

        void OnDisable()
        {
            
        }

        
    }
}


using TMPro;
using UnityEngine;
using Zenject;
using Zoo.Signals;

namespace Zoo.UI
{
    public class ScoresPanel : MonoBehaviour
    {
        [SerializeField] TMP_Text PreysDied;
        [SerializeField] TMP_Text PredatorsDied;

        const string PREYS_TEXT = "Prey died:";
        const string PREDATORS_TEXT = "Predators died:";

        [Inject] SignalBus _signalBus;

        void OnEnable()
        {
            _signalBus.Subscribe<ScoresUpdatedSignal>( ScoreUpdatedSignal );
        }

        void OnDisable()
        {
            _signalBus.Unsubscribe<ScoresUpdatedSignal>( ScoreUpdatedSignal );
        }

        void ScoreUpdatedSignal( ScoresUpdatedSignal signal )
        {
            PreysDied.text      = $"{PREYS_TEXT} {signal.PreysDied}";
            PredatorsDied.text  = $"{PREDATORS_TEXT} {signal.PredatorsDied}";
        }
    }
}


using System;
using Zenject;
using Zoo.Signals;

namespace Zoo
{
    public class GameController : IInitializable, IDisposable
    {
        [Inject] SignalBus _signalBus;

        public int TotalPreyDeath;
        public int TotalPredatorsDeath;

        public void Initialize()
        {
            _signalBus.Subscribe<AnimalDiedSignal>( OnAnimalDead );
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<AnimalDiedSignal>( OnAnimalDead );
        }

        void OnAnimalDead( AnimalDiedSignal aniaml )
        {
            switch (aniaml.AnimalType)
            {
                case Enums.AnimalType.Prey:
                    TotalPreyDeath++;
                    break;
                case Enums.AnimalType.Predator:
                    TotalPredatorsDeath++;
                    break;
            }

            UnityEngine.Debug.Log( $"OnAnimalDead, TotalPreyDeath: {TotalPreyDeath}, TotalPredatorsDeath {TotalPredatorsDeath}" );
            _signalBus.Fire( new ScoresUpdatedSignal( TotalPreyDeath, TotalPredatorsDeath ));
        }
    }
}
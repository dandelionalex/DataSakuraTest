using Zoo.Enums;

namespace Zoo.Signals
{
    public class AnimalDiedSignal
    {
        public AnimalType AnimalType { get;}

        public AnimalDiedSignal(AnimalType animalType)
        {
            AnimalType = animalType;
        }
    }
}


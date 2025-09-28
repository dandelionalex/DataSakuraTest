using UnityEngine;
using Zoo.Enums;

namespace Zoo.Config
{
    [CreateAssetMenu(fileName = "Animal", menuName = "Zoo/Animal")]
    public class AnimalConfig : ScriptableObject
    {
        public AnimalType animalType;
        public GameObject prefab;
        public BaseMovement MovementBehaviour;
    }
}
using UnityEngine;

namespace Zoo.Config
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Zoo/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        public Vector2 mapSize;

        public float minDelayBeforeSpawn;
        public float maxDelayBeforeSpawn;

        public AnimalConfig[] animals;
    }
}
using UnityEngine;

namespace Zoo.Config
{
    [CreateAssetMenu(fileName = "PrefabsConfig", menuName = "Zoo/PrefabsConfig")]
    public class PrefabsConfig : ScriptableObject
    {
        public GameObject TastyPrefab;
    }
}
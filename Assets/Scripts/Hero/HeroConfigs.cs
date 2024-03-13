using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Create HeroConfigs", fileName = "HeroConfigs")]
    public sealed class HeroConfigs : ScriptableObject
    {
        [field: SerializeField]
        public HeroConfig[] Heroes { get; private set; }
    }
}
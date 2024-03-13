using Game.Effects;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Create Ability", fileName = "NewAbility")]
    public class Ability : ScriptableObject
    {
        [SerializeReference] public IEffect Effect;
    }
}
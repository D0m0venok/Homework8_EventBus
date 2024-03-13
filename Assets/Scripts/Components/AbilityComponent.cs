using UnityEngine;

namespace Game
{
    public sealed class AbilityComponent
    {
        private readonly AudioClip[] _abilityClips;
        
        public Ability Ability { get; }
        
        public AbilityComponent(Ability ability, AudioClip[] abilityClips)
        {
            _abilityClips = abilityClips;
            Ability = ability;
        }

        public void PlaySoundAbility()
        {
            if (_abilityClips.Length > 0)
                AudioPlayer.Instance.PlaySound(_abilityClips[Random.Range(0, _abilityClips.Length)]);
        }
    }
}
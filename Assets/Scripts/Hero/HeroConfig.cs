using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class HeroConfig
    {
        [field: SerializeField]
        public int Health { get; private set; }
        [field: SerializeField]
        public int Damage { get; private set; }
        [field: SerializeField]
        public Sprite Sprite { get; private set; }
        [field: SerializeField]
        public Ability Ability { get; private set; }
        [field: SerializeField]
        public AudioClip[] StartTurnClips { get; private set; } 
        [field: SerializeField]
        public AudioClip LowHealthClip { get; private set; }
        [field: SerializeField]
        public AudioClip DeathClip { get; private set; }
        [field: SerializeField]
        public AudioClip[] AbilityClips { get; private set; }
    }
}
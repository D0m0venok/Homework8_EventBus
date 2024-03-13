using System;
using UnityEngine;

namespace Game.Effects
{
    [Serializable]
    public struct DamageEffect : IEffect
    {
        [field: SerializeField]
        public int Damage { get; private set; }
    }
}
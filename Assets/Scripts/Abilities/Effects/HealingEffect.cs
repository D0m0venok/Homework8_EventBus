using System;
using UnityEngine;

namespace Game.Effects
{
    [Serializable]
    public struct HealingEffect : IEffect
    {
        [field: SerializeField]
        public int Health { get; private set; }
    }
}
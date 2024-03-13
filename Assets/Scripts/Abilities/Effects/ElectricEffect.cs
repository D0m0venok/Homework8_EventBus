using System;
using UnityEngine;

namespace Game.Effects
{
    [Serializable]
    public struct ElectricEffect : IEffect
    {
        [field: SerializeField]
        public int Damage { get; private set; }
    }
}
using System;
using UnityEngine;

namespace Game.Effects
{
    [Serializable]
    public struct VampireEffect : IEffect
    {
        [field: SerializeField, Range(0, 100)]
        public int Percent { get; private set; }
    }
}
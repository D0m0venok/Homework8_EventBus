using UI;
using UnityEngine;

namespace Game
{
    public sealed class HealthComponent
    {
        private int _health;
        private HeroView _heroView;
        private HeroConfig _heroModel;
        private float _percentToLowHealth = 0.2f;

        public int Health
        {
            get => _health;
            set
            {
                var percent = _heroModel.Health * _percentToLowHealth;
            
                if(value <= 0)
                    AudioPlayer.Instance.PlaySound(_heroModel.DeathClip);
                else if (percent < _health && percent >= value)
                    AudioPlayer.Instance.PlaySound(_heroModel.LowHealthClip);
            
                _health = Mathf.Clamp(value, 0, _heroModel.Health);
                _heroView.SetStats($"{_health}/{_heroModel.Health}");
            }
        }
        public bool IsAlive => Health > 0;

        public HealthComponent(HeroConfig heroModel, HeroView heroView)
        {
            _heroView = heroView;
            _heroModel = heroModel;
            Health = _heroModel.Health;
        }
    }
}
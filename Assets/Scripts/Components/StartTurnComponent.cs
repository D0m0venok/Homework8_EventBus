using UI;
using UnityEngine;

namespace Game
{
    public sealed class StartTurnComponent
    {
        private readonly HeroConfig _heroModel;
        private readonly HeroView _heroView;

        public StartTurnComponent(HeroConfig heroModel, HeroView heroView)
        {
            _heroModel = heroModel;
            _heroView = heroView;
        }

        public void StartTurn()
        {
            _heroView.SetActive(true);
            AudioPlayer.Instance.PlaySound(_heroModel.StartTurnClips[Random.Range(0, _heroModel.StartTurnClips.Length)]);
        }
    }
}
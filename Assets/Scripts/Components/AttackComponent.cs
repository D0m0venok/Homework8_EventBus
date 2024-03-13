using UI;

namespace Game
{
    public sealed class AttackComponent
    {
        private HeroView _sourceHeroView;
        private HeroView _targetHeroView;

        public AttackComponent(HeroView sourceHeroView, HeroView targetHeroView)
        {
            _sourceHeroView = sourceHeroView;
            _targetHeroView = targetHeroView;
        }

        public void Attack()
        {
            _sourceHeroView.AnimateAttack(_targetHeroView);
        }
    }
}
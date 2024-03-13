using UI;

namespace Game.Pipeline.Visual.Tasks
{
    public sealed class AttackVisualTask : Task
    {
        private readonly HeroView _sourceView;
        private readonly HeroView _targetView;
        public AttackVisualTask(HeroView sourceView, HeroView targetView)
        {
            _sourceView = sourceView;
            _targetView = targetView;
        }
        
        protected override async void OnRun()
        {
            await _sourceView.AnimateAttack(_targetView);
            Finish();
        }
    }
}
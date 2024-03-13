using DG.Tweening;
using UnityEngine;

namespace Game.Pipeline.Visual.Tasks
{
    public sealed class DestroyVisualTask : Task
    {
        private readonly float _duration;
        private readonly Transform _transform;

        public DestroyVisualTask(IEntity entity, float duration = 0.15f)
        {
            _transform = entity.Get<ViewComponent>().HeroView.transform;
            _duration = duration;
        }
        
        protected override void OnRun()
        {
            _transform.DOScale(Vector3.zero, _duration).OnComplete(Finish);
        }
    }
}
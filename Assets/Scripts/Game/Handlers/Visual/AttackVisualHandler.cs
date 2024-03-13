using Game.Pipeline.Visual;
using Game.Pipeline.Visual.Tasks;

namespace Game.Handlers.Visual
{
    public sealed class AttackVisualHandler : BaseHandler<AttackEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public AttackVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }
        protected override void HandleEvent(AttackEvent evt)
        {
            var sourceView = evt.Source.Get<ViewComponent>().HeroView;
            var targetView = evt.Target.Get<ViewComponent>().HeroView;
            
            _visualPipeline.AddTask( new AttackVisualTask(sourceView, targetView));
        }
    }
}
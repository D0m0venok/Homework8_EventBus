using JetBrains.Annotations;
using Game.Pipeline.Visual;

namespace Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public sealed class HandleVisualPipelineTask : Task
    {
        private readonly VisualPipeline _visualPipeline;

        public HandleVisualPipelineTask(VisualPipeline visualPipeline)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnRun()
        {
            _visualPipeline.OnFinished += OnVisualPipelineFinished;
            
            _visualPipeline.Run();
        }

        protected override void OnFinish()
        {
            _visualPipeline.OnFinished -= OnVisualPipelineFinished;
        }

        private void OnVisualPipelineFinished()
        {
            _visualPipeline.Clear();
            Finish();
        }
    }
}
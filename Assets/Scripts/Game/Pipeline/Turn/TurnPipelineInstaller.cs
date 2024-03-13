using System;
using JetBrains.Annotations;
using Game.Pipeline.Turn.Tasks;
using Zenject;

namespace Game.Pipeline.Turn
{
    [UsedImplicitly]
    public sealed class TurnPipelineInstaller : IInitializable, IDisposable
    {
        private readonly TurnPipeline _turnPipeline;
        private readonly DiContainer _container;

        public TurnPipelineInstaller(TurnPipeline turnPipeline, DiContainer container)
        {
            _turnPipeline = turnPipeline;
            _container = container;
        }

        void IInitializable.Initialize()
        {
            _turnPipeline.AddTask(new StartTurnTask());
            _turnPipeline.AddTask(_container.Instantiate<PlayerTurnTask>(new object []{TeamType.Red}));
            _turnPipeline.AddTask(_container.Instantiate<HandleVisualPipelineTask>());
            _turnPipeline.AddTask(_container.Instantiate<PlayerTurnTask>(new object []{TeamType.Blue}));
            _turnPipeline.AddTask(_container.Instantiate<HandleVisualPipelineTask>());
            _turnPipeline.AddTask(new FinishTurnTask());
        }

        void IDisposable.Dispose()
        {
            _turnPipeline.Clear();
        }
    }
}
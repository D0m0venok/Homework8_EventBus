using Game;
using Game.Handlers.Turn;
using Game.Handlers.Visual;
using Game.Pipeline.Turn;
using Game.Pipeline.Visual;
using UI;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private UIService _uiService;
        [SerializeField] private TurnPipelineRunner _turnPipelineRunner;
        [SerializeField] private HeroConfigs _heroConfigs;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_uiService).AsSingle();
            Container.Bind<EventBus>().AsSingle();

            Container.BindInstance(_heroConfigs).AsSingle();
            Container.Bind<HeroEntitiesService>().AsSingle();

            Container.Bind<TurnPipeline>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsSingle();
            Container.BindInstance(_turnPipelineRunner).AsSingle();
            
            Container.BindInterfacesTo<AttackHandler>().AsSingle();
            Container.BindInterfacesTo<DealDamageHandler>().AsSingle();
            Container.BindInterfacesTo<HealingHandler>().AsSingle();
            
            Container.Bind<VisualPipeline>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttackVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DestroyVisualHandler>().AsSingle();
        }
    }
}
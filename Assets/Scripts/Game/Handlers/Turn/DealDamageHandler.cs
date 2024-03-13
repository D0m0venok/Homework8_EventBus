using Game.Effects;

namespace Game.Handlers.Turn
{
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        private readonly HeroEntitiesService _heroEntitiesService;
        
        public DealDamageHandler(EventBus eventBus, HeroEntitiesService heroEntitiesService) : base(eventBus)
        {
            _heroEntitiesService = heroEntitiesService;
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            var hitPointsComponent = evt.Entity.Get<HealthComponent>();
            
            if (evt.Entity.TryGet(out ConditionComponent conditionComponent) && !conditionComponent.Has<ShieldCondition>())
                hitPointsComponent.Health -= evt.Damage;
            else
                conditionComponent.Remove<ShieldCondition>();

            if (evt.Entity.TryGet<AbilityComponent>(out var abilityComponent) && abilityComponent.Ability.Effect is ElectricEffect electricEffectEvent)
            {
                abilityComponent.PlaySoundAbility();
                var team = evt.Entity.Get<TeamComponent>().TeamType;
                var enemies = team == TeamType.Red ? _heroEntitiesService.GetBluePlayerEntities() : _heroEntitiesService.GetRedPlayerEntities();
                
                foreach (var enemy in enemies.GetEntities())
                {
                    EventBus.RaiseEvent(new DealDamageEvent(enemy, electricEffectEvent.Damage));
                }
            }
            
            if (!hitPointsComponent.IsAlive)
                EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
        }
    }
}
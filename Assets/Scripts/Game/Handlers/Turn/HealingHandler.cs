namespace Game.Handlers.Turn
{
    public sealed class HealingHandler : BaseHandler<HealingEvent>
    {
        public HealingHandler(EventBus eventBus) : base(eventBus)
        {
            
        }

        protected override void HandleEvent(HealingEvent evt)
        {
            var hitPointsComponent = evt.Target.Get<HealthComponent>();
            hitPointsComponent.Health += evt.Health;
        }
    }
}
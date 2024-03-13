namespace Game
{
    public readonly struct HealingEvent : IEvent
    {
        public readonly IEntity Target;
        public readonly int Health;

        public HealingEvent(IEntity target, int health)
        {
            Target = target;
            Health = health;
        }
    }
}
namespace Game
{
    public readonly struct AttackEvent : IEvent
    {
        public IEntity Source { get; }
        public IEntity Target { get; }

        public AttackEvent(IEntity source, IEntity target)
        {
            Source = source;
            Target = target;
        }
    }
}
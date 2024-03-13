namespace Game
{
    public class TeamComponent
    {
        public TeamType TeamType { get; }
        
        public TeamComponent(TeamType teamType)
        {
            TeamType = teamType;
        }
    }
}
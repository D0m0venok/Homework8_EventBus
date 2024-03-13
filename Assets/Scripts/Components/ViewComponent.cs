using UI;

namespace Game
{
    public class ViewComponent
    {
        public HeroView HeroView { get; }
        
        public ViewComponent(HeroView heroView)
        {
            HeroView = heroView;
        }
    }
}
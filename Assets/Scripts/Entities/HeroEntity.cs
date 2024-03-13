using Game.Effects;
using UI;

namespace Game
{
    public sealed class HeroEntity : Entity
    {
        public HeroEntity(HeroConfig heroModel, HeroView heroView, TeamType team)
        {
            heroView.SetIcon(heroModel.Sprite);
            
            Add(new HealthComponent(heroModel, heroView));
            Add(new StartTurnComponent(heroModel, heroView));
            Add(new DamageComponent(heroModel.Damage));
            Add(new AbilityComponent(heroModel.Ability, heroModel.AbilityClips));
            Add(new ViewComponent(heroView));
            Add(new TeamComponent(team));
            var conditionComponent = new ConditionComponent();
            Add(conditionComponent);

            if (heroModel.Ability.Effect is ShieldEffect)
                conditionComponent.Add<ShieldCondition>();
        }
    }
}
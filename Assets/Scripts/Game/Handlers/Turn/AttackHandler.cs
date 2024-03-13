using Game.Effects;
using UnityEngine;

namespace Game.Handlers.Turn
{
    public class AttackHandler : BaseHandler<AttackEvent>
    {
        public AttackHandler(EventBus eventBus) : base(eventBus)
        {
        }
        
        protected override void HandleEvent(AttackEvent evt)
        {
            var source = evt.Source;
            var target = evt.Target;

            var damageComponent = source.Get<DamageComponent>();
            
            EventBus.RaiseEvent(new DealDamageEvent(target, damageComponent.Damage));

            var abilityComponent = source.Get<AbilityComponent>();
            
            if(abilityComponent.Ability.Effect is not IgnoreRetaliatoryDamageEffect)
                EventBus.RaiseEvent(new DealDamageEvent(source, 1));
            
            if (abilityComponent.Ability.Effect is FreezingEffect)
            {
                target.Get<ConditionComponent>().Add<FrozenCondition>();
                abilityComponent.PlaySoundAbility();
            }
            else if (source.Get<HealthComponent>().IsAlive && 
                     abilityComponent.Ability.Effect is VampireEffect vampireEffect && 
                     vampireEffect.Percent > Random.Range(0, 100))
            {
                var enemyHealth = target.Get<HealthComponent>().Health;
                var healingAmount = damageComponent.Damage > enemyHealth ? enemyHealth : damageComponent.Damage;
                EventBus.RaiseEvent(new HealingEvent(source, healingAmount));
            }
        }
    }
}